using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace webApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class covidApi : ControllerBase
    {



        public class MyCustomResponse
        {
            [JsonProperty(PropertyName = "data")]
            public object Data { get; set; }

            [JsonProperty(PropertyName = "message")]
            public string Message { get; set; }

            [JsonProperty(PropertyName = "result")]
            public string Result { get; set; }
        }

        public class Global
        {


            public Int32 NewConfirmed { get; set; }
            public Int32 TotalConfirmed { get; set; }
            public Int32 NewDeaths { get; set; }
            public Int32 TotalDeaths { get; set; }
            public Int32 NewRecovered { get; set; }
            public Int32 TotalRecovered { get; set; }


        }

        public class Countries
        {


            public String Country { get; set; }
            public String CountryCode { get; set; }
            public String Slug { get; set; }
            public Int32 NewConfirmed { get; set; }
            public Int32 TotalConfirmed { get; set; }
            public Int32 NewDeaths { get; set; }

            public Int32 TotalDeaths { get; set; }
            public Int32 TotalRecovered { get; set; }
            


        }

        


        //private HttpClient client = new HttpClient();

        //private readonly IHttpClientFactory _clientFactory;
        HttpClient client = new HttpClient();


        [HttpGet("getList")]
        public async Task<ActionResult> CovidList()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync("https://api.covid19api.com/summary");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            dynamic json = JsonConvert.SerializeObject(content);

            return Ok(new JsonResult(json));



        }



    }
}
