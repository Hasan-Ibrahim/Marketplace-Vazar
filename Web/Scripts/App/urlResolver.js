appModule.factory('urlResolver', ['$window',
    function ($window) {

        function getActionUrl(controllerName, actionName) {
            return $window.location.origin + "/" + controllerName + "/" + actionName;
        }

        return {
            resolveAccount: function (actionName) {
                return getActionUrl('Account', actionName);
            },
            resolveHome: function (actionName) {
                return getActionUrl('Home', actionName);
            }
        }
    }
]);

