appModule.controller('loginController', ['$scope','accountService',
    function ($scope, accountService) {
        $scope.login = function() {
            accountService.login($scope.loginModel).success(function () {
                $location.path('/');
            });
        }
    }
]);
