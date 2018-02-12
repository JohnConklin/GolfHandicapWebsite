//add new round
class RoundController {

    constructor(roundService, courseService, $state) {
        this.roundService = roundService;
        this.$state = $state;
        this.rounds = roundService.listRound();
        this.selected;
        this.courses = courseService.listCourses();
    }

    //1.  Calculate Handicap Differential:  (Score - Course Rating) x 113 / Slope Rating  --FOR EACH INDIVIDUAL ROUND

    addRound() {
        //console.log(this.round);
        this.round.roundDifferential = this.calcDiff();
        this.round.courseName = this.selected.name;
        this.roundService.save(this.round).then(() =>
            {
                window.location.reload(true);   //added so the form fields would clear contents submtited to db.
                this.rounds = this.roundService.listRound();
            }
        );
    }

    calcDiff() {
        let differential = (this.round.holeScore - this.selected.rating) * 113 / this.selected.slope;
        differential = Math.round(differential);
        return differential;
    }
    /*
    2.  Get average of differentials by adding together and dividing by total number used.
    3.  Final Handicap:  (Sum of differentials / number of differentials) x 0.96
    */


    handicapCalc() {

        var diff = this.rounds.differential;
        var sum = 0;
    
        for (var key in diff) {
            //sum the values
            sum += key + diff;
        }
        //get length of array
        let count = diff.length;

        //get average
        let avgDiff = sum / count;

        let handicap = avgdiff / count * 0.96;
        handicap = Math.round(handicap);

        console.log(handicap);
        return handicap; 
    }
}

RoundController.$inject = ['roundService', 'courseService', '$state'];

