using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Platform;
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
using System.Threading;
using System.Threading.Tasks;

namespace Blueberry.Client.ViewModels
{
    public class StorageManagerViewModel : ReactiveObject, IRoutableViewModel
    {
        private BlueberryAPI _api;

        public string UrlPathSegment => "StorageManagerPage";

        public IScreen HostScreen { get; }

        public StockItem StockItem { get; set; }
        public ItemCategory ItemCategory { get; set; }
        public ItemType ItemType { get; set; }
        public ObservableCollection<ItemCategory> ItemCategoryList { get; }
        public ObservableCollection<ItemType> ItemTypeList { get; set; }
        public ReactiveCommand<Unit, Unit> AddStockItem { get; }
        public ReactiveCommand<Unit, Unit> UpdateItemTypeList { get; }

        public StorageManagerViewModel(IScreen? screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            _api = new BlueberryAPI();

            StockItem = new StockItem();
            ItemCategory = new ItemCategory();
            ItemType = new ItemType();

            ItemCategoryList = _api!.GetCategoryList();
            ItemTypeList = new ObservableCollection<ItemType>();


            AddStockItem = ReactiveCommand.Create(() => 
            {
                _api.AddStockItem(new StockItem()
                {
                    Category = ItemCategory.Name,
                    Type = ItemType.Name,
                    Description = StockItem.Description,
                    Amount = StockItem.Amount,
                }); 
            });

            UpdateItemTypeList = ReactiveCommand.Create(() =>
            {
                ItemTypeList.Clear();

                foreach (ItemType itemType in _api!.GetTypeList(ItemCategory.Id))
                {
                    ItemTypeList.Add(itemType);
                }
            });
        }
    }
}
