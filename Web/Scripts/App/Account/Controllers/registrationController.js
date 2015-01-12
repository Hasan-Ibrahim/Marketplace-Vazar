appModule.controller('registrationController', ['$scope','accountService',
    function ($scope, accountService) {
        $scope.register = function() {
            accountService.register($scope.registerModel);
        }
    }
]);
