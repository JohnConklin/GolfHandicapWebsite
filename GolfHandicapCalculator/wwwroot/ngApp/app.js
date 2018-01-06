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
                controller: AddCourse,
                controllerAs: 'controller'
            }).state('Rounds', {
                url: '/rounds',
                templateUrl: '/ngApp/views/rounds.html',
                controller: AddRounds,
                controllerAs: 'controller'
            }).state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html'
            }).state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html'
            }).state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

            $urlRouterProvider.otherwise('/notFound');
            $locationProvider.html5Mode(true);
        }