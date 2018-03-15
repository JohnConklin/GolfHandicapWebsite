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
        //trying to create user access pages only
        data: {
            requiresAuthentication: true
        }
    }).state('Rounds', {
        url: '/rounds',
        templateUrl: '/ngApp/views/rounds.html',
        controller: RoundController,
        controllerAs: 'controller',
        //trying to create user access pages only
        data: {
            requiresAuthentication: true
        }
    }).state('login', {
        url: '/login',
        templateUrl: '/ngApp/views/login.html',
        controller: UserController,
        controllerAs: 'controller'
    }).state('register', {
        url: '/register',
        templateUrl: '/ngApp/views/register.html',
        controller: UserController,
        controllerAs: 'controller'
    }).state('notFound', {
        url: '/notFound',
        templateUrl: '/ngApp/views/notFound.html'
    });

    $urlRouterProvider.otherwise('/notFound');
    $locationProvider.html5Mode(true);
}

config.$inject = ['$rootScope', '$state', 'userService'];
function config($rootScope, $state, accountService) {
    $rootScope.$on('$stateChangeStart', (e, to) => {
        // protect non-public views
        if (to.data && to.data.requiresAuthentication) {
            if (!accountService.isLoggedIn()) {
                e.preventDefault();
                $state.go('login');
            }
        }
    });
}
angular.module('GolfHandicapCalculator').run(config);