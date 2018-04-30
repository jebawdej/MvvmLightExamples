using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace TwoViews.ViewModels
{
    public class SecondViewModel : ViewModelBase
    {
        public SecondViewModel()
        {
            Title = "TwoViews (SecondView)";
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged("Title"); }
        }
    }
}
