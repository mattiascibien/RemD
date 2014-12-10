using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemD.ViewModels
{
    public class ConnectViewModel : Screen
    {
        public string Address
        {
            get;
            set;
        }

        public ConnectViewModel()
        {
            DisplayName = "Connect...";
        }

        public void Connect()
        {
            TryClose(true);
        }
    }
}
