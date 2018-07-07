class CourseService {

    constructor($resource) {
        this.CourseService = $resource('/api/course/:id');
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
        this.UsersService = $resource('/api/users/:id', null, {
            login: {
                method: "POST",
                url: "/api/users/login"
            }
        });
    }

    register() {
        return this.UsersService.register();
    }

    login(user) {
        return this.UsersService.login(user).$promise;
        //window.location.href = "/";
    }


    save(user) {
        return this.UsersService.save(user).$promise;
    }

}

UsersService.$inject = ['$resource'];
angular.module("GolfHandicapCalculator").service("usersService", UsersService);
