> Written in (Visual Studio 2017).

# Project: WpfAppEfPerson

## Table of Contents
1. [Description](#description)
2. [The database](#the-database)
3. [Create project](#create-project)


## Description 
This is a WPF application using MVVMLIGHT as design pattern. Makes connection with a database 
table named "Persons" using [Entity Framework 6.0](https://docs.microsoft.com/en-us/ef/ef6/) (EF Database First). For mapping between the entity and the DTO classes, I made use of [AutoMapper](http://docs.automapper.org/en/stable/Getting-started.html).
 
## The database
The database table named `Persons`exists of the following fields:
|DataType SQL         |DataType C#          |FieldName                      |
|---------------------|---------------------|-------------------------------|
|uniqueidentifier     |Guid                 |`ID`                           |
|nvarchar(50)         |String               |`FirstName`                    |
|nvarchar(50)         |String               |`LastName`                     |
|nvarchar(50)         |String               |`Street`                       |
|char(10)             |String               |`HouseNember `                 |
|nvarchar(50)         |String               |`PostalCode  `                 |
|varchar(10)          |String               |`Country     `                 |


See file `Persons.sql` in folder SQL. You can use this to create the database on your own system. On my system it was installed on `"source=(localDB)\MSSQLLocalDB"`.
## Create project
- Create Project: `Installed->Windows Desktop->WpfAppEfPerson->WPF App (.net Framework)`
- Open Nuget manager and install package `"mvvmlight"` from GalaSoft.
- Open Nuget manager and install package `"EntityFramework"` from Microsoft.
- Open Nuget manager and install package `"AutoMapper"` by Jimmy Bogard.
- Add new item `Installed->Data->ADO.Net Entity Data Model`, choose Database first and select the database table `Persons`. Name this ContextModel `PersonModel`.
- Create PersonDTO with the same properties as the Persons.cs class, created by EntityFramework in the previous step.
- Create a DataService for the communication with the database, with the following interface:
```cs
    public interface IDataService
    {
        ObservableCollection<PersonDTO> GetAll();
        ObservableCollection<Persons> Get(Func<Persons, bool> predicate);
        PersonDTO GetByName(string name);
        bool SavePerson(PersonDTO personDto);
        bool DeletePerson(Guid ID);
    }
```
- Create a Mapper class to map between entity class and DTO class and v.v. Make use of AutoMapper on the following way:
```cs
    //- To Initialise and configure for the entity class Pedrsons and the DTO class PersonDTO
    Mapper.Initialize(cfg => cfg.CreateMap<Persons, PersonDTO>());

    //To map the persons class to personDTO class call:
    Persons p = new Persons; 
    //Fill the proprerties of object p and map object p to pDto.
    PersonDTO pDto = Mapper.Map<PersonDTO>(p);

    //To map the personDTO class to persons class call:
    PersonDTO pDto = new PersonDTO; 
    //Fill the proprerties of object pDto and map object pDto to p..
    Persons p = Mapper.Map<Persons>(pDto);
``



