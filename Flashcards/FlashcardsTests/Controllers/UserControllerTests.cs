using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flashcards.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flashcards.Models;

namespace Flashcards.Controllers.Tests {
    [TestClass()]
    public class UserControllerTests {
        [TestMethod()]
        public void LoginUserTest() {
            User user = new User();
            user.Id_user = 22;
            user.First_name = "Jan";
            user.Email = "jkowalski@gmail.com";
            user.Password = "MTIzNDU2Nzg=";
            user.Is_admin = 0;

            Assert.AreEqual(user.Password, "MTIzNDU2Nzg=");
        }
    }
}