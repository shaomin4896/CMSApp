using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagementAPI.Models;
using System.Net.Http.Json;

namespace CaseManagementApp.Service
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly LoginState _loginState;

        public AuthService(HttpClient httpClient, LoginState loginState)
        {
            _httpClient = httpClient;
            _loginState = loginState;
        }

        public async Task<string?> GetToken(string account, string password)
        {
            var res = await _httpClient.PostAsync($"/api/User/login?account={account}&password={password}", null);
            var token = await res.Content.ReadAsStringAsync();
            return token;
        }

        public async Task<CmsUser> GetCurrentUser()
        {
            var res = await _httpClient.GetFromJsonAsync<CmsUser>("/api/User/current");
            return res;
        }

        public async Task<CmsUser?> GetUserByName(string name)
        {
            return await _httpClient.GetFromJsonAsync<CmsUser?>("/api/User/get/" + name);
        }

        public void InitLoginState(CmsUser cmsUser)
        {
            _loginState.IsLogin = true;
            _loginState.User = cmsUser;
        }

        public void LogOut()
        {

        }
    }
}