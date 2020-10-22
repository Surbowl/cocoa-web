/// <binding BeforeBuild='default' Clean='clean' />
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
const through = require('through2');

const debug = false;
const paths = {
    js: 'wwwroot/js/',
    css: 'wwwroot/css/',
    lib: 'wwwroot/lib/'
}
// 需要移动到 wwwroot/lib 的文件
const libs = [
    { name: 'bulma', dist: 'node_modules/bulma/css/*.*' }
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

// 找到 View/ 文件夹下的所有 *.cshtml.css 文件，压缩生成 *.min.css 与 *.css.map 文件保存在 wwwroot/css 文件夹下
gulp.task('min:css', () => {
    return gulp.src('Views/**/*.cshtml.css')
        .pipe(sourcemaps.init())
        .pipe(cleanCSS({ debug: debug }))
        .pipe(rename(path => {
            let pathArr = path.dirname.split('\\');
            return {
                dirname: pathArr[pathArr.length - 1].toLowerCase(),
                basename: path.basename.toLowerCase().replace('.cshtml', ''),
                extname: '.min.css'
            };
        }))
        .pipe(sourcemaps.write('./', {
            mapFile: path => path.replace('.min.', '.')
        }))
        .pipe(gulp.dest(paths.css));
});

// 找到 View/ 文件夹下的所有 *.cshtml.ts 文件，编译与压缩，并将生成的 *.min.js 与 *.js.map 文件保存在 wwwroot/js 文件夹下
gulp.task('min:js', () => {
    var bundle = function (file) {
        let dirNames = file.dirname.split('\\');
        let dest = paths.js + dirNames[dirNames.length - 1].toLowerCase();
        // https://www.bookstack.cn/read/TypeScript-4.0-zh/8593981d0f4f8496.md
        return browserify({
            debug: debug,
            entries: file.path
        })
            .plugin(tsify)
            // https://vuejs.org/v2/guide/deployment.html
            .transform(vueify)
            .transform(
                { global: true },
                envify({ NODE_ENV: (debug ? 'development' : 'production') })
            )
            .bundle()
            .pipe(source(file.basename.toLowerCase().replace('.cshtml.ts', '.min.js')))
            .pipe(buffer())
            .pipe(sourcemaps.init({ loadMaps: true }))
            .pipe(uglify())
            .pipe(sourcemaps.write('./', {
                mapFile: path => path.replace('.min.', '.')
            }))
            .pipe(gulp.dest(dest));
    }

    return gulp.src('Views/**/*.cshtml.ts')
        .pipe(through.obj(function (file, enc, next) {
            if (!file.isNull() && !file.isDirectory()) {
                bundle(file);
            }
            next(null, file);
        }));
});

// 清除生成的文件
gulp.task('clean', gulp.parallel(['clean:css', 'clean:js']));

// 清除生成的文件并重新编译
gulp.task('default', gulp.parallel([
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