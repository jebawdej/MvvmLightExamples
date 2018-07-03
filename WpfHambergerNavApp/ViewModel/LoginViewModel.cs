﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfHamburgerNavApp.Common;

namespace WpfHamburgerNavApp.ViewModel
{

    public class LoginViewModel : ViewModelBase
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

        public LoginViewModel(IFrameNavigationService fns)
        {
            HelloWorld = "Login View";
        }
    }
}
