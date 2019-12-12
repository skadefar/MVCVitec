using System;
using System.Data.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ikvm.runtime;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
 

namespace intefrations_test
{
    class Intergration
    {
     /*   protected readonly HttpClient TestClient;
        protected Intergration()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                { builder.ConfigureServices(services =>

                 {
                     services.RemoveAll(typeof(DataContext));
                     services.AddDbContext<DbContext>(optionsAction => options 
                        
                     });
                });
            TestClient = appFactory.CreateClient();
        }

        protected async Task AuthenticateAsync()
        {
           // TestClient.DefaultRequestHeaders.Authorization =new AuthenticationHeaderValue("thing", await GetJwtAsyn());
        }

      /*  private async Task<string> GetJwtAsyn()
        {
        }*/ 
    }
}
