using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using WpfAppEfPersson.Service;

namespace WpfAppEfPersson.ViewModel
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
        private readonly IDataService _dataService;
        public RelayCommand SavePersonsCommand { get; private set; }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            if (IsInDesignMode)
            {
                Title = "WpfAppEfPerson in design mode";
            }
            else
            {
                // Code runs "for real"
                Title = "WpfAppEfPerson";
                SavePersonsCommand = new RelayCommand(SavePersonsMethod, CheckPersonChanged);
                Persons = _dataService.GetAll();
                if (Persons.Count > 0)
                    SelectedPerson = Persons[0];
            }
        }
        /// <summary>
        /// Command handler of RelayCommand: SavePersonsCommand
        /// </summary>
        private void SavePersonsMethod()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Title in caption above the form
        /// </summary>
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value) return;
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        ObservableCollection<PersonDTO> _persons;

        public ObservableCollection<PersonDTO> Persons
        {
            get { return _persons; }
            set
            {
                if (_persons == value) return;
                _persons = value;
                RaisePropertyChanged("Persons");
            }
        }

        /// <summary>
        /// Property SelectedPerson: the placeholder of the current selected PersonDTO
        /// </summary>
        PersonDTO _selectedperson;
        public PersonDTO SelectedPerson
        {
            get { return _selectedperson; }
            set
            {
                if (_selectedperson == value) return;
                if(_selectedperson != null)
                    _selectedperson.PersonChanged -= OnPersonChanged;

                _selectedperson = value;
                personReadyToSave(false);

                _selectedperson.PersonChanged += OnPersonChanged;
                RaisePropertyChanged("SelectedPerson");
                
            }
        }
        #region personChanged
        /// <summary>
        /// private member to set true when person is changed
        /// </summary>
        bool _personChanged;

        /// <summary>
        /// Func<bool> to use by command SavePersonssCommand.canExecute()
        /// </summary>
        /// <returns>status _personChanged</returns>
        bool CheckPersonChanged()
        {
            return _personChanged;
        }

        /// <summary>
        /// Eventhandler of PersonChanged in PersonDTO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPersonChanged(object sender, EventArgs e)
        {
            personReadyToSave(true);
        }
        //Methode to call when the state off _personChanged is changed.
        private void personReadyToSave(bool readyToSave)
        {
            _personChanged = readyToSave;
            if (SavePersonsCommand != null)
                SavePersonsCommand.RaiseCanExecuteChanged();
        }
        #endregion

    }
}