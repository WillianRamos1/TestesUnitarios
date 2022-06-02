using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class CollectionAssertClassTest
    {
        [TestMethod]
        [Owner("Willian")]
        public void AreCollectionEqualsFailsBecauseNoComparerTest()
        {
            PersonManager perMgr = new PersonManager();

            List<Person> PeopleExpected = new List<Person>();
            List<Person> PeopleActual = new List<Person>();

            PeopleExpected.Add(new Person() { PrimeiroNome = "Willian", UltimoNome="Ramos" });
            PeopleExpected.Add(new Person() { PrimeiroNome = "Alexia", UltimoNome = "Ramos" });
            PeopleExpected.Add(new Person() { PrimeiroNome = "April ", UltimoNome = "Ramos" });

            PeopleActual = perMgr.GetPeople();

            CollectionAssert.AreEqual(PeopleExpected, PeopleActual);
        }


        [TestMethod]
        [Owner("Willian")]
        public void AreCollectionEqualsWithComparerTest()
        {
            PersonManager perMgr = new PersonManager();

            List<Person> PeopleExpected = new List<Person>();
            List<Person> PeopleActual = new List<Person>();

            PeopleExpected.Add(new Person() { PrimeiroNome = "Willian", UltimoNome = "Ramos" });
            PeopleExpected.Add(new Person() { PrimeiroNome = "Alexia", UltimoNome = "Ramos" });
            PeopleExpected.Add(new Person() { PrimeiroNome = "April ", UltimoNome = "Ramos" });

            PeopleActual = perMgr.GetPeople();

            CollectionAssert.AreEqual(PeopleExpected, PeopleActual, Comparer<Person>.Create((x,y) => x.PrimeiroNome == y.PrimeiroNome && y.UltimoNome == y.UltimoNome ? 0:1));
        }


        [TestMethod]
        [Owner("Willian")]
        public void AreCollectionEquivalentTest()
        {
            PersonManager perMgr = new PersonManager();

            List<Person> PeopleExpected = new List<Person>();
            List<Person> PeopleActual = new List<Person>();

            PeopleActual = perMgr.GetPeople();

            PeopleExpected.Add(PeopleActual[1]);
            PeopleExpected.Add(PeopleActual[2]);
            PeopleExpected.Add(PeopleActual[0]);

            CollectionAssert.AreEquivalent(PeopleExpected, PeopleActual);
        }


        [TestMethod]
        [Owner("Willian")]
        public void IsCollectionOfTypeTest()
        {
            PersonManager perMgr = new PersonManager();

            List<Person> PeopleActual = new List<Person>();

            PeopleActual = perMgr.GetSupervisor();

            CollectionAssert.AllItemsAreInstancesOfType(PeopleActual, typeof(Supervisor));
        }
    }
}
