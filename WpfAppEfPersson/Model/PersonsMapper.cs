using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppEfPersson
{

    public static class PersonsMapper
    {
        //public static Persons ConvertFromDTO(this PersonDTO personDto)
        //{
        //    return new Persons
        //    {
        //        ID = personDto.ID,
        //        FirstName = personDto.FirstName,
        //        LastName = personDto.LastName,
        //        Street = personDto.Street,
        //        HouseNumber = personDto.HouseNumber,
        //        Country = personDto.Country,
        //        PostalCode = personDto.PostalCode
        //    };
        //}
        public static PersonDTO ConvertToDTO(this Persons person)
        {
            return new PersonDTO
            {
                ID = person.ID,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Street = person.Street,
                HouseNumber = person.HouseNumber,
                Country = person.Country,
                PostalCode = person.PostalCode
            };
        }

        public static ObservableCollection<PersonDTO> ConvertToDTO(this ObservableCollection<Persons> persons)
        {
            ObservableCollection<PersonDTO> personDto = new ObservableCollection<PersonDTO>();
            foreach (Persons p in persons)
            {
                personDto.Add(ConvertToDTO(p));
            }
            return personDto;
        }
    }
}
