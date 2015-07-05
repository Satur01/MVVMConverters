using MVVMConverters.ViewModels.ViewModelBase;

namespace MVVMConverters.ViewModels
{
    public class VMMainPage:BindableBase
    {

        private int _age;

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                RaisePropertyChanged();
            }
        }
        

    }
}
