/// <binding BeforeBuild='auto' Clean='clean:js' />
var gulp = require('gulp');
var clean = require('gulp-clean');
var browserify = require('browserify');
var vueify = require('vueify')
var envify = require('envify/custom')
var source = require('vinyl-source-stream');
var tsify = require('tsify');
var uglify = require('gulp-uglify');
var sourcemaps = require('gulp-sourcemaps');
var buffer = require('vinyl-buffer');

// development or production
const nodeEnv = 'production';

const paths = {
    js: 'wwwroot/js/',
    lib: 'wwwroot/lib/'
}

// 需要编译的 ts 文件
const tsFiles = [
    { controller: 'Home', action: 'Index' }
]

// 需要移动到 wwwroot/lib 的文件
const libs = [
    { name: 'bulma', dist: './node_modules/bulma/css/*.*' }
];

// 设置首字母小写
String.prototype.firstLowerCase = function () {
    return this.replace(/\b(\w)(\w*)/g, function ($0, $1, $2) {
        return $1.toLowerCase() + $2;
    });
}

// 清空 wwwroot/js 文件夹
gulp.task('clean:js', function () {
    return gulp.src(paths.js, { read: false, allowEmpty: true })
        .pipe(clean());
});

// 将 lib 移动到 wwwroot/lib
gulp.task('move:lib', done => {
    libs.forEach(function (item) {
        gulp.src(item.dist)
            .pipe(gulp.dest(paths.lib + item.name));
    });
    done()
});

// 将 ts 编译为 min.js 并创建 map
gulp.task('bundle:js', done => {
    tsFiles.forEach(function (tsFile) {
        browserify({
            basedir: './Views',
            entries: [tsFile.controller + '/' + tsFile.action + '.ts'],
            cache: {},
            packageCache: {}
        })
        .transform(vueify)
        .transform(
            // https://vuejs.org/v2/guide/deployment.html
            { global: true },
            envify({ NODE_ENV: nodeEnv })
        )
        .plugin(tsify)
        .bundle()
        .pipe(source(tsFile.action.firstLowerCase() + '.min.js'))
        .pipe(buffer())
        .pipe(sourcemaps.init({ loadMaps: true }))
        .pipe(uglify())
        .pipe(sourcemaps.write('./', {
            mapFile: path => path.replace('.min.', '.')
        }))
        .pipe(gulp.dest(paths.js + tsFile.controller.firstLowerCase()));
    });
    done();
});

// 执行所有任务
gulp.task('auto', gulp.parallel(['move:lib', gulp.series(['clean:js', 'bundle:js'])]));