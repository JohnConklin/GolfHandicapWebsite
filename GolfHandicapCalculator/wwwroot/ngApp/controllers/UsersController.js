class UsersController {

    constructor(usersService, $state) {
        this.usersService = usersService;
        this.$state = $state;
        console.log("File: UsersController.js - constuctor");
    }

    register() {
        console.log("Register");
        this.usersService.save(this.user).then(() => {
            console.log(this.user);
            window.location.href = "/login";
        }
        );
    }

    userLogin(user) {
        console.log("Login - File: UsersController.js");
        this.usersService.userLogin(this.user).then(() => {
            console.log(this.user);
            window.location.href = "/";
        });
    }
}

UsersController.$inject = ['usersService', '$state'];