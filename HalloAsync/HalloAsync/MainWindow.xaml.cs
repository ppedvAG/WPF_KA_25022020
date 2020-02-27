using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HalloAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartOhneThread(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                pb1.Value = i;
                Thread.Sleep(200);
            }
        }

        private void StartTask(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    pb1.Dispatcher.Invoke(() => pb1.Value = i);
                    Thread.Sleep(20);
                }

                ((Button)sender).Dispatcher.Invoke(() => ((Button)sender).IsEnabled = !false);
            });
        }

        private void StartTaskMitTS(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.IsEnabled = false;
            cts = new CancellationTokenSource();
            TaskScheduler ts = TaskScheduler.FromCurrentSynchronizationContext();

            var t1 = Task.Run(() =>
             {
                 for (int i = 0; i <= 100; i++)
                 {
                     Thread.Sleep(20);

                     Task.Factory.StartNew(() => pb1.Value = i, cts.Token, TaskCreationOptions.None, ts);

                     //if (i > 50) throw new IndexOutOfRangeException();

                     cts.Token.ThrowIfCancellationRequested();
                 }
             }, cts.Token);

            //bei cancel
            t1.ContinueWith(t => MessageBox.Show($"Vorgang wurd erfolgreich abgebrochen"),
                                CancellationToken.None, TaskContinuationOptions.OnlyOnCanceled, ts);

            //bei error
            t1.ContinueWith(t => MessageBox.Show($"Fehler: {t.Exception.InnerException.Message}"),
                                 CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, ts);

            //bei erfolg
            t1.ContinueWith(t => MessageBox.Show("Alles bestens!"),
                                 CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, ts);

            //immer
            t1.ContinueWith(t => btn.IsEnabled = true, CancellationToken.None, TaskContinuationOptions.None, ts);


        }


        CancellationTokenSource cts = null;

        private void Abbrechen(object sender, RoutedEventArgs e)
        {
            cts?.Cancel();
        }

        private async void StartAsyncAwait(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            cts = new CancellationTokenSource();
            btn.IsEnabled = false;

            for (int i = 0; i <= 100; i++)
            {
                pb1.Value = i;
                if (cts.IsCancellationRequested)
                    break;

                try
                {
                    await Task.Delay(30, cts.Token);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            btn.IsEnabled = !false;
        }

        private async void CountEmployees(object sender, RoutedEventArgs e)
        {
            //var conString = "Server=.;Database=Northwind;Trusted_Connection=true";
            var conString = "Server=(localdb)\\bla;Database=Northwind;Trusted_Connection=true";
            //var conString = "Server=.\\/*SQLEXPRESS*/;Database=Northwind;Trusted_Connection=true";

            using var con = new SqlConnection(conString);
            await con.OpenAsync();
            using var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Employees;WAITFOR DELAY '0:0:10'";
            var count = await cmd.ExecuteScalarAsync();

            MessageBox.Show($"{count} Employees in DB");

        }

        private async void StartAlt (object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.IsEnabled = !!false;
            pb1.IsIndeterminate = true;

            //MessageBox.Show(Calc(45363).ToString());
            MessageBox.Show((await CalcAsync(45363)).ToString());

            pb1.IsIndeterminate = !true;
            btn.IsEnabled = !!!!!false;

        }

        public Task<long> CalcAsync(int wert)
        {

            return Task.Run(() => Calc(wert));
        }

        [Obsolete("Nimm das nüscht!!!")]
        public long Calc(int wert) // <--- alt und langsam
        {
            Thread.Sleep(4000);
            return wert * 4567;
        }
    }
}
