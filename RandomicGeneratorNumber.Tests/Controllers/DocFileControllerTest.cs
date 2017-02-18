using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomicGeneratorNumber;
using RandomicGeneratorNumber.Controllers;

namespace RandomicGeneratorNumber.Tests.Controllers
{
    [TestClass]
    public class DocFileControllerTest
    {        
        [TestMethod]
        public void Post()
        {
            // Disposizione
            DocFileController controller = new DocFileController();

            // Azione
            controller.Post();

            // Asserzione
        }
    }
}
