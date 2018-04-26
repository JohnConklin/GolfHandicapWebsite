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

class UsersService {

    constructor($resource) {
        //console.log("UsersService - File: service.js");
        this.UsersService = $resource('/api/users/:id', null, {
            login: {
                method: "POST",
                url: "/api/users/login"
            }
        });
    }

    //trying to create user access pages only
    isLoggedIn() {
        return true;
        console.log("You are logged in.");
    }

    register() {
        return this.UsersService.register();
    }

    userLogin(user) {
        return this.UsersService.login(user).$promise;
        return this.isLoggedIn().$promise;
    }

    save(user) {
        return this.UsersService.save(user).$promise;
    }

}

UsersService.$inject = ['$resource'];
angular.module("GolfHandicapCalculator").service("usersService", UsersService);
