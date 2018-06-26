class UsersController {

    constructor(usersService, $state, $window) {
        this.usersService = usersService;
        this.$state = $state;
        this.error = "Y";
        this.window = $window;
        this.user = { userName: '', password: '' };
    }

    register() {
        this.usersService.save(this.user).then(() => {
            window.location.href = "/login";
        }
        );
    }

    login() {
        console.log("UserController.js - login");
        this.usersService.login(this.user).then((results) => {
            this.window.sessionStorage.setItem("id", this.user.userName);        //this sets a variable in session storage
            window.location.href = "/";

        }).catch((err) => {
            this.error = err.data;
        });
    }

   
    logout() {
        sessionStorage.clear();
        window.location.href = "/";
        return true;
    }
}

UsersController.$inject = ['usersService', '$state', '$window'];