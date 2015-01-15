appModule.factory('accountRepository', ['appHelperService', '$http',
    function (appHelperService, $http) {
        return {
            register: function (registerModel) {
                return $http.post(appHelperService.resolveAccount('Register'), registerModel);
            },
            login: function (loginModel) {
                return $http.post(appHelperService.resolveAccount('Login'), loginModel);
            },
            logout: function () {
                return $http.get(appHelperService.resolveAccount('Logout'));
            },
            changePassword: function (passwordModel) {
                return $http.get(appHelperService.resolveAccount('ChangePassword'), passwordModel);
            }
        }
    }
]);
