using RemD.Interop;
using RemD.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace RemD.Behaviours
{
    public class CommandOnDisconnectBehavior : Behavior<WindowsFormsHost>
    {
        private RDPControl RDPControl;

        protected override void OnAttached()
        {
            base.OnAttached();

            RDPControl = (AssociatedObject.Child as RDPControl);

            RDPControl.ActiveX.OnDisconnected += OnDisconnected;
        }

        void OnDisconnected(object sender, AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEvent e)
        {
            
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            RDPControl.ActiveX.OnDisconnected -= OnDisconnected;
        }
    }
}
