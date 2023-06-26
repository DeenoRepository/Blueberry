using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Blueberry.Client.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace Blueberry.Client.Views
{
    public partial class StorageView : ReactiveUserControl<StorageViewModel>
    {
        public StorageView()
        {
            InitializeComponent();
        }
    }
}
