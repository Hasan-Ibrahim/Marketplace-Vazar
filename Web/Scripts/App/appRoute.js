appModule.config([
    '$routeProvider', function ($routeProvider) {
        $routeProvider
        .when('/home', {
            templateUrl: '/Templates/Home/home.html',
            controller: 'homeController'
        })
        .when('/account/register', {
            templateUrl: '/Templates/Account/registration.html',
            controller: 'registrationController'
        })
        .when('/account/logOn', {
            templateUrl: '/Templates/Account/logOn.html',
            controller: 'logOnController'
        })
        .when('/account/changePassword', {
            templateUrl: '/Templates/Account/changePassword.html',
            controller: 'logOnController'
        })
        .otherwise({
            redirectTo: '/home'
        });
    }
]);
