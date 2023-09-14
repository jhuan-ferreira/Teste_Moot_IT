using System;
using System.Collections.Generic;
using System.Net.Http;
using Data.Entity;

namespace API.Command
{
    public class ClienteApi
    {
        public Cliente SaveCliente(Cliente cliente)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44361/api/Cliente");

                var postTask = client.PostAsJsonAsync<Cliente>("Cliente", cliente);
                postTask.Wait();

                var result = postTask.Result;

                return cliente;
            }
        }

        public List<Cliente> GetCliente(int? id)
        {
            var listaCliente = new List<Cliente>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44361/api/");

                var rootApi = id != null ? "Cliente?id=" + id : "Cliente/Cliente";

                using (HttpResponseMessage response = client.GetAsync(rootApi).Result)
                {
                    if (response.IsSuccessStatusCode)
                        listaCliente = response.Content.ReadAsAsync<List<Cliente>>().Result;
                }

                return listaCliente;
            }
        }

        public bool DeleteCliente(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44361/api/");

                var rootApi =  "Cliente?id=" + id;

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