using System.Collections.Generic;
using Auggie_IT_Support_Portal.Models;

namespace Auggie_IT_Support_Portal.ViewModels
{
    public class ConnectivityViewModel
    {
        public List<Connectivity> NetworkPage { get; set; }
        public List<AdvConnectity> MoreWifi { get; set; }
        public List<AdvSubStep> Subwifi { get; set; }
    }
}
