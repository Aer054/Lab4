using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab4
{
     class ProfileViewModel : INotifyPropertyChanged
    {
        public ICommand Enter { set; get; }
        private async void Command_Execute_Enter(object parameter)
        {
           Window1 Window=new Window1();
           Window.Show();
           Application.Current.MainWindow.Close();
        }
        public ProfileViewModel()
        {
            Enter = new RelayCommand(Command_Execute_Enter);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
