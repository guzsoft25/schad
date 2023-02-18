using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Ecommerce.Shared.Utilities
{
    public static class HttpUtilities
    {
        public static TResponse Post<TRequest, TResponse>(string url, TRequest request, ref string errorMessage)
        {
            TResponse objectResponse = default;

            using (var client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(request);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, data).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;
                    objectResponse = JsonConvert.DeserializeObject<TResponse>(jsonResponse);
                }
                else
                {
                    errorMessage = response.ReasonPhrase;
                }


                return objectResponse;
            }

        }

        public static TResponse Put<TRequest, TResponse>(string url, TRequest request, ref string errorMessage)
        {
            TResponse objectResponse = default;

            using (var client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(request);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PutAsync(url, data).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;
                    objectResponse = JsonConvert.DeserializeObject<TResponse>(jsonResponse);
                }
                else
                {
                    errorMessage = response.ReasonPhrase;
                }


                return objectResponse;
            }
        }

        public static TResponse Delete<TResponse>(string url, ref string errorMessage)
        {
            TResponse objectResponse = default;

            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, url);
                var response = httpClient.Send(request);

                if (response.IsSuccessStatusCode) {
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;
                    objectResponse = JsonConvert.DeserializeObject<TResponse>(jsonResponse);

                }
                else {
                    errorMessage = response.ReasonPhrase;
                }
               
            }

            return objectResponse;
        }

    }
}


//var readTask = result.Content.ReadAsAsync<Student[]>();
//readTask.Wait();

//var students = readTask.Result;

//foreach (var student in students)
//{
//    Console.WriteLine(student.Name);
//}