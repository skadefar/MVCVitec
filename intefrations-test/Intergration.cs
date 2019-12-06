using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ikvm.runtime;
using Microsoft.AspNetCore.Mvc.Testing;

namespace intefrations_test
{
    class Intergration
    {
        protected readonly HttpClient TestClient;
        protected Intergration()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            TestClient = appFactory.CreateClient();
        }

        protected async Task AuthenticateAsync()
        {
          //  TestClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("thing", GetJwtAsyn());
        }

        protected async Task GetJwtAsyn()
        {
            throw new NotImplementedException();
        }
    }
}
