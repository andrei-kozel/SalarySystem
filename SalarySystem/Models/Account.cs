namespace SalarySystem
{
    public class Account
    {
        public String Name { get; set; }
        public String Password { get; set; }
        public Double Salary { get; set; }
        public String Role { get; set; }

        public Account() { }

        public Account(String Name, String Password, Double Salary, String Role)
        {
            this.Name = Name;
            this.Password = Password;
            this.Salary = Salary;
            this.Role = Role;
        }
    }
}
