using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data;
using Avalonia.Data.Core;
using Avalonia.Xaml.Interactivity;
using Blueberry.Client.Models;
using Blueberry.Client.Services;
using Blueberry.Client.Views;
using DynamicData;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tmds.DBus;


namespace Blueberry.Client.ViewModels
{
    public class AddItemDialogViewModel : ReactiveObject, IScreen
    {
        private BlueberryAPI _blueberryApi;

        public RoutingState Router { get; }

        public ReactiveCommand<Unit, Unit> AddItem { get; }
        public ReactiveCommand<Unit, Unit> UpdateTypeList { get; }

        public ItemCategory SelectedCategory { get; set; }
        public ItemType SelectedType { get; set; }

        private ObservableCollection<ItemCategory> _itemCategories;
        public ObservableCollection<ItemCategory> ItemCategories
        {
            get => _itemCategories;
            set => this.RaiseAndSetIfChanged(ref _itemCategories, value);
        }

        private ObservableCollection<ItemType> _itemTypes;
        public ObservableCollection<ItemType> ItemTypes
        {
            get => _itemTypes;
            set => this.RaiseAndSetIfChanged(ref _itemTypes, value);
        }

        private string? _partNumberField;
        public string? PartNumberField
        {
            get => _partNumberField;
            set => this.RaiseAndSetIfChanged(ref _partNumberField, value);
        }

        private string? _descriptionField;
        public string? DescriptionField
        {
            get => _descriptionField;
            set => this.RaiseAndSetIfChanged(ref _descriptionField, value);
        }

        private int _amountField;
        public int AmountField
        {
            get => _amountField;
            set => this.RaiseAndSetIfChanged(ref _amountField, value);
        }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set => this.RaiseAndSetIfChanged(ref _errorMessage, value);
        }

        public AddItemDialogViewModel()
        {
            _blueberryApi = new BlueberryAPI();

            ItemCategories = new BlueberryAPI().GetCategoryList();
            ItemTypes = new ObservableCollection<ItemType>();

            PartNumberField = String.Empty;
            DescriptionField = String.Empty;
            AmountField = 0;

            ErrorMessage = String.Empty;

            Router = new RoutingState();

            AddItem = ReactiveCommand.Create(() => 
            {
                if (SelectedCategory != null && SelectedType != null && DescriptionField != String.Empty && AmountField > 0)
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

                        ErrorMessage = String.Empty;
                    }
                }
                else
                {
                    ErrorMessage = "Пожалуйста заполните все поля";
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
