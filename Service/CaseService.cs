using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagementAPI.Models;
using System.Net.Http.Json;

namespace CaseManagementApp.Service
{
    public class CaseService
    {
        private readonly HttpClient _httpClient;

        public CaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> NewCase(CmsCase @case)
        {
            @case.Patient = new CmsUser
            {
                Name = @case.PatientName,
                Account = @case.PatientName,
                Password = "1234",
                RoleType = RoleType.User
            };
            var res = await _httpClient.PostAsJsonAsync<CmsCase>("/Case/new", @case);
            return await res.Content.ReadFromJsonAsync<int>();
        }
    }
}