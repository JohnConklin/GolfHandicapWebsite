//list existing courses

export class ListCourseController {

    constructor(courseService) {
        this.course = courseService.listCourses();
    }
}

ListCourseController.$inject = ['listCourses'];

//add new course
export class CourseAddController {

    constructor(courseService, $state) {
        this.courseService = courseService;
        this.$state = $state;
    }

    addCourse() {
        this.courseService.save(this.course).then(
            () => this.$state.go('add')
        );
    }
}

ListCourseController.$inject = ['courseService', '$state'];