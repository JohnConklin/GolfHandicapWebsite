class UsersController {

    constructor(usersService, $state) {
        this.usersService = usersService;
        this.$state = $state;
    }

    register() {
        this.usersService.save(this.user).then(() => {
            window.location.href = "/login";
        }
        );
    }

    userLogin(user) {
        this.usersService.userLogin(this.user).then(() => {
            return this.usersService.isLoggedIn();
        });
    }

    isLoggedIn() {
        return true;
        window.location.href = "/";
        console.log("You are logged in.");
    }
}

UsersController.$inject = ['usersService', '$state'];