using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class PersonManagerTest
    {
        [TestMethod]
        [Owner("Willian")]
        public void CreatePerson_OfTypeEmployeeTest()
        {
            PersonManager perMgr = new PersonManager();

            Person per;

            per = perMgr.CreatePerson("Willia", "Ramos", false);

            Assert.IsInstanceOfType(per, typeof(Employee));
        }


        [TestMethod]
        [Owner("Willian")]
        public void DoEmployeeExistTest()
        {
            Supervisor super = new Supervisor();

            super.Employees = new List<Employee>();
            super.Employees.Add(new Employee() { PrimeiroNome="Willian", UltimoNome="Ramos" });

            Assert.IsTrue(super.Employees.Count > 0);
        }

    }
}
