using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NaviWPFApp.ViewModels.Common;
using WpfNavigationApp.Common;

namespace WpfNavigationApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IFrameNavigationService fns)
        {
            MainTitle = "Hallo Allemaal";
            _navigationService = fns;
 

           // _navigationService.NavigateTo("LoginView");
        }

        public MyCommand GotoLoginCommand
        {
            get { return new MyCommand(x => _navigationService.NavigateTo("LoginView")); }
        }
        public MyCommand GotoNotesCommand
        {
            get { return new MyCommand(x => _navigationService.NavigateTo("Notes")); }
        }
        private string _mainTitle;
        public string MainTitle
        {
            get
            {
                return _mainTitle;
            }
            set
            {
                _mainTitle = value;
                RaisePropertyChanged(() => MainTitle);
            }
        }
    }
}