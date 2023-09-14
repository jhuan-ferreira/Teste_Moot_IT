using System;
using System.Collections.Generic;
using System.Net.Http;
using Data.Entity;

namespace API.Command
{
    public class LogradouroApi
    {
        public Logradouro SaveLogradouro(Logradouro logradouro)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44361/api/");

                var postTask = client.PostAsJsonAsync<Logradouro>("Logradouro", logradouro);
                postTask.Wait();

                var result = postTask.Result;

                return logradouro;

            }
        }

        public List<Logradouro> GetLogradouro(int? id, int? clienteId)
        {
            var listaLogradouro = new List<Logradouro>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44361/api/");

                var rootApi = id != null || clienteId != null ? "Logradouro?id=" + id + "&ClienteId=" + clienteId : "Logradouro/Logradouro";

                using (HttpResponseMessage response = client.GetAsync(rootApi).Result)
                {
                    if (response.IsSuccessStatusCode)
                        listaLogradouro = response.Content.ReadAsAsync<List<Logradouro>>().Result;
                }

                return listaLogradouro;
            }
        }

        public bool DeleteLogradoro(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44361/api/");

                var rootApi = "Logradouro?id=" + id;

                using (HttpResponseMessage response = client.DeleteAsync(rootApi).Result)
                {
                    if (response.IsSuccessStatusCode)
                        return true;
                    else
                        return false;
                }

            }
        }
    }
}