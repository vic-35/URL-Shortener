using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication_Forms1;

namespace WebApplication_Forms1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {


        }
        [TestMethod]
        public void Test_Util_l_MD5() // расчет короткой ссылки
        {
            // Вызов 
            string test = "Test_Util_l_MD5";
            string test_md5 = "c7eb12fa794bbcb717b86b7ae816a40a";
            // проверка
            string actual = Util_l.MD5(test);
            Assert.AreEqual(test_md5, actual,   "Ошибка расчета короткой ссылки");           

        }
    }
}
