using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Blueberry.Client.ViewModels;
using ReactiveUI;

namespace Blueberry.Client.Views
{
    public partial class AddItemDialogView : ReactiveWindow<AddItemDialogViewModel>
    {
        public AddItemDialogView()
        {
            InitializeComponent();

            ViewModel = new AddItemDialogViewModel();
        }
    }


}
