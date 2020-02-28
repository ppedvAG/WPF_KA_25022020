using ppedv.Virository.Logic;
using ppedv.Virository.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ppedv.Virository.UI.WPF.ViewModels
{
    public class VirusViewModel : ViewModelBase
    {
        public List<Virus> VirenListe { get; set; }

        public Virus SelectedVirus
        {
            get => selectedVirus;
            set
            {
                selectedVirus = value;
                PropChanged(""); //update ALL

                //IChanged();
                //PropChanged(nameof(InkubationszeitDatum));
                //PropChanged(nameof(Inkubationszeit));

                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedVirus"));
                //   PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InkubationszeitDatum"));
            }
        }

        public int? Inkubationszeit
        {
            get => selectedVirus?.Inkubationszeit;
            set
            {
                if (selectedVirus != null && value.HasValue)
                    selectedVirus.Inkubationszeit = value.Value;

                PropChanged(nameof(InkubationszeitDatum));
            }
        }

        public string InkubationszeitDatum
        {
            get
            {
                if (SelectedVirus == null)
                    return "--";

                return DateTime.Now.AddDays(SelectedVirus.Inkubationszeit).ToShortDateString();
            }
        }

        Core core = new Core();
        private Virus selectedVirus;

        public SaveCommand SaveCommand { get; set; }

        public VirusViewModel()
        {
            VirenListe = new List<Virus>(core.Repository.GetAll<Virus>());

            SaveCommand = new SaveCommand(core);
        }

    }
}
