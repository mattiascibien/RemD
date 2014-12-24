using Caliburn.Micro;
using Newtonsoft.Json;
using RemD.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RemD.ViewModels
{
    public class ConnectionsViewModel : Screen
    {
        public ConnectionsModel Connections
        {
            get;
            set;
        }

        public ConnectionsViewModel()
        {
            DisplayName = "Connections";
            Connections = new ConnectionsModel();
            Load();
        }

        private Common _selectedItem;
        public Common SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if(_selectedItem != value)
                {
                    _selectedItem = value;
                    NotifyOfPropertyChange(() => SelectedItem);
                }
            }
        }

        public void Load()
        {
            string fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "connections.json");

            if(File.Exists(fileName))
            {
                Connections.RootCategories = JsonConvert.DeserializeObject<ObservableCollection<Category>>(File.ReadAllText(fileName));
            }
        }

        public void Save()
        {
            string fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "connections.json");
            File.WriteAllText(fileName, JsonConvert.SerializeObject(Connections.RootCategories));    
        }

        public void Open(Connection conn)
        {
            IoC.Get<ShellViewModel>().Open(conn);
        }


        public void AddNewConnection()
        {
            NewConnectionViewModel newConnVM = new NewConnectionViewModel(Connections.RootCategories);

            bool result = IoC.Get<IWindowManager>().ShowDialog(newConnVM).Value;

            if (result)
            {
                Connection connection = new Connection();
                connection.Address = newConnVM.Address;
                connection.Name = newConnVM.Name;
                newConnVM.SelectedCategory.Connections.Add(connection);
            }
        }

        public void AddNewCategory()
        {
            
        }


        public void RemoveSelected()
        {
            if(SelectedItem is Category)
            {
                if ((SelectedItem as Category).Name == "Uncategorized")
                {
                    MessageBox.Show("Cannot delete default category", "RemD - Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want do delete the category and all its connections?", "RemD", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        (SelectedItem as Category).Connections.Clear();
                        Connections.RootCategories.Remove(SelectedItem as Category);
                    }
                }
            }
            else //SelectedItem is Connection
            {
                foreach (var cat  in Connections.RootCategories)
                {
                    if(cat.Connections.Contains(SelectedItem as Connection))
                    {
                        cat.Connections.Remove(SelectedItem as Connection);
                    }
                }
            }
        }
    }
}
