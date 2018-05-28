angular.module('GolfHandicapCalculator', ['ui.router', 'ngResource']).config(routing);

routing.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider'];
function routing($stateProvider, $urlRouterProvider, $locationProvider) {
    $stateProvider.state('Home', {
        url: '/',
        templateUrl: '/ngApp/views/home.html',
        controller: HomeController,
        controllerAs: 'controller'
    }).state('About', {
        url: '/about',
        templateUrl: '/ngApp/views/about.html',
        controller: AboutController,
        controllerAs: 'controller'
    }).state('Contact', {
        url: '/contact',
        templateUrl: '/ngApp/views/contact.html',
        controller: ContactController,
        controllerAs: 'controller'
    }).state('Add', {
        url: '/add',
        templateUrl: '/ngApp/views/add.html',
        controller: CourseController,
        controllerAs: 'controller',
        data: {
            requiresAuthentication: true,
            redirectTo: 'Login'
        }
    }).state('Rounds', {
        url: '/rounds',
        templateUrl: '/ngApp/views/rounds.html',
        controller: RoundController,
        controllerAs: 'controller',
        data: {
            requiresAuthentication: true,
            redirectTo: 'Login'
        }
    }).state('Login', {
        url: '/login',
        templateUrl: '/ngApp/views/login.html',
        controller: UsersController,
        controllerAs: 'controller'
    }).state('Register', {
        url: '/register',
        templateUrl: '/ngApp/views/register.html',
        controller: UsersController,
        controllerAs: 'controller'
    }).state('notFound', {
        url: '/notFound',
        templateUrl: '/ngApp/views/notFound.html'
    });

    $urlRouterProvider.otherwise('/notFound');
    $locationProvider.html5Mode(true);
}

config.$inject = ['$rootScope', '$state', 'usersService'];
function config($rootScope, $state, usersService) {
    $rootScope.$on('$stateChangeStart', (e, to) => {
        // protect non-public views
        if (to.data && to.data.requiresAuthentication) {
            if (!usersService.isLoggedIn()) {
                e.preventDefault();
                $state.go('Login');
            }
        }
    });
}


angular.module('GolfHandicapCalculator').run(config);