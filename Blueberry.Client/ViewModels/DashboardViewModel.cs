using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
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
    public class DashboardViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "DashboardPage";

        public IScreen HostScreen { get; }

        public ReactiveCommand<Unit, Unit> OpenAddItemDialog { get; }
        public ReactiveCommand<Unit, Unit> OpenGetItemDialog { get; }

        public DashboardViewModel(IScreen? screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                OpenAddItemDialog = ReactiveCommand.Create(() => { new AddItemDialogView().ShowDialog(desktop.MainWindow); });
                OpenGetItemDialog = ReactiveCommand.Create(() => { new GetItemDialogView().ShowDialog(desktop.MainWindow); });
            }
        }
    }
}
