using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem
{
    public class MainSystem
    {
        public List<Account> accounts = new List<Account>();
        public bool isLoggedIn = false;
        public Account loggedInAccount = null;

        /// <summary>
        /// Log in to the system
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <returns>String result</returns>
        public String LogIn(String userName, String password)
        {
            String optionalResult = "";
            Account user = GetUser(userName, password);
            if (user != null)
            {
                isLoggedIn = true;
                loggedInAccount = (Account)user;
                optionalResult = "Logged in";
            }
            else
            {
                isLoggedIn = false;
                optionalResult = "User doesn't exist";
            }

            return optionalResult;
        }

        /// <summary>
        /// Log out
        /// </summary>
        public void LogOut()
        {
            loggedInAccount = null;
            isLoggedIn = false;
        }

        /// <summary>
        /// Create an admin
        /// </summary>
        /// <returns>String</returns>
        public String CreateAdmin()
        {
            String optionalResult = "";
            Admin admin = new Admin("admin1", "admin1234", 10000.0, "Admin");
            accounts.Add(admin);

            if (GetUser(admin.Name, admin.Password) == admin)
            {
                optionalResult = "Admin created successfully!";
            }

            return optionalResult;
        }

        /// <summary>
        /// Create a new user
        /// Only admin can do it
        /// </summary>
        /// <param name="userName">Account name</param>
        /// <param name="password">Password</param>
        /// <param name="role">Role in company</param>
        /// <param name="salary">User salary</param>
        /// <returns>String result</returns>
        public String CreateAccount(String userName, String password, String role, double salary)
        {
            String optionalResult = "";
            if (loggedInAccount is Admin)
            {
                if (userName.Length > 0 && password.Length > 0 && role.Length > 0)
                {
                    User user = new User(userName, password, salary, role);
                    accounts.Add(user);
                    if (GetUser(userName, password) == user)
                    {
                        optionalResult = "Successfully created.";
                    }
                }
                else
                {
                    optionalResult = "Something is wrong. Fields can't be empty. Please try again.";
                }
            }
            else
            {
                optionalResult = "You are not the admin";
            }

            return optionalResult;
        }

        /// <summary>
        /// Delete account
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="password">password</param>
        /// <returns>String result</returns>
        public String DeleteAccount(String userName, String password)
        {
            String optionalResult = "";
            Account acc = GetUser(userName, password);

            if (acc != null)
            {
                if (loggedInAccount is Admin && loggedInAccount.Name.Equals(userName))
                {
                    optionalResult = "Admin can not delete your own account.";
                }
                else
                {
                    accounts.Remove(acc);
                }
                optionalResult = "Account removed";
            }
            else
            {
                optionalResult = "There is no account whit provided name and password";
            }

            return optionalResult;
        }

        /// <summary>
        /// Show all active users
        /// </summary>
        /// <returns></returns>
        public String ShowAllActiveUsers()
        {
            String outout = "All active users: \n";
            foreach (Account acc in accounts)
            {
                outout += "Name: " + acc.Name + ", Password: " + acc.Password + ", Role: " + acc.Role + ", Salary: " + acc.Salary + "\n";
            }
            return outout;
        }


        /// <summary>
        /// Get an user by name and password
        /// </summary>
        /// <param name="userName">user name</param>
        /// <param name="password">password</param>
        /// <returns>account if exists otherwise null</returns>
        public Account GetUser(string? userName, string? password)
        {
            foreach (Account account in accounts)
            {
                if (account.Name.Equals(userName) && account.Password.Equals(password))
                {
                    return account;
                }
            }
            return null;
        }

        /// <summary>
        /// Close the application
        /// </summary>
        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
