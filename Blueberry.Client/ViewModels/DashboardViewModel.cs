using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueberry.Client.ViewModels
{
    public class DashboardViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "DashboardPage";

        public IScreen HostScreen { get; }

        public DashboardViewModel(IScreen? screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        }
    }
}
