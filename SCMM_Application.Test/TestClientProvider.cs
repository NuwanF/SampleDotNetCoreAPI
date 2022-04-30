using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SCMM_Application.DataAccess;
using Microsoft.AspNetCore.TestHost;

namespace SCMM_Application.Test
{
    public class TestClientProvider
    {
        public HttpClient Client { get; private set; }

        public TestClientProvider()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.test.json")
            .Build();

            WebHostBuilder webHostBuilder = new WebHostBuilder();
            webHostBuilder.ConfigureServices(s =>
                s.AddDbContext<SwimClubDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DBConnection"))));
            webHostBuilder.UseStartup<Startup>();

            var server = new TestServer(webHostBuilder);

            Client = server.CreateClient();
        }
    }
}
