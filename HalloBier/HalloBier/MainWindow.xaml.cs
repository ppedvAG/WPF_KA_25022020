using HalloBier.Data;
using HalloBier.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;

namespace HalloBier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BierManager bm = new BierManager();

        public MainWindow()
        {
            InitializeComponent();
            cb1.ItemsSource = Enum.GetValues(typeof(Sorten));
        }

        private void DemoBiereLaden(object sender, RoutedEventArgs e)
        {
            lb1.ItemsSource = bm.GetDemoBiere().ToList<object>().Union(bm.GetDemoKaffee()).OrderBy(x=>Guid.NewGuid()).ToList();
        }

        private void ExportBiere(object sender, RoutedEventArgs e)
        {
            using var sw = new StreamWriter("bier.xml");
            var serial = new XmlSerializer(typeof(List<Bier>));
            serial.Serialize(sw, lb1.ItemsSource);
        }

        private void ImportBiere(object sender, RoutedEventArgs e)
        {
            using var sr = new StreamReader("bier.xml");
            var serial = new XmlSerializer(typeof(List<Bier>));
            lb1.ItemsSource = (List<Bier>)serial.Deserialize(sr);
        }
    }
}
