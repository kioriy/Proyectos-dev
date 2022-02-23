using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verificacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verificacion.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void serialTest()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("51155", logStatus.FaltaFotografia.ToString());
            Verificacion.Form1.serial(dic);
            Assert.IsTrue(true);
        }

       
  
    }
}