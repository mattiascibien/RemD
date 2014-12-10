using Caliburn.Micro;
using RemD.Interfaces;
using RemD.Models;
using System.Linq;
using System.Collections.Generic;
using Xceed.Wpf.AvalonDock;

namespace RemD.ViewModels
{
    public class ShellViewModel : Conductor<RemoteDesktopViewModel>.Collection.OneActive, IShell
    {
        public List<Screen> Anchorables
        {
            get;
            set;
        }

        public ShellViewModel()
        {
            DisplayName = "RemD - A Decent Remote Desktop Client";
            Anchorables = new List<Screen>();
            Anchorables.Add(new ConnectionsViewModel());
        }


        public void OpenNew()
        {
            ConnectViewModel connectVM = new ConnectViewModel();

            bool result = IoC.Get<IWindowManager>().ShowDialog(connectVM).Value;

            if (result)
            {
                RemoteDesktopViewModel newItem = new RemoteDesktopViewModel();
                Items.Add(newItem);
                newItem.Address = connectVM.Address;
                ActivateItem(newItem);
            }
        }

        public void AddNew()
        {
            var categories = (Anchorables.First(a => a.GetType() == typeof(ConnectionsViewModel)) as ConnectionsViewModel).Connections.RootCategories;
            NewConnectionViewModel newConnVM = new NewConnectionViewModel(categories);

            bool result = IoC.Get<IWindowManager>().ShowDialog(newConnVM).Value;

            if (result)
            {
                Connection connection = new Connection();
                connection.Address = newConnVM.Address;
                connection.Name = newConnVM.Name;
                newConnVM.SelectedCategory.Connections.Add(connection);
            }
        }

        //Helper method for closing the active document
        public void Close(RemoteDesktopViewModel tab, DocumentClosingEventArgs e)
        {
            bool? result = false;
            tab.TryClose(result);
            e.Cancel = !result.Value;
        }

        protected override void OnDeactivate(bool close)
        {
            if(close)
            {
                (Anchorables.First(a => a.GetType() == typeof(ConnectionsViewModel)) as ConnectionsViewModel).Save();
            }
            base.OnDeactivate(close);
        }

    }
}