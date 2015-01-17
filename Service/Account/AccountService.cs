using System;
using System.Security.Cryptography;
using System.Text;
using Data.Model;
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

        public bool ValidateUser(Login login)
        {
            var passwordHash = GenerateHash(login.Password);

            var user = _userRepository.FindByLoginId(login.LoginId).Result;

            return user != null && user.HashedPassword != null && user.HashedPassword == passwordHash;
        }

        public string GenerateHash(string plainText)
        {
            var encoded = new UTF8Encoding().GetBytes(plainText);
            var hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encoded);
            var hashString = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
            return hashString;
        }

        public bool CreateUser(string email, string password)
        {
            if (_userRepository.Exists(user => user.LoginId == email))
            {
                return false;
            }

            var passwordHash = GenerateHash(password);
            _userRepository.Create(new DbUser(email, passwordHash));
            return true;
        }

        public bool UpdateProfile(string loginId, ProfileUpdate update)
        {
            var profile = _userRepository.FindByLoginId(loginId).Result;

            if (!string.IsNullOrWhiteSpace(update.OldPassword))
            {
                var currentPasswordHash = GenerateHash(update.OldPassword);
                if (currentPasswordHash != profile.HashedPassword)
                {
                    return false;
                }

                profile.HashedPassword = GenerateHash(update.NewPassword);
            }

            profile.FullName = update.FullName;

            _userRepository.Update(profile);

            return true;
        }
    }
}
