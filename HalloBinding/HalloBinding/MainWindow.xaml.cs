using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HalloBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var ran = new Random();
            var timer = new Timer() { Enabled = true, Interval = 100 };

            timer.Elapsed += (s, e) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    r.Value = ran.Next(0, 255);
                    g.Value = ran.Next(0, 255);
                    b.Value = ran.Next(0, 255);
                });
            };
        }

    }

}
