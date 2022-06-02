using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace MyClassesTest
{
    [TestClass]
    public class StringAssertClassTest
    {
        [TestMethod]
        [Owner("Willian")]
        public void ContainsTest()
        {
            string str1 = "Willian Ramos";
            string str2 = "Ramos";

            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        [Owner("Willian")]
        public void StartWithTest()
        {
            string str1 = "Todos em Caixa Alta";
            string str2 = "Todos em Caixa";

            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        [Owner("Willian")]
        public void IsAllLowerCaseTest()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("todos em caixa", reg);
        }

        [TestMethod]
        [Owner("Willian")]
        public void IsNotAllLowerCaseTest()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("Todos em Caixa", reg);
        }
    }
}
