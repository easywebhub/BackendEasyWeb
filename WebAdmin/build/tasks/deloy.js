'use strict';

const gulp = require('gulp');
const runSequence = require('run-sequence');
const paths = require('../paths');
var exec = require('child_process').exec;


// deletes all files in the output path

gulp.task('copy-to-deloy', function () {
    return gulp.src([paths.exportSrv + '/*', paths.exportSrv + '/**/*.*', paths.exportSrv + '/**/**/*.*', paths.exportSrv + '/**/**/*.*', paths.exportSrv + '/**/**/**/*.*'])
        .pipe(gulp.dest(paths.deploy));
});


// use after prepare-release
gulp.task('predeploy', function (callback) {
    return runSequence(
        'copy-to-deloy',
        callback
    );
});
gulp.task('deploy', function () {
    exec(`git add -A && git commit -m "commit to push"  && git push`, {
        cwd: paths.deploy
    }, function (error, stdout, stderr) {
        console.log('stdout: ' + stdout);
        console.log('stderr: ' + stderr);
        if (error !== null) {
            console.log('exec error: ' + error);
        }
    });

})
let Cmd = () => {
    switch (process.platform) {
        case 'win32':
    }
}
