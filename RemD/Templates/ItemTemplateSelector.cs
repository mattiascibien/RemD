using RemD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RemD.Templates
{
    public class ItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CategoryTemplate { get; set; }
        public DataTemplate ConnectionTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Category folder = item as Category;
            if (folder != null)
            {
                return CategoryTemplate;
            }

            Connection file = item as Connection;
            if (file != null)
            {
                return ConnectionTemplate;
            }

            return null;
        }
    }
}
