class UsersController {

    constructor(userService, $state) {
        this.userService = userService;
        this.$state = $state;
        this.registers = userService.register();
        console.log("constuctor");
    }

    register() {
        console.log("Register");
        this.userService.save(this.user).then(() => {
            console.log(this.user);
            window.location.reload(true);   //added so the form fields would clear contents submtited to db.
            this.registers = this.userService.register();
        }
        );

    }

    login() {


    }
}

UsersController.$inject = ['userService', '$state'];
