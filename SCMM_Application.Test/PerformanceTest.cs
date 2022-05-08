using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SCMM_Application.Test
{
    public class PerformanceTest
    {
        [Fact]
        public async Task GetPerformance()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("performance/GetAllPerformance");
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
