using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfNavigationApp.Common;

namespace WpfNavigationApp.ViewModel
{

    public class NoteViewModel : ViewModelBase
    {
        private string _helloWorld;
        public string HelloWorld
        {
            get
            {
                return _helloWorld;
            }
            set
            {
                _helloWorld = value;
                RaisePropertyChanged(() => HelloWorld);
            }
        }
        public NoteViewModel(IFrameNavigationService fns)
        {
            HelloWorld = "Notes view";
        }
    }
}
