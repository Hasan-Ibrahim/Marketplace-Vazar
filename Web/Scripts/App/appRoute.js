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
        .when('/account/login', {
            templateUrl: '/Templates/Account/login.html',
            controller: 'loginController'
        })
        .when('/account/changePassword', {
            templateUrl: '/Templates/Account/changePassword.html',
            controller: 'changePasswordController'
        })
        .otherwise({
            redirectTo: '/account/register'
        });
    }
]);

