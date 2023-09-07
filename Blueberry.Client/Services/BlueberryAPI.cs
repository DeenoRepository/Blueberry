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
    public class BlueberryAPI
    {
        private HttpClient _client;

        private string _host;

        public BlueberryAPI() 
        {
            _client = new HttpClient();

            _host = "http://localhost:5000/api/";
        }

        public ObservableCollection<StockItem> GetStockItems() 
        {
            HttpResponseMessage response = _client.GetAsync(_host + "StockItems").Result;

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

        public bool AddStockItem(StockItem stockItem)
        {
            HttpResponseMessage response =  _client.PostAsync(_host + "StockItems", new StringContent(JsonSerializer.Serialize<StockItem>(stockItem), Encoding.UTF8, "application/json")).Result;

            if (response.IsSuccessStatusCode) 
            {
                return true;
            }

            return false;
        } 

        public StockItem GetStockItem(int id)
        {
            HttpResponseMessage response = _client.GetAsync(_host + "StockItems/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;

                return JsonSerializer.Deserialize<StockItem>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }

            return new StockItem();
        }

        public bool TakeStockItem(StockItem stockItem, int amount) 
        {
            HttpResponseMessage response = _client.PutAsync(_host + "StockItems/" + stockItem.Id, new StringContent(JsonSerializer.Serialize<StockItem>(stockItem), Encoding.UTF8, "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public ObservableCollection<ItemCategory> GetCategoryList()
        {
            ObservableCollection<ItemCategory> itemCategotyList = new ObservableCollection<ItemCategory>()
            {
                new ItemCategory {
                    Id = 0,
                    Name = "Радиодетали"
                },
                new ItemCategory {
                    Id = 1,
                    Name = "Инструменты"
                },
                new ItemCategory {
                    Id = 2,
                    Name = "Устройства"
                }
            };

            return itemCategotyList;
        }

        public ObservableCollection<ItemType> GetTypeList(int category)
        {
            ObservableCollection<ItemType> itemCategotyList = new ObservableCollection<ItemType>()
            {
                new ItemType
                {
                    Id = 0,
                    Name = "Резистор",
                    Category = 0
                },
                new ItemType
                {
                    Id = 1,
                    Name = "Конденсатор",
                    Category = 0
                },
                new ItemType
                {
                    Id = 2,
                    Name = "Диод",
                    Category = 0
                },
                new ItemType
                {
                    Id = 3,
                    Name = "Бокорезы",
                    Category = 1
                },
                new ItemType
                {
                    Id = 4,
                    Name = "ПЛК",
                    Category = 2
                },
            };

            var a = new ObservableCollection<ItemType>(itemCategotyList.Where(x => x.Category == category));

            return a;
        }
    }
}
