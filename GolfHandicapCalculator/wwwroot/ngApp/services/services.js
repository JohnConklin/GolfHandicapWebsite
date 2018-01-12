export class AccountService {
    isLoggedIn() {
        return false;

    }
}

export class CourseService {

    constructor($resource) {
        this.CourseService = $resource('/api/addcourse/:id');
    }

    listCourses() {
        return this.CourseService.query();
    }

    save(course) {
        return this.CourseService.save(course).$promise;
    }

    getCourse(id) {
        return this.CourseService.get({ id: id });
    }

}

CourseService.$inject = ['$resource'];
