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
            var cat = new Category();
            cat.Name = "Uncategorized";

            RootCategories.Add(cat);
            Uncategorized = cat;
        }
    }
}
