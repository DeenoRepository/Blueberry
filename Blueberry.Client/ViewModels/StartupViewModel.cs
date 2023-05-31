using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueberry.Client.ViewModels
{
    public class StartupViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "StartupPage";

        public IScreen HostScreen { get; }

        public StartupViewModel(IScreen? screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        }
    }
}
