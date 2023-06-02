using Blueberry.Client.Views;
using ReactiveUI;
using Splat;

namespace Blueberry.Client.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        public RoutingState Router { get; }

        public MainWindowViewModel()
        {
            Locator.CurrentMutable.Register(() => new StartupView(), typeof(IViewFor<StartupViewModel>));
            Locator.CurrentMutable.Register(() => new StorageView(), typeof(IViewFor<StorageViewModel>));

            Router = new RoutingState();
            Router.Navigate.Execute(new StorageViewModel(this));
        }
    }
}