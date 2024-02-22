using Newtonsoft.Json;
using Roticeria.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roticeria.Repositories
{
    
    internal class RepositoryComida
    {
        string urlApi = "https://documentalesmaui-2ada.restdb.io/rest/comida"; HttpClient client = new HttpClient();

        public RepositoryComida()
        {
            //configuramos que trabajará con respuestas JSON
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("apikey", "2f05d2abd381ccac09e078089ff3354d06ee9");
        }
        public async Task<ObservableCollection<Comida>> GetAllAsync()
        {
            try
            {

                var response = await client.GetStringAsync(urlApi);
                return
                    JsonConvert.DeserializeObject<ObservableCollection<Comida>>(response);
            }
            catch (Exception error)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Hubo un error" + error.Message, "OK");
                return null;
            }
        }
            public async Task<bool> RemoveAsync(string id)
            {
                var response = await client.DeleteAsync($"{urlApi}/{id}");
                return response.IsSuccessStatusCode;
            }

            public async Task<bool> AddAsync(Comida comida)
            {
                var resonse = await client.PostAsync(urlApi,
                    new StringContent(JsonConvert.SerializeObject(comida), Encoding.UTF8, "application/json"));
                return resonse.IsSuccessStatusCode;
            }

            public async Task<bool> UpdateAsync(Comida comida)
            {
                var resonse = await client.PutAsync($"{urlApi}/{comida._id}",
                    new StringContent(JsonConvert.SerializeObject(comida), Encoding.UTF8, "application/json"));
                return resonse.IsSuccessStatusCode;
            }

        
    }
}