using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalloTPL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo TPL");
            //Parallel.Invoke(Zähle, Zähle, Zähle, Zähle, Zähle, Zähle, Zähle, Zähle);

            //Parallel.For(0, 1000000, i => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}"));
            //int wert = Convert.ToInt32(Console.ReadLine());
            int wert = 45678;
            Task t = new Task(() =>
            {
                Console.WriteLine("T1 gestartet");
                Thread.Sleep(600);
                Console.WriteLine("T1 fertig");
                throw new FieldAccessException();
            });

            t.ContinueWith(t1 => Console.WriteLine($"Fehler in T1 {t1.Exception.InnerException.Message}"), TaskContinuationOptions.OnlyOnFaulted);
            t.ContinueWith(t1 => Console.WriteLine($"T1 OK"), TaskContinuationOptions.OnlyOnRanToCompletion);
            t.ContinueWith(t1 => Console.WriteLine($"T1 wurde beendet"), TaskContinuationOptions.None);

            Task<long> t2 = new Task<long>(() =>
            {
                Console.WriteLine("T2 gestartet");
                var res = Calc(wert);
                Console.WriteLine("T2 fertig");
                return res;
            });
            var t2r = t2.ContinueWith(tr2 =>
             {
                 Console.WriteLine($"Der Result ist {tr2.Result}");
             });

            t.Start();
            t2.Start();

            Console.WriteLine("Ende");
            Console.ReadLine();
        }

        public static long Calc(int wert)
        {
            Thread.Sleep(400);
            return 234567890 * wert;
        }


        private static void Zähle()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");

                //Console.WriteLine(string.Format("Wert: {0} {1:d}", i, DateTime.Now));
                //Console.WriteLine($"Wert: {i} {DateTime.Now:d}");
            }
        }
    }
}
