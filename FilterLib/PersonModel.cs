using PabDbLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace FilterLib
{
    public class PersonModel : ObservableObject
    {
        public PabDBContext db { get; set; }
        public PersonModel() { }
        public PersonModel(PabDBContext db)
        {
            this.db = db;
            LoadPersonModel();
        }

        public Person Person { get; set; }
        public ObservableCollection<Person> People { get; set; }
        

        public void LoadPersonModel()
        {
            Person = new Person { Adress = new Adress { City = new City() } };
            People = db.Persons.ToList().AsObservableCollection();
        }

        public ICommand CreateNewPerson => new RelayCommand<string>(
            DoCreateNewPerson,
            x => true
            );

        private void DoCreateNewPerson(string obj)
        {
            var personAdresss = Person.Adress;
            if (db.Cities.Count(x => x.ZIP.Equals(personAdresss.City.ZIP)) != 0)
            {
                var id = db.Cities.First(x => x.ZIP.Equals(personAdresss.City.ZIP));
                personAdresss.City = id;

            }
            Person.Adress.City.Country = "Austria";
            
            //Adds Person to database
            db.Persons.Add(Person);
            db.SaveChanges();
            MessageBox.Show($"Person {Person.ToString()} added!");

            //ReloadsPersonModel
            LoadPersonModel();
            
            RaisePropertyChangedEvent(nameof(People));
        }
    }
}
