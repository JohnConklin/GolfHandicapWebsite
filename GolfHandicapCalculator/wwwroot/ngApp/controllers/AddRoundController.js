//add new round
class RoundAddController {

    constructor(roundService, $state) {
        this.roundService = roundService;
        this.$state = $state;
        this.rounds = roundService.listRound();
    }

    addRound() {
        console.log(this.round);

        this.roundService.save(this.round).then(() =>
            {
                this.rounds = this.roundService.listRound();
            }
        );
    }
}

RoundAddController.$inject = ['roundService', '$state'];