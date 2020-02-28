using ppedv.Virository.Logic;
using ppedv.Virository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.Virository.UI.WPF.ViewModels
{
    public class VirusViewModel
    {
        public List<Virus> VirenListe { get; set; }

        public Virus SelectedVirus { get; set; }

        Core core = new Core();

        public VirusViewModel()
        {
            VirenListe = new List<Virus>(core.Repository.GetAll<Virus>());
        }

    }
}
