///<reference path="~/Scripts/Lib/jasmine.js"/>
///<reference path="~/Scripts/Lib/angular.js"/>
///<reference path="~/Scripts/Lib/angular-toastr.js"/>
///<reference path="~/Scripts/Lib/angular-route.js"/>
///<reference path="~/Scripts/Lib/ui-bootstrap-tpls.js"/>
///<reference path="~/Scripts/Lib/angular-mocks.js"/>

///<reference path="~/Scripts/App/appModule.js"/>
///<reference path="~/Scripts/App/Account/Controllers/loginController.js"/>
///<reference path="~/Scripts/App/Account/Services/accountRepository.js"/>
///<reference path="~/Scripts/App/Account/Services/accountService.js"/>

describe("appModule unit testing.", function () {
    beforeEach(function() {
        module('appModule');
    });

    it('It should have a login controller.', function() {
        expect('appModule.loginController').toBeDefined();
    });

    it('It should have a registration controller', function() {
        expect('appModule.registrationController').toBeDefined();
    });

    it("It should have a change password controller", function() {
        expect("appModule.changePasswordController").toBeDefined();
    });

    it("It should have a account service.", function() {
        expect('appModule.accountService').toBeDefined();
    });

    it("It should have a account repository.", function() {
        expect("appModule.accountRepository").toBeDefined();
    });
});
