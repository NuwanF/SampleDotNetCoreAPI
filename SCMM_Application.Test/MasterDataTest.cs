using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SCMM_Application.Test
{
    public class MasterDataTest
    {
        [Fact]
        public async Task GetUserRoles()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("masterdata/GetAllUserRoles");
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task GetStrokes()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("masterdata/GetAllStrokes");
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
