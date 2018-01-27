//add new round
class RoundAddController {

    constructor(roundService, courseService, $state) {
        this.roundService = roundService;
        this.$state = $state;
        this.rounds = roundService.listRound();
        this.selected;
        this.courses = courseService.listCourses();
    }

    addRound() {
        console.log(this.round);
        this.round.courseName = this.selected.name;
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

RoundAddController.$inject = ['roundService', 'courseService', '$state'];

/*
//Added to display courses in drop-down list for adding rounds.
class DisplayCourses {
    
    constructor(courseService, $state) {
        this.courseService = courseService;
        this.$state = $state;
        this.courses = courseService.listCourses();
    }

    listCourses() {
        this.courses = this.listCourses();
    }

}

DisplayCourses.$inject = ['courseService', '$state'];
*/