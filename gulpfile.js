/// <binding BeforeBuild='less' AfterBuild='zip' />
var gulp = require("gulp");
var less = require("gulp-less");
var path = require("path");
var plumber = require("gulp-plumber");
var zip = require("gulp-zip");

gulp.task("less", function () {
    return gulp.src("./UnionTemplate/css/less/*.less")
    .pipe(plumber())
      .pipe(less({
          paths: [path.join(__dirname, "less", "includes")]
      }))
      .pipe(gulp.dest("./UnionTemplate/css/"));
});

gulp.task("zip", function () {
    return gulp.src(["./Union/**", "!./Union/*.config"])
        .pipe(zip("UnionTemplate.zip"))
        .pipe(gulp.dest("./UnionDistribution"));
});