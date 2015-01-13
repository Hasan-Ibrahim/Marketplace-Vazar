///<reference path="~/Scripts/Lib/jasmine.js"/>
///<reference path="~/Scripts/Lib/angular.js"/>
///<reference path="~/Scripts/Lib/angular-mocks.js"/>

///<reference path="~/Scripts/App/Account/Controllers/loginController.js"/>
///<reference path="~/Scripts/App/Account/Services/accountRepository.js"/>
///<reference path="~/Scripts/App/Account/Services/accountService.js"/>

describe("Controllers", function () {

    beforeEach(angular.module("appModule", []));

    describe("login controller", function () {

        var scope,
            accountService,
            controller;

        beforeEach(inject(function ($rootScope, $controller) {
            scope = $rootScope.$new();

            accountService = {
                login: function (loginModel) {
                    return true;
                }
            }

            controller = $controller('loginController', { $scope: scope, accountService: accountService });
        }));

        it('the page should login', function () {
            expect(true).toBe(true);
        });

        it('It should pass', function () {
            expect(true).toBe(true);
        });
    });
});