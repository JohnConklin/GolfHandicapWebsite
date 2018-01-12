class AddCourse {

    getCourse() {
        this.getCourse = this.AddCourse.query();
    }

    save() {
        console.log(this.AddCourse);

        this.AddCourse.save(this.AddCourse).$promise.then(() => {
            this.AddCourse = null;
            this.getCourse();
        })
    }

   // constructor() {
   //     this.message = 'Hello, welcome to my site.';
   // }
    constructor($resource, $state) {
        this.AddCourse = $resource('api/addcourse/:id');
        this.getCourse();
    }
}

    angular.module('GolfHandicapCalculator').controller('AddCourse', AddCourse);

