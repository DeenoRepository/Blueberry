using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueberry.Client.ViewModels
{
    public class ReportsViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "ReportsPage";

        public IScreen HostScreen { get; }

        public ReportsViewModel(IScreen? screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        }
    }
}
