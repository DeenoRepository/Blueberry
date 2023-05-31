using Avalonia.Controls;
using Avalonia.Controls.Mixins;
using Avalonia.ReactiveUI;
using Blueberry.Client.ViewModels;
using ReactiveUI;

namespace Blueberry.Client.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainWindowViewModel();

            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.Router, x => x.RoutedViewHost.Router)
                    .DisposeWith(disposables);
            });
        }
    }
}