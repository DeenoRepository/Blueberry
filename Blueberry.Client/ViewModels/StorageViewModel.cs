using Avalonia.Collections;
using Blueberry.Client.Models;
using Blueberry.Client.Services;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blueberry.Client.ViewModels
{
    public class StorageViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "StoragePage";

        public IScreen HostScreen { get; }

        public ReactiveCommand<Unit, Unit> OnFilteringRequired { get; }

        public ObservableCollection<StockItem> StockItems { get; set; }

        public string? FilterField { get; set; }

        public StorageViewModel(IScreen? screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            StockItems = new ObservableCollection<StockItem>(new Database().GetStockItems());
            FilterField = String.Empty;

            OnFilteringRequired = ReactiveCommand.Create(() => 
            {
                StockItems.Clear();

                foreach (StockItem stockItem in new Database().GetStockItems().Where(x => x.Type.Contains(FilterField, StringComparison.OrdinalIgnoreCase) ||
                                                                                          x.Description.Contains(FilterField, StringComparison.OrdinalIgnoreCase)))
                {
                    StockItems.Add(stockItem);
                }
            });
        }
    }
}
