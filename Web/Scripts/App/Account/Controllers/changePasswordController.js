appModule.controller('changePasswordController', ['$scope', 'accountService','$location',
    function ($scope, accountService, $location) {
        $scope.changePassword = function() {
            accountService.changePassword($scope.changePasswordModel).success(function() {
                $location.path('/');
            });
        };
    }
]);
