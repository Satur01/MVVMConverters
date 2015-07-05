using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Data;

namespace MVVMConverters.ViewModels.ViewModelBase
{
    public class BindableBase:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
