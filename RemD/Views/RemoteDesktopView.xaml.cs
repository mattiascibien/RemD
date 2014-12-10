using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RemD.Views
{
    /// <summary>
    /// Interaction logic for RemoteDesktopView.xaml
    /// </summary>
    public partial class RemoteDesktopView : UserControl
    {
        public Interop.RDPControl RDPControl
        {
            get;
            private set;
        }

        public RemoteDesktopView()
        {
            InitializeComponent();
            RDPControl = new Interop.RDPControl();
            formsHost.Child = RDPControl;
        }
    }
}
