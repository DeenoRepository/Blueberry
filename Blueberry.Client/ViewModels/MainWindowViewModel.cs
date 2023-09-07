using Avalonia.Platform;
using Blueberry.Client.Views;
using ReactiveUI;
using Splat;
using System.Reactive;

namespace Blueberry.Client.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        public RoutingState Router { get; }
        public ReactiveCommand<Unit, Unit> LoadInventoryPage { get; }
        public ReactiveCommand<Unit, Unit> LoadDashboardPage { get; }
        public ReactiveCommand<Unit, Unit> LoadReportsPage { get; }


        public MainWindowViewModel()
        {
            Locator.CurrentMutable.Register(() => new InventoryView(), typeof(IViewFor<InventoryViewModel>));
            Locator.CurrentMutable.Register(() => new DashboardView(), typeof(IViewFor<DashboardViewModel>));
            Locator.CurrentMutable.Register(() => new ReportsView(), typeof(IViewFor<ReportsViewModel>));
            

            Router = new RoutingState();
            Router.Navigate.Execute(new InventoryViewModel(this));

            LoadInventoryPage = ReactiveCommand.Create(() => { Router.Navigate.Execute(new InventoryViewModel(this)); });
            LoadDashboardPage = ReactiveCommand.Create(() => { Router.Navigate.Execute(new DashboardViewModel(this)); });
            LoadReportsPage = ReactiveCommand.Create(() => { Router.Navigate.Execute(new ReportsViewModel(this)); });
        }
    }
}