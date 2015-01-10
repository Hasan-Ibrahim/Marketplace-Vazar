using System;
using System.Security.Cryptography;
using System.Text;
using Data.Repositories;

namespace Service.Account
{
    public class AccountService
    {
        private readonly UserRepository _userRepository;

        public AccountService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ValidateUser(string loginId, string password)
        {
            var passwordHash = GenerateHash(password);

            var user = _userRepository.FindByLoginId(loginId);

            return user != null && user.HashedPassword != null && user.HashedPassword == passwordHash;
        }

        public string GenerateHash(string plainText)
        {
            var encoded = new UTF8Encoding().GetBytes(plainText);
            var hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encoded);
            var hashString = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
            return hashString;
        }
    }
}
