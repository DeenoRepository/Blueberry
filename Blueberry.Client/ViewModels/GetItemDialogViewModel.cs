using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Blueberry.Client.Models;
using Blueberry.Client.Services;
using Blueberry.Client.Views;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;


namespace Blueberry.Client.ViewModels
{
    public class GetItemDialogViewModel : ReactiveObject, IScreen
    {
        public RoutingState Router { get; }

        public ReactiveCommand<Unit, Unit> TakeStockItem { get; }

        public int IdField { get; set; }
        public int AmountField { get; set; }

        public GetItemDialogViewModel()
        {
            Router = new RoutingState();

            TakeStockItem = ReactiveCommand.Create(() => 
            {
                StockItem stockItem = new BlueberryAPI().GetStockItem(IdField);

                if (stockItem.Amount >= AmountField) 
                {
                    new BlueberryAPI().TakeStockItem(stockItem, AmountField);
                }
            });
        }
    }
}
