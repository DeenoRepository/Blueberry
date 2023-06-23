using Blueberry.Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blueberry.Client.Services
{
    public class Database
    {
        private HttpClient _client;

        public Database() 
        {
            _client = new HttpClient();
        }

        public ObservableCollection<StockItem> GetStockItems() 
        {
            HttpResponseMessage response = _client.GetAsync("http://localhost:5000/api/StockItems").Result;

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;

                var result = JsonSerializer.Deserialize<ObservableCollection<StockItem>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});

                if (result != null )
                {
                    return result;
                }
            }

            return new ObservableCollection<StockItem>(); ;
        }
        
    }
}
