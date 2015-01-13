appModule.factory('accountService', ['accountRepository','toastr',
    function (accountRepository, toastr) {
        return {
            register: function (registerModel) {
                return accountRepository.register(registerModel).success(function() {
                    
                }).error(function() {
                    
                });
            },
            login: function (loginModel) {
                return accountRepository.login(loginModel).success(function() {
                    
                }).error(function() {
                    
                });
            },
            logout: function() {
                return accountRepository.logout().success(function() {
                    
                }).error(function() {
                    
                });
            },
            changePassword: function(passwordModel) {
                return accountRepository.changePassword(passwordModel).error(function() {
                    toastr.success('Password changed');
                }).error(function() {
                    toastr.success('Unable to changed password');
                });
            }
        }
    }
]);
