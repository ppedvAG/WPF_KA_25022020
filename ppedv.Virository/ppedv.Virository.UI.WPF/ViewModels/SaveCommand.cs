using ppedv.Virository.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ppedv.Virository.UI.WPF.ViewModels
{
    public class SaveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        Core core;
        public SaveCommand(Core core)
        {
            this.core = core;
        }

        public void Execute(object parameter)
        {
            core.Repository.SaveChanges();
        }
    }
}
