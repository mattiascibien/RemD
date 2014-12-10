using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RemD.Models
{
    public class Category
    {
        public ObservableCollection<Connection> Connections
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Category()
        {
            Connections = new ObservableCollection<Connection>();
        }
    }
}
