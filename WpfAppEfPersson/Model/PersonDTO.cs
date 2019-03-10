using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppEfPersson
{ 
    public class PersonDTO : ObservableObject
    {
        public event EventHandler PersonChanged;
        private System.Guid _id;
        public System.Guid ID
        {
            get
            {
                return _id;
            }
            set
            {
                Set<System.Guid>(() => this.ID, ref _id, value);
                RaisePersonChanged();
            }
        }
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                Set<string>(() => this.FirstName, ref _firstName, value);
                RaisePersonChanged();
            }
        }
        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                Set<string>(() => this.LastName, ref _lastName, value);
                RaisePersonChanged();
            }
        }
        private string _street;
        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                Set<string>(() => this.Street, ref _street, value);
                RaisePersonChanged();
            }
        }

        private string _houseNumber;
        public string HouseNumber
        {
            get
            {
                return _houseNumber;
            }
            set
            {
                Set<string>(() => this.HouseNumber, ref _houseNumber, value);
                RaisePersonChanged();
            }
        }

        private string _postalCode;
        public string PostalCode
        {
            get
            {
                return _postalCode;
            }
            set
            {
                Set<string>(() => this.PostalCode, ref _postalCode, value);
                RaisePersonChanged();
            }
        }

        private string _place;
        public string Place
        {
            get
            {
                return _place;
            }
            set
            {
                Set<string>(() => this.Place, ref _place, value);
                RaisePersonChanged();
            }
        }
        private string _country;
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                Set<string>(() => this.Country, ref _country, value);
                RaisePersonChanged();
            }
        }
        private void RaisePersonChanged()
        {
            PersonChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}
