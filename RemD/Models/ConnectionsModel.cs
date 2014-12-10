using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemD.Models
{
    public class ConnectionsModel
    {
        public Category Uncategorized
        {
            get;
            set;
        }

        public ObservableCollection<Category> RootCategories
        {
            get;
            set;
        }

        public ConnectionsModel()
        {
            RootCategories = new ObservableCollection<Category>();
            Uncategorized = new Category();
            Uncategorized.Name = "Uncategorized";

            RootCategories.Add(Uncategorized);
        }
    }
}
