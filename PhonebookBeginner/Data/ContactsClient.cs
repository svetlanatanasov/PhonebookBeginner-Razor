using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhonebookBeginner.Data
{
    public static class ContactsClient
    {
        

        public static async Task<T> SendAsync<T>(string baseUrl, string relativeUrl, string query)
        {

            using (var http = new HttpClient())
            {
                //var builder = new UriBuilder(baseUrl)
                //{
                //    Path = relativeUrl,
                //    Query = query
                //};
                var response = await http.GetAsync(baseUrl);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var error = JsonConvert.DeserializeObject<DataError>(content);
                    throw new Exception(error.Message);
                }

                JObject jObject = JObject.Parse(content);
                var rootIgnored = jObject.SelectToken(relativeUrl).ToString();


                var result = JsonConvert.DeserializeObject<T>(rootIgnored);

                return result;
            }
        }
    }
}
