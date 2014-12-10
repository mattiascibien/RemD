using Caliburn.Micro;
using RemD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemD.ViewModels
{
    public class NewConnectionViewModel : Screen
    {
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
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        private IEnumerable<Category> _availableCategories;
        public IEnumerable<Category> AvailableCategories
        {
            get
            {
                return _availableCategories;
            }
            set
            {
                _availableCategories = value;
                NotifyOfPropertyChange(() => AvailableCategories);
            }
        }

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                _selectedCategory = value;
                NotifyOfPropertyChange(() => SelectedCategory);
            }
        }

        public NewConnectionViewModel(IEnumerable<Category> avaialbleCategories)
        {
            DisplayName = "New Connection...";
            AvailableCategories = avaialbleCategories;
            SelectedCategory = AvailableCategories.First();
        }


        public void Add()
        {
            TryClose(true);
        }
    }
}
