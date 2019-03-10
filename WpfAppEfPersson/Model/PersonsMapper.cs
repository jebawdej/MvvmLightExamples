using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppEfPersson
{
    //- To Initialise and configure for the entity class Pedrsons and the DTO class PersonDTO
    //Mapper.Initialize(cfg => cfg.CreateMap<Persons, PersonDTO>());

    //To map the persons class to personDTO class call:
    //Persons p = new Persons; 
    //Fill the proprerties of object p.
    // PersonDTO pDto = Mapper.Map<PersonDTO>(p);

    //To map the personDTO class to persons class call:
    //PersonDTO pDto = new PersonDTO; 
    //Fill the proprerties of object pDto.
    // Persons p = Mapper.Map<Persons>(pDto);


    public class PersonsMapper
    {
        public PersonsMapper()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Persons, PersonDTO>());
        }

        public Persons ConvertFromDTO(PersonDTO personDto)
        {
            return Mapper.Map<Persons>(personDto);
        }

        public ObservableCollection<Persons> ConvertFromDTO(ObservableCollection<PersonDTO> personDto)
        {
            ObservableCollection<Persons> persons = new ObservableCollection<Persons>();
            foreach (PersonDTO dto in personDto)
            {
                persons.Add(ConvertFromDTO(dto));
            }

            return persons;
        }

        public PersonDTO ConvertToDTO(Persons persons)
        {
            return Mapper.Map<PersonDTO>(persons);
        }

        public ObservableCollection<PersonDTO> ConvertToDTO(ObservableCollection<Persons> persons)
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
