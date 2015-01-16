﻿using System;
using System.Collections.Generic;

namespace Data.TokenStorages
{
    public class InMemoryTokenStorage : ITokenStorage
    {
        private static IDictionary<string, string> _store = new Dictionary<string, string>();
        public string CreateToken(string userId)
        {
            var token = Guid.NewGuid().ToString().Replace("-", "");
            return _store[token] = userId;
        }

        public bool TokenExists(string token)
        {
            return _store.ContainsKey(token);
        }

        public string GetLoginId(string token)
        {
            return _store.ContainsKey(token) ? _store[token] : null;
        }

        public void DeleteToken(string loginId)
        {
            if (loginId != null)
            {
                _store.Remove(loginId);                
            }
        }
    }
}
