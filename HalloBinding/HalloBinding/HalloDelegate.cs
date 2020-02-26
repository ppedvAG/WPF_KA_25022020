using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HalloBinding
{
    delegate void EinfacherDelegate();
    delegate void DelegateMitPara(string txt);
    delegate long CalcDelegate(int a, int b);

    class HalloDelegate
    {
        public HalloDelegate()
        {
            EinfacherDelegate meinDele = HalloWelt;
            Action meinDeleAlsAction = HalloWelt;
            Action meinDeleAlsActionAno = delegate () { Console.WriteLine("AAAAHhh"); };
            Action meinDeleAlsActionAno2 = () => { Console.WriteLine("AAAAHhh"); };
            Action meinDeleAlsActionAno3 = () => Console.WriteLine("AAAAHhh");

            DelegateMitPara meinDeleMitPara = HalloWeltMitPara;
            Action<string> meinDeleMitParaAlsAction = HalloWeltMitPara;
            DelegateMitPara meinDeleMitParaAno = delegate (string s) { Console.WriteLine(s); };
            DelegateMitPara meinDeleMitParaAno2 = (string s) => { Console.WriteLine(s); };
            Action<string> meinDeleMitParaAno3 = (s) => Console.WriteLine(s);
            Action<string> meinDeleMitParaAno4 = x => Console.WriteLine(x);

            CalcDelegate calcDele = Minus;
            Func<int, int, long> calcAlsFunc = Sum;
            CalcDelegate calcDeleAno = (x, y) => { return x + y; };
            CalcDelegate calcDeleAno2 = (x, y) => x + y;

            List<string> texte = new List<string>();

            texte.Where((x) => { return x.StartsWith("b"); });
            texte.Where(x => x.StartsWith("b"));
            texte.Where(filter);
        }

        private bool filter(string arg)
        {
            if (arg.StartsWith("b"))
                return true;
            else
                return false;
        }

        private long Minus(int a, int b)
        {
            return a - b;
        }

        private long Sum(int a, int b)
        {
            return a + b;
        }

        private void HalloWeltMitPara(string msg)
        {
            Console.WriteLine($"Hallo {msg}");
        }

        public void HalloWelt()
        {
            Console.WriteLine("Hallo");
        }
    }
}
