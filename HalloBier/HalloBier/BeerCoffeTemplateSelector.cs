using HalloBier.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace HalloBier
{
    public class BeerCoffeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BeerTemplate { get; set; }
        public DataTemplate CoffeeTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
                return null;

            if (item is Kaffee)
                return CoffeeTemplate;
            else if (item is Bier)
                return BeerTemplate;
            else
                throw new NotImplementedException();
        }

    }
}
