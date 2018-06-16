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
            console.log("login");
            this.window.sessionStorage.setItem("test", "test");
            console.log("testing");
            this.window.sessionStorage.setItem("id", vm.UserID);        //this sets a variable in session storage
            this.window.sessionStorage.setItem("user", vm.UserName);

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

UsersController.$inject = ['usersService', '$state'];