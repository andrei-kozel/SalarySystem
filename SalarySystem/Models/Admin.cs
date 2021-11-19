namespace SalarySystem
{
    public class Admin : Account
    {
        public bool IsAdmin = true;

        public Admin(String Name, string Password, double Salary, String Role) : base(Name, Password, Salary, Role)
        {

        }
    }
}
