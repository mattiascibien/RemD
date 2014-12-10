using Caliburn.Micro;
using RemD.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemD.ViewModels
{
    public class RemoteDesktopViewModel : Screen
    {

        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            Connect();
        }

        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                NotifyOfPropertyChange(() => Address);
                DisplayName = _address;
            }
        }


        public void Connect()
        {
            RemoteDesktopView View = GetView() as RemoteDesktopView;
            View.RDPControl.ActiveX.Server = Address;
            View.RDPControl.ActiveX.Connect();
        }

        protected override void OnDeactivate(bool close)
        {
            if(close)
            {
                RemoteDesktopView View = GetView() as RemoteDesktopView;
            }

            base.OnDeactivate(close);
        }
    }
}
