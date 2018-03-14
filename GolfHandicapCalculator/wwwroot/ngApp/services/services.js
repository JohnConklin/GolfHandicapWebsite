
class CourseService {

    constructor($resource) {
        //debugger;
        this.CourseService = $resource('/api/course/:id');
    }

   
    listCourses() {
        //debugger;
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
angular.module("GolfHandicapCalculator").service("courseService", CourseService);

class RoundService {

    constructor($resource) {
        this.RoundService = $resource('/api/round/:id');
    }

    listRound() {
        return this.RoundService.query();
    }

    listCourses() {
        return this.RoundService.query();
    }

    save(round) {
        return this.RoundService.save(round).$promise;
    }

    getRound(id) {
        return this.RoundService.get({ id: id });
    }

}

RoundService.$inject = ['$resource'];
angular.module("GolfHandicapCalculator").service("roundService", RoundService);

class UserService {

    constructor($resource) {
        this.UserService = $resource('/api/login/:user');
    }

    //trying to create user access pages only
    isLoggedIn() {
        return false;
    }

    register() {
        return this.UserService.register();
    }

    login(user) {
        return this.UserService.login(user).$promise;
    }
}

UserService.$inject = ['$resource'];
angular.module("GolfHandicapCalculator").service("userService", UserService);

