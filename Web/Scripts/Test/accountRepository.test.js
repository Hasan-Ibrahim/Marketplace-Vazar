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

describe("Account service unit testing.", function () {
    beforeEach(function () {
        module('appModule');
    });

    it("should have a register method.", inject(function (accountRepository) {
        expect(accountRepository.register).toBeDefined();
    }));

    it('should post registration success',
       inject(function (accountRepository, urlResolver, $httpBackend) {

           $httpBackend.expect('POST', urlResolver.resolveAccount('Register'))
               .respond(200, { success: true });

           accountRepository.register({ loginId: 'test@test.com', password: 'password' })
               .success(function (data) {
                   expect(data.success).toBeTruthy();
               });

           $httpBackend.flush();
       }));

    it("should have a login method.", inject(function (accountRepository) {
        expect(accountRepository.login).toBeDefined();
    }));

    it('should post login success',
        inject(function (accountRepository, urlResolver, $httpBackend) {

            $httpBackend.expect('POST', urlResolver.resolveAccount('Login'))
                .respond(200, { success: true });

            accountRepository.login({ loginId: 'test@test.com', password: 'password', rememberMe: true })
                .success(function (data) {
                    expect(data.success).toBeTruthy();
                });

            $httpBackend.flush();
        }));

    it("should have a logout method.", inject(function (accountRepository) {
        expect(accountRepository.logout).toBeDefined();
    }));

    it('should get logout success',
        inject(function (accountRepository, urlResolver, $httpBackend) {

            $httpBackend.expect('GET', urlResolver.resolveAccount('Logout'))
                .respond(200, { success: true });

            accountRepository.logout({ loginId: 'test@test.com', password: 'password' })
                .success(function (data) {
                    expect(data.success).toBeTruthy();
                });

            $httpBackend.flush();
        }));

    it("should have a changePassword method.", inject(function (accountRepository) {
        expect(accountRepository.changePassword).toBeDefined();
    }));

    it('should get password change success',
        inject(function (accountRepository, urlResolver, $httpBackend) {

            $httpBackend.expect('POST', urlResolver.resolveAccount('ChangePassword'))
                .respond(200, { success: true });

            accountRepository.changePassword({ oldPassword: "oldPassword", newPassword: "newPassword" })
                .success(function (data) {
                    expect(data.success).toBeTruthy();
                });

            $httpBackend.flush();
        }));
});