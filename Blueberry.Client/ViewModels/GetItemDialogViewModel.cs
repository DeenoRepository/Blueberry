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
        private BlueberryAPI _blueberryApi;

        public RoutingState Router { get; }

        public ReactiveCommand<Unit, Unit> TakeStockItem { get; }

        private int _idField;
        public int IdField
        {
            get => _idField;
            set => this.RaiseAndSetIfChanged(ref _idField, value);
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

        public GetItemDialogViewModel()
        {
            _blueberryApi = new BlueberryAPI();

            Router = new RoutingState();

            TakeStockItem = ReactiveCommand.Create(() => 
            {
                StockItem stockItem = new BlueberryAPI().GetStockItem(IdField);

                if (IdField != 0 && AmountField != 0) 
                {
                    if (_blueberryApi.TakeStockItem(stockItem, AmountField))
                    {
                        IdField = 0;
                        AmountField = 0;

                        ErrorMessage = String.Empty;
                    }
                }
                else 
                {
                    ErrorMessage = "Пожалуйста заполните все поля";
                }
            });
        }
    }
}
