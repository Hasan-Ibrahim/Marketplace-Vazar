///<reference path="~/Scripts/Lib/jasmine.js"/>
///<reference path="~/Scripts/Lib/angular.js"/>
///<reference path="~/Scripts/Lib/angular-toastr.js"/>
///<reference path="~/Scripts/Lib/angular-route.js"/>
///<reference path="~/Scripts/Lib/ui-bootstrap-tpls.js"/>
///<reference path="~/Scripts/Lib/angular-mocks.js"/>

///<reference path="~/Scripts/App/appModule.js"/>
///<reference path="~/Scripts/App/urlResolver.js"/>
///<reference path="~/Scripts/App/Account/Services/accountRepository.js"/>


describe("tests for urlResolver", function () {
    beforeEach(function () {
        module('appModule');
    });
    

    it("should have a method resolveAccount", inject(function (urlResolver) {
        expect(urlResolver.resolveAccount).toBeDefined();
    }));

    it("should return url that ends with '/account/action'", inject(function (urlResolver) {
        var url = urlResolver.resolveAccount("action").toLowerCase();
        expect(url.indexOf('/account/action') != -1).toBeTruthy();
    }));


    it("should have a method resolveHome", inject(function (urlResolver) {
        expect(urlResolver.resolveHome).toBeDefined();
    }));

    it("should return url that ends with '/home/action'", inject(function (urlResolver) {
        var url = urlResolver.resolveHome("action").toLowerCase();
        expect(url.indexOf('/home/action') != -1).toBeTruthy();
    }));
});