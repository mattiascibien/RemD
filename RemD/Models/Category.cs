using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RemD.Models
{
    public class Category : Common
    {
        public ObservableCollection<Connection> Connections
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
