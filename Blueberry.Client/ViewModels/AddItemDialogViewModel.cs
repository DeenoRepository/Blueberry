using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Blueberry.Client.Models;
using Blueberry.Client.Services;
using Blueberry.Client.Views;
using DynamicData;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;


namespace Blueberry.Client.ViewModels
{
    public class AddItemDialogViewModel : ReactiveObject, IScreen
    {
        private BlueberryAPI _blueberryApi;

        public RoutingState Router { get; }

        public ReactiveCommand<Unit, Unit> AddItem { get; }
        public ReactiveCommand<Unit, Unit> UpdateTypeList { get; }

        public ObservableCollection<ItemCategory> ItemCategories { get; set; }
        public ObservableCollection<ItemType> ItemTypes { get; set; }
        public ItemCategory SelectedCategory { get; set; }
        public ItemType SelectedType { get; set; }
        public string? PartNumberField { get; set; }
        public string? DescriptionField { get; set; }
        public int AmountField { get; set; }

        public AddItemDialogViewModel()
        {
            _blueberryApi = new BlueberryAPI();

            ItemCategories = new BlueberryAPI().GetCategoryList();
            ItemTypes = new ObservableCollection<ItemType>();

            PartNumberField = String.Empty;
            DescriptionField = String.Empty;
            AmountField = 0;

            Router = new RoutingState();

            AddItem = ReactiveCommand.Create(() => 
            {
                if (SelectedCategory != null && SelectedType != null && DescriptionField != String.Empty)
                {
                    StockItem stockItem = new StockItem
                    {
                        Category = SelectedCategory.Name,
                        Type = SelectedType.Name,
                        PartName = PartNumberField,
                        Description = DescriptionField,
                        Amount = AmountField
                    };

                    if (_blueberryApi.AddStockItem(stockItem))
                    {
                        ItemCategories.Clear();
                        ItemTypes.Clear();
                        PartNumberField = "";
                        DescriptionField = "";
                        AmountField = 0;
                    }
                }
                else
                {

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
