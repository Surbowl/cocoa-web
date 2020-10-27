/// <binding Clean='clean' />
const gulp = require('gulp');
const rimraf = require('rimraf');

const paths = {
    css: './wwwroot/dist/css/',
    js: './wwwroot/dist/js/'
};

gulp.task('clean-css', done => rimraf(paths.css, done));
gulp.task('clean-js', done => rimraf(paths.js, done));

gulp.task('clean', gulp.series(['clean-js', 'clean-css']));