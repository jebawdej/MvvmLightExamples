using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppEfPersson;

namespace WpfAppEfPersson.Service
{
    public class DataService : IDataService
    {
        PersonEntities context;
        PersonsMapper mapper;
        public DataService()
        {
            context = new PersonEntities();
            mapper = new PersonsMapper();
        }

        public ObservableCollection<PersonDTO> GetAll()
        {
            ObservableCollection<Persons> PersonList = new ObservableCollection<Persons>(context.Persons);
            //foreach (var item in context.Persons)
            //{
            //    PersonList.Add(item);
            //}
            return mapper.ConvertToDTO(PersonList);
        }

        public ObservableCollection<Persons> Get(Func<Persons, bool> predicate)
        {
            return (ObservableCollection<Persons>)context.Persons.Where(predicate);
        }

        public PersonDTO GetByName(string name)
        {
            Persons p = context.Persons.FirstOrDefault(person => person.LastName == name);
            return mapper.ConvertToDTO(p); ;
        }
        public bool SavePerson(PersonDTO personDto)
        {
            Persons person = mapper.ConvertFromDTO(personDto);
            if (person.ID == Guid.Empty)
            {
                //then create new
                person.ID = Guid.NewGuid();
                context.Persons.Add(person);
            }
            else
            { 
                //Then update
                Persons orig = context.Persons.FirstOrDefault(p => p.ID == person.ID);
                copyPerson(orig, person);
                //context.Entry(p).State = System.Data.Entity.EntityState.Modified;
            }
            context.SaveChanges();

            return true;
        }
        public bool DeletePerson(Guid id)
        {
            Persons personToDelete = context.Persons.FirstOrDefault(p => p.ID == id);
            if(personToDelete != null)
            {
                context.Persons.Remove(personToDelete);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        private void copyPerson(Persons to, Persons from)
        {
            to.ID = from.ID;
            to.FirstName = from.FirstName;
            to.LastName = from.LastName;
            to.Street = from.Street;
            to.HouseNumber = from.HouseNumber;
            to.PostalCode = from.PostalCode;
            to.Place = from.Place;
            to.Country = from.Country;
        }
    }
}
    