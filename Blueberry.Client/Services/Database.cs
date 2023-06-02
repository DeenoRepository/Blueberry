using Blueberry.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueberry.Client.Services
{
    public class Database
    {
        public IEnumerable<StockItem> GetStockItems() => new[]
        {
            new StockItem
            {
                Id = 1,
                Category = "Радиодетали",
                Type = "Конденсатор",
                Description = "Электролитический, 16В, 20мФ",
                Amount = 10
            },
            new StockItem
            {
                Id = 2,
                Category = "Радиодетали",
                Type = "Резистор",
                Description = "Проволочный, 10кОм, 1Вт",
                Amount = 10
            },
            new StockItem
            {
                Id = 3,
                Category = "Радиодетали",
                Type = "Диод",
                Description = "Шоттки, 1N4148",
                Amount = 10
            },
        };
    }
}
