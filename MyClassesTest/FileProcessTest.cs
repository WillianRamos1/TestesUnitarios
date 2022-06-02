using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;
using System.Configuration;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\BadFileName.bat";
        private string _GoodFileName;

        public TestContext TestContext { get; set; }

        #region Test Initialize e Cleanup

        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExists"))
            {
                if (string.IsNullOrEmpty(_GoodFileName))
                {
                    SetGoodFileName();
                    TestContext.WriteLine($"Criando Arquivo: {_GoodFileName}");
                    File.AppendAllText(_GoodFileName, "Algum Texto");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExists"))
            {
                if (string.IsNullOrEmpty(_GoodFileName))
                {
                    SetGoodFileName();
                    TestContext.WriteLine($"Deletando Arquivo: {_GoodFileName}");
                    File.Delete(_GoodFileName);

                }
            }
        }
        #endregion

        [TestMethod]
        [Description("Verificar se um Arquivo Existe")]
        [Owner("Willian")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testando Arquivo: {_GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);
            
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesExistsSimpleMessage()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testando Arquivo: {_GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "Arquivo Não Existe");
        }


        [TestMethod]
        public void FileNameDoesExistsMessageFormatting()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testando Arquivo: {_GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "Arquivo {0} Não Existe", _GoodFileName);
        }


        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPatch]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPatch]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        private const string FILE_NAME = @"FileToDeploy.txt";

        [TestMethod]
        [Owner("Willian")]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistsUsingDeployment()
        {
            FileProcess fp = new FileProcess();
            string fileName;
            bool fromCall;

            fileName = $@"{TestContext.DeploymentDirectory}\{FILE_NAME}";
            TestContext.WriteLine($"Verificando Arquivo: {fileName}");
            fromCall = fp.FileExists(fileName);

            Assert.IsTrue(fromCall);
        }



        [TestMethod]
        [Description("Verifica se um Arquivo Não Existe")]
        [Owner("Willian")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameDoesNotExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Owner("Willian")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }
        [TestMethod]
        [Owner("Willian")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();

            try
            {
                fp.FileExists("");
            }
            catch (ArgumentException)
            {

                return;
            }
            Assert.Fail("Falha Esperada");
        }
    }
}
