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
        public DataService()
        {
            context = new PersonEntities();
        }

        public ObservableCollection<PersonDTO> GetAll()
        {
            ObservableCollection<Persons> PersonList = new ObservableCollection<Persons>(context.Persons);
            //foreach (var item in context.Persons)
            //{
            //    PersonList.Add(item);
            //}
            return PersonsMapper.ConvertToDTO(PersonList);
        }

        public ObservableCollection<Persons> Get(Func<Persons, bool> predicate)
        {
            return (ObservableCollection<Persons>)context.Persons.Where(predicate);
        }

        public Persons GetByName(string name)
        {
            return context.Persons.FirstOrDefault(person => person.LastName == name);
        }
    }
}
