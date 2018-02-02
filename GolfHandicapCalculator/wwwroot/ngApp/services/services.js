
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

