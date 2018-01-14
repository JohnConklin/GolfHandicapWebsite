//add new round
class RoundAddController {

    constructor(roundService, $state) {
        this.roundService = roundService;
        this.$state = $state;
        this.round = roundService.listRound();
        this.course = roundService.listCourses();
    }

    addCourse() {
        this.roundService.save(this.round).then(
            () => this.$state.go('add')
        );
    }
}

//ListCourseController.$inject = ['courseService', '$state'];