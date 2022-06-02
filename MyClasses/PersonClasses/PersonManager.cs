using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses.PersonClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string primeiro, string ultimo, bool isSupervisor)
        {
            Person ret = null;

            if (!string.IsNullOrEmpty(primeiro))
            {
                if (isSupervisor)
                    ret = new Supervisor();
                else
                    ret = new Employee();

                ret.PrimeiroNome = primeiro;
                ret.UltimoNome = ultimo;
            }
            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { PrimeiroNome = "Willian", UltimoNome = "Ramos" });
            people.Add(new Person() { PrimeiroNome = "Alexia", UltimoNome = "Ramos" });
            people.Add(new Person() { PrimeiroNome = "April ", UltimoNome = "Ramos" });

            return people;
        }

        public List<Person> GetSupervisor()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Willian", "Ramos", true));
            people.Add(CreatePerson("Alexia", "Ramos", true));

            return people;
        }
    }
}
