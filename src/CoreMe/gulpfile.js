/// <binding BeforeBuild='auto' Clean='clean' />
const gulp = require('gulp');
const clean = require('gulp-clean');
const cleanCSS = require('gulp-clean-css');
const rename = require('gulp-rename');
const browserify = require('browserify');
const vueify = require('vueify')
const envify = require('envify/custom')
const source = require('vinyl-source-stream');
const tsify = require('tsify');
const uglify = require('gulp-uglify');
const sourcemaps = require('gulp-sourcemaps');
const buffer = require('vinyl-buffer');

const debug = false;

const paths = {
    js: 'wwwroot/js/',
    css: 'wwwroot/css/',
    lib: 'wwwroot/lib/'
}

// 有 ts 文件需要编译的 Views
const tsFiles = [
    { controller: 'Home', action: 'Index' }
]

// 有 css 文件需要编译的 Views
const cssFiles = [
    { controller: 'Home', action: 'Index' },
    { controller: 'Shared', action: '_Layout' }
]

// 需要移动到 wwwroot/lib 的文件
const libs = [
    { name: 'bulma', dist: './node_modules/bulma/css/*.*' }
];

// 将 lib 移动到 wwwroot/lib
gulp.task('move:lib', done => {
    libs.forEach(function (item) {
        gulp.src(item.dist)
            .pipe(gulp.dest(paths.lib + item.name));
    });
    done()
});

// 清空 wwwroot/js 文件夹
gulp.task('clean:js', () => {
    return gulp.src([paths.js + '/**/*.min.js', paths.js + '/**/*.js.map'], { read: false, allowEmpty: true })
        .pipe(clean());
});

// 清空 wwwroot/css 文件夹
gulp.task('clean:css', () => {
    return gulp.src([paths.css + '/**/*.min.css', paths.css + '/**/*.css.map'], { read: false, allowEmpty: true })
        .pipe(clean());
});

// 压缩 css 并创建 map
gulp.task('min:css', done => {
    cssFiles.forEach((cssFile) => {
        gulp.src('./Views/' + cssFile.controller + '/' + cssFile.action + '.cshtml.css')
            .pipe(sourcemaps.init())
            .pipe(cleanCSS({ debug: debug }))
            .pipe(rename(cssFile.action.toLowerCase() + '.min.css'))
            .pipe(sourcemaps.write('./', {
                mapFile: path => path.replace('.min.', '.')
            }))
            .pipe(gulp.dest(paths.css + '/' + cssFile.controller.toLowerCase()));
    });
    done();
});

// 将 ts 编译为 min.js 并创建 map
gulp.task('min:js', done => {
    tsFiles.forEach((tsFile) => {
        // https://www.bookstack.cn/read/TypeScript-4.0-zh/8593981d0f4f8496.md
        browserify({
            basedir: './Views',
            debug: debug,
            entries: [tsFile.controller + '/' + tsFile.action + '.cshtml.ts'],
            cache: {},
            packageCache: {}
        })
            // https://vuejs.org/v2/guide/deployment.html
            .transform(vueify)
            .transform(
                { global: true },
                envify({ NODE_ENV: (debug ? 'development' : 'production') })
            )
            .plugin(tsify)
            .bundle()
            .pipe(source(tsFile.action.toLowerCase() + '.min.js'))
            .pipe(buffer())
            .pipe(sourcemaps.init({ loadMaps: true }))
            .pipe(uglify())
            .pipe(sourcemaps.write('./', {
                mapFile: path => path.replace('.min.', '.')
            }))
            .pipe(gulp.dest(paths.js + tsFile.controller.toLowerCase()));
    });
    done();
});

// 清除生成的文件
gulp.task('clean', gulp.parallel(['clean:css', 'clean:js']));

// 清除生成的文件并重新编译
gulp.task('auto', gulp.parallel([
    'move:lib',
    gulp.series([
        'clean:css',
        'min:css'
    ]),
    gulp.series([
        'clean:js',
        'min:js'
    ])
]));