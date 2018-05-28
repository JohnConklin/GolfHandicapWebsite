class UsersController {

    constructor(usersService, $state, $window) {
        this.usersService = usersService;
        this.$state = $state;
        this.error = "Y";
        this.window = $window;
    }

    register() {
        this.usersService.save(this.user).then(() => {
            window.location.href = "/login";
        }
        );
    }

    login(user) {
        console.log("UserController.js - login");
        this.usersService.login(this.user).then((results) => {
            this.usersService.isLoggedIn();
            window.location.href = "/";

        }).catch((err) => {
            this.error = err.data;
        });
    }

   
    logout() {
        return true;
    }
}

UsersController.$inject = ['usersService', '$state'];