//add new course
class CourseAddController {

    constructor(courseService, $state) {
        this.courseService = courseService;
        this.$state = $state;
        this.course = courseService.listCourses();
    }

    addCourse() {
        this.courseService.save(this.course).then(
            () => this.$state.go('Add')
        );
    }
}

CourseAddController.$inject = ['courseService', '$state'];
