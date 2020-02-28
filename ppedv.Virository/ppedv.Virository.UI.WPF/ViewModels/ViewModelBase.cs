using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ppedv.Virository.UI.WPF.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void PropChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        protected void IChanged([CallerMemberName]string cmn = "")
        {
            if (!string.IsNullOrEmpty(cmn))
                PropChanged(cmn);
        }
    }
}
