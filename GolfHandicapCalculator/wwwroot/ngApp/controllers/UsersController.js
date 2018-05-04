class UsersController {

    constructor(usersService, $state) {
        this.usersService = usersService;
        this.$state = $state;
        this.error = "Y";
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

    isLoggedIn() {
        console.log("UserController.js - isLoggedIn()");

        if (this.currentUser == null) {
            return false;
        }
        return true;
        window.location.href = "/about";

    }

    logout() {
        return true;
    }
}

UsersController.$inject = ['usersService', '$state'];