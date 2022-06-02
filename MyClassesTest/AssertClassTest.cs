using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    [TestClass]
    public class AssertClassTest
    {
        [TestMethod]
        [Owner("Willian")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualTest()
        {
            string str1 = "Willian";
            string str2 = "willian";

            Assert.AreEqual(str1, str2, false);
        }

        [TestMethod]
        [Owner("Willian")]
        public void AreNotEqualTest()
        {
            string str1 = "Willian";
            string str2 = "willian";

            Assert.AreNotEqual(str1, str2, false);
        }

        [TestMethod]
        public void AreSameTest()
        {
            FileProcessTest x = new FileProcessTest();
            FileProcessTest y = x;

            Assert.AreSame(x,y);
        }


        [TestMethod]
        public void AreNotSameTest()
        {
            FileProcessTest x = new FileProcessTest();
            FileProcessTest y = new FileProcessTest();

            Assert.AreNotSame(x, y);
        }


        #region IsInstanceOfType Test

        [TestMethod]
        [Owner("Willian")]
        public void IsInstanceOfTypeTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("Willian", "Ramos", true);

            Assert.IsInstanceOfType(per, typeof(Supervisor));
        }

        [TestMethod]
        [Owner("Willian")]
        public void IsNullTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("", "Ramos", true);

            Assert.IsNull(per);
        }
        #endregion

    }
}
