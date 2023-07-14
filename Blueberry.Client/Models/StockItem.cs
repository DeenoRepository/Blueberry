using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueberry.Client.Models
{
    public class StockItem
    {
        public int Id { get; set; }
        public string? Category { get; set; }
        public string? Type { get; set; }
        public string? PartName { get; set; }
        public string? Description { get; set; }
        public int Amount { get; set; }
    }
}
