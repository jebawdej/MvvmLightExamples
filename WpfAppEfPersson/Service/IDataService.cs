using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppEfPersson.Service
{
    public interface IDataService
    {
        ObservableCollection<PersonDTO> GetAll();
        ObservableCollection<Persons> Get(Func<Persons, bool> predicate);
        PersonDTO GetByName(string name);
        bool SavePerson(PersonDTO personDto);
        bool DeletePerson(Guid ID);
    }
}
