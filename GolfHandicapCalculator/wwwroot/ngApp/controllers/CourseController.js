//add new course
class CourseController {

    constructor(courseService, $state) {
        this.courseService = courseService;
        this.$state = $state;
        this.courses = courseService.listCourses();
    }

    addCourse() {
        console.log(this.course);

        this.courseService.save(this.course).then(() =>
        {
            window.location.reload(true);   //added so the form fields would clear contents submtited to db.
            this.courses = this.courseService.listCourses();
        }
        );
    }
}

CourseController.$inject = ['courseService', '$state'];
