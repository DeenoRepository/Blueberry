using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Blueberry.Client.ViewModels;

namespace Blueberry.Client.Views
{
    public partial class StartupView : ReactiveUserControl<StartupViewModel>
    {
        public StartupView()
        {
            InitializeComponent();
        }
    }
}
