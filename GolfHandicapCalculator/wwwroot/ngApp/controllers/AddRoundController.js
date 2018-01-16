//add new round
class RoundAddController {

    constructor(roundService, $state) {
        this.roundService = roundService;
        this.$state = $state;
        this.round = roundService.listRound();
        this.course = roundService.listCourses();
    }

    addRound() {
        this.roundService.save(this.round).then(
            () => this.$state.go('add')
        );
    }
}

RoundAddController.$inject = ['roundService', '$state'];