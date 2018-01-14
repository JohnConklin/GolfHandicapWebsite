//add new course
class CourseAddController {

    constructor(courseService, $state) {
        this.courseService = courseService;
        this.$state = $state;
        this.course = courseService.listCourses();
    }

    addCourse() {
        this.courseService.save(this.course).then(
            () => this.$state.go('add')
        );
    }
}

//ListCourseController.$inject = ['courseService', '$state'];