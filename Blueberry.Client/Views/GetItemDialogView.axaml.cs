using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Blueberry.Client.ViewModels;

namespace Blueberry.Client.Views
{
    public partial class GetItemDialogView : ReactiveWindow<GetItemDialogViewModel>
    {
        public GetItemDialogView()
        {
            InitializeComponent();

            ViewModel = new GetItemDialogViewModel();
        }
    }
}
