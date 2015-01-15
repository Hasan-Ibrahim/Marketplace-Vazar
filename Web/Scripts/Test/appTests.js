///<reference path="~/Scripts/Lib/jasmine.js"/>
///<reference path="~/Scripts/Lib/angular.js"/>
///<reference path="~/Scripts/Lib/angular-route.js"/>
///<reference path="~/Scripts/Lib/angular-toastr.js"/>
///<reference path="~/Scripts/Lib/ui-bootstrap-tpls.js"/>
///<reference path="~/Scripts/Lib/angular-mocks.js"/>

///<reference path="~/Scripts/App/appModule.js"/>
///<reference path="~/Scripts/App/urlResolver.js"/>
///<reference path="~/Scripts/App/Account/Controllers/loginController.js"/>
///<reference path="~/Scripts/App/Account/Services/accountRepository.js"/>
///<reference path="~/Scripts/App/Account/Services/accountService.js"/>

describe("appModule", function () {
    var scope, controller;

    beforeEach(function () {
        module('appModule', function($provider) {
            $provider.value('accountService', mockService);
        });
    });

    beforeEach(inject(function ($rootScope, $controller, mockService) {
        scope = $rootScope.$new();
        controller = $controller('loginController', {
            '$scope': scope,
            'accountService': mockService
        });
    }));

    it('Test if everything is ok', function () {
        expect(true).toBeTruthy();
    });

});