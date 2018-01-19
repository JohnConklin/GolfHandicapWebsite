//add new course
class CourseAddController {

    constructor(courseService, $state) {
        this.courseService = courseService;
        this.$state = $state;
        this.courses = courseService.listCourses();
    }

    addCourse() {
        console.log(this.course);

        this.courseService.save(this.course).then(() =>
        {
            this.courses = this.courseService.listCourses();
        }
        );
    }
}

CourseAddController.$inject = ['courseService', '$state'];
