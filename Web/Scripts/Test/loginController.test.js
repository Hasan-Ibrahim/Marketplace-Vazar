///<reference path="~/Scripts/Lib/jasmine.js"/>
///<reference path="~/Scripts/Lib/angular.js"/>
///<reference path="~/Scripts/Lib/angular-toastr.js"/>
///<reference path="~/Scripts/Lib/angular-route.js"/>
///<reference path="~/Scripts/Lib/ui-bootstrap-tpls.js"/>
///<reference path="~/Scripts/Lib/angular-mocks.js"/>

///<reference path="~/Scripts/App/appModule.js"/>
///<reference path="~/Scripts/App/urlResolver.js"/>
///<reference path="~/Scripts/App/Account/Controllers/loginController.js"/>
///<reference path="~/Scripts/App/Account/Services/accountRepository.js"/>
///<reference path="~/Scripts/App/Account/Services/accountService.js"/>

describe('loginController tests', function () {
    beforeEach(function () {
        module('appModule');
    });

    var scope = {};
    it("should have a method login.", inject(function ($controller, $rootScope, accountService) {
        scope = $rootScope.$new();
        $controller('loginController', { $scope: scope, accountService: accountService });
        expect(scope.login).toBeDefined();
    }));
});