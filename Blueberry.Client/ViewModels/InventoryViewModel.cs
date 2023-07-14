using Blueberry.Client.Models;
using Blueberry.Client.Services;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace Blueberry.Client.ViewModels
{
    public class InventoryViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "InventoryPage";

        public IScreen HostScreen { get; }

        public ReactiveCommand<Unit, Unit> UpdateStockList { get; }
        public ReactiveCommand<Unit, Unit> UpdateTypeList { get; }

        public ObservableCollection<StockItem> StockItems { get; set; }
        public ObservableCollection<ItemCategory> ItemCategories { get; set; }
        public ObservableCollection<ItemType> ItemTypes { get; set; }
        public ItemCategory SelectedCategory { get; set; }
        public ItemType SelectedType { get; set; }

        public string? FilterField { get; set; }

        public InventoryViewModel(IScreen? screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            StockItems = new BlueberryAPI().GetStockItems();
            ItemCategories = new BlueberryAPI().GetCategoryList();
            ItemTypes = new ObservableCollection<ItemType>();

            SelectedCategory = new ItemCategory();
            SelectedType = new ItemType();

            FilterField = String.Empty;

            UpdateStockList = ReactiveCommand.Create(() =>
            {
                StockItems.Clear();

                foreach (StockItem stockItem in new BlueberryAPI().GetStockItems().Where(x => x.Description!.Contains(FilterField, StringComparison.OrdinalIgnoreCase)))
                {
                    StockItems.Add(stockItem);
                }
            });

            UpdateTypeList = ReactiveCommand.Create(() =>
            {
                ItemTypes.Clear();

                if (SelectedCategory != null)
                {
                    foreach (var itemType in new BlueberryAPI().GetTypeList(SelectedCategory.Id))
                    {
                        ItemTypes.Add(itemType);
                    }
                }
            });
        }
    }
}
