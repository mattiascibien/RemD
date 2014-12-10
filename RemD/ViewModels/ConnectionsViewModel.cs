using Caliburn.Micro;
using Newtonsoft.Json;
using RemD.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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


        public void Load()
        {
            string fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "connections.json");

            if(File.Exists(fileName))
            {
                Connections.RootCategories.Clear();
                Connections = JsonConvert.DeserializeObject<ConnectionsModel>(File.ReadAllText(fileName));
            }
        }

        public void Save()
        {
            string fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "connections.json");
            File.WriteAllText(fileName, JsonConvert.SerializeObject(Connections));
            
        }
    }
}
