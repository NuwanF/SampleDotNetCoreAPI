using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SCMM_Application.Test
{
    public class UserTest
    {
        [Fact]
        public async Task GetDeveloperByTechnology()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("user/GetUserType");
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
