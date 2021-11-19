using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SalarySystem.UnitTests
{
    [TestClass]
    public class SalarySystemTests
    {
        MainSystem _system;

        [TestInitialize]
        public void TestInitialize()
        {
            _system = new MainSystem();
        }

        [TestMethod]
        public void Create_Admin()
        {
            String actual = _system.CreateAdmin();
            String expected = "Admin created successfully!";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void LogIn_Account()
        {
            String actual = _system.LogIn("acc", "password");
            String expected = "User doesn't exist";
            Assert.AreEqual(actual, expected);

            // log in as admin
            _system.CreateAdmin();
            actual = _system.LogIn("admin1", "admin1234");
            expected = "Logged in";
            Assert.AreEqual(actual, expected);

            // login as user
            _system.CreateAccount("acc1", "acc1", "user", 10000);
            actual = _system.LogIn("acc1", "acc1");
            expected = "Logged in";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void LogOut()
        {
            bool actual = _system.isLoggedIn;
            bool expected = false;
            Assert.AreEqual(actual, expected);

            _system.CreateAdmin();
            _system.LogIn("admin1", "admin1234");
            actual = _system.isLoggedIn;
            expected = true;
            Assert.AreEqual(actual, expected);

            _system.LogOut();
            actual = _system.isLoggedIn;
            expected = false;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Check_All_Active_Users()
        {
            // no users
            String actual = _system.ShowAllActiveUsers();
            String expected = "All active users: \n";
            Assert.AreEqual(actual, expected);

            // creating 1 user - admin
            _system.CreateAdmin();
            actual = _system.ShowAllActiveUsers();
            expected = "All active users: \nName: admin1, Password: admin1234, Role: Admin, Salary: 10000\n";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Delete_Account()
        {
            String actual = _system.DeleteAccount("acc", "password");
            String expected = "There is no account whit provided name and password";
            Assert.AreEqual(actual, expected);

            actual = _system.CreateAccount("acc1", "acc1", "user", 10000);
            expected = "You are not the admin";
            Assert.AreEqual(actual, expected);

            _system.CreateAdmin();
            _system.LogIn("admin1", "admin1234");
            _system.CreateAccount("acc1", "acc1", "user", 10000);
            _system.CreateAccount("acc2", "acc2", "user", 10000);
            actual = _system.DeleteAccount("acc1", "acc1");
            expected = "Account removed";
            Assert.AreEqual(actual, expected);
        }


    }
}