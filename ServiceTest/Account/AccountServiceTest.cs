using Data.Model;
using Data.Repositories;
using Data.Repositories.Abstraction;
using NUnit.Framework;
using Service.Account;

namespace ServiceTest.Account
{
    [TestFixture]
    public class AccountServiceTest
    {
        private AccountService _accountService;
        [SetUp]
        public void SetUp()
        {
            _accountService = new AccountService(new UserRepository(new InMemoryRepository<DbUser>()));
        }

        [Test]
        public void ValidateUser_Valid_ReturnsTrue()
        {
            var isValid = _accountService.ValidateUser(new Login{LoginId = "LoginId1", Password = "123"});
            Assert.IsTrue(isValid);
        }

        [Test]
        public void ValidateUser_WrongPassword_ReturnsFalse()
        {
            var isValid = _accountService.ValidateUser(new Login { LoginId = "LoginId1", Password = "wrong password" });
            Assert.IsFalse(isValid);
        }

        [Test]
        public void ValidateUser_UserDoesNotExist_ReturnsFalse()
        {
            var isValid = _accountService.ValidateUser(new Login { LoginId = "No such user", Password = "1234" });
            Assert.IsFalse(isValid);
        }

        [Test]
        public void ValidateUser_LoginIdNull_ReturnsFalse()
        {
            var isValid = _accountService.ValidateUser(new Login { LoginId = null, Password = "1234" });
            Assert.IsFalse(isValid);
        }

        [Test]
        public void ValidateUser_PasswordNull_ReturnsFalse()
        {
            var isValid = _accountService.ValidateUser(new Login { LoginId = "LoginId1", Password = null });
            Assert.IsFalse(isValid);
        }

        [Test]
        public void ValidateUser_ModelNull_ReturnsFalse()
        {
            var isValid = _accountService.ValidateUser(null);
            Assert.IsFalse(isValid);
        }

        [Test]
        public void GenerateHash_KnownHashes()
        {
            var h123 = _accountService.GenerateHash("123");
            Assert.AreEqual("202cb962ac59075b964b07152d234b70", h123);
        }
    }
}
