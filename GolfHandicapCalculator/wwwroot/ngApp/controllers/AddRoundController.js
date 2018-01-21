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
                window.location.reload(true);   //added so the form fields would clear contents submtited to db.
                this.rounds = this.roundService.listRound();
            }
        );
    }

    HandicapCalc() {

    }
}

RoundAddController.$inject = ['roundService', '$state'];