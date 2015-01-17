using System;
using System.Collections.Generic;

namespace Data.TokenStorages
{
    public class InMemoryTokenStorage : ITokenStorage
    {
        private static IDictionary<string, string> _store = new Dictionary<string, string>();
        public string CreateToken(string userId)
        {
            var token = Guid.NewGuid().ToString().Replace("-", "");
            _store[token] = userId;
            return token;
        }

        public bool TokenExists(string token)
        {
            return _store.ContainsKey(token);
        }

        public string GetLoginId(string token)
        {
            return _store.ContainsKey(token) ? _store[token] : null;
        }

        public bool DeleteToken(string token)
        {
            if (token != null)
            {
                return _store.Remove(token);                
            }
            return false;
        }
    }
}
