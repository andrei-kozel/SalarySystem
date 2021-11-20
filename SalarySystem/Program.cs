using System;
using System.Collections.Generic;

namespace SalarySystem;

public class SalarySystem
{
  private static MainSystem sys = new MainSystem();

  public static void Main(String[] args)
  {
    sys.CreateAdmin();
    StartApp();
  }

  private static void StartApp()
  {

    int input = 0;

    do
    {
      if (!sys.isLoggedIn)
      {
        LogInMenu();
      }
      else
      {
        if (sys.loggedInAccount is Admin)
        {
          ShowAdminMenu();
        }
        else
        {
          ShowUserMenu();
        }
      }

      Console.WriteLine("Chose a number: ");
      input = AskForInput();

      switch (input)
      {
        case 1:
          StartApp();
          break;
        case 2:
          sys.Exit();
          break;
        default:
          break;
      }

    } while (input != 2);
  }

  private static void LogInMenu()
  {
    int input = 0;

    Console.WriteLine("1. Log in.");
    Console.WriteLine("2. Close app.");

    Console.WriteLine("Chose a number: ");
    input = AskForInput();

    switch (input)
    {
      case 1:
        Console.WriteLine("Enter a name: ");
        String userName = Console.ReadLine();
        Console.WriteLine("Enter a password: ");
        String password = Console.ReadLine();
        String result = sys.LogIn(userName, password);
        Console.WriteLine(result);
        StartApp();
        break;
      case 2:
        sys.Exit();
        break;
      default:
        break;
    }
  }

  private static void ShowAdminMenu()
  {
    int input = 0;

    Console.Clear();
    Console.WriteLine("1. View my salary.");
    Console.WriteLine("2. View my role.");
    Console.WriteLine("3. Delete any account.");
    Console.WriteLine("4. Create new account");
    Console.WriteLine("5. Show all users");
    Console.WriteLine("6. Log Out");
    Console.WriteLine();

    Console.WriteLine("Chose a number: ");

    input = AskForInput();

    switch (input)
    {
      case 1:
        Console.Clear();
        Console.Write("Your salary is: " + sys.loggedInAccount.Salary);
        PressToContinue();
        break;
      case 2:
        Console.Clear();
        Console.Write("Your role is: " + sys.loggedInAccount.Role);
        PressToContinue();
        break;
      case 3:
        Console.WriteLine("Enter a name: ");
        String userName = Console.ReadLine();
        Console.WriteLine("Enter a password: ");
        String password = Console.ReadLine();
        sys.DeleteAccount(userName, password);
        StartApp();
        break;
      case 4:
        Console.WriteLine("Enter a name: ");
        userName = Console.ReadLine();
        Console.WriteLine("Enter a password: ");
        password = Console.ReadLine();
        Console.WriteLine("Enter a role: ");
        String role = Console.ReadLine();
        Console.WriteLine("Enter a salary: ");
        double salary = (double)AskForInput();
        sys.CreateAccount(userName, password, role, salary);
        StartApp();
        break;
      case 5:

        string result = sys.ShowAllActiveUsers();
        Console.Write(result);
        PressToContinue();
        break;
      case 6:
        sys.LogOut();
        StartApp();
        break;
      default:
        break;
    }
  }

  private static void ShowUserMenu()
  {
    int input = 0;

    Console.Clear();
    Console.WriteLine("1. View my salary.");
    Console.WriteLine("2. View my role.");
    Console.WriteLine("3. Delete my account.");
    Console.WriteLine("4. Log Out");
    Console.WriteLine();

    Console.WriteLine("Chose a number: ");
    input = AskForInput();

    switch (input)
    {
      case 1:
        Console.Clear();
        Console.Write("Your salary is: " + sys.loggedInAccount.Salary);
        PressToContinue();
        break;
      case 2:
        Console.Clear();
        Console.Write("Your role is: " + sys.loggedInAccount.Role);
        PressToContinue();
        break;
      case 3:
        Console.WriteLine("Enter a name: ");
        String userName = Console.ReadLine();
        Console.WriteLine("Enter a password: ");
        String password = Console.ReadLine();
        sys.DeleteAccount(userName, password);
        StartApp();
        break;
      case 4:
        sys.LogOut();
        StartApp();
        break;
      default:
        break;
    }
  }

  /// <summary>
  /// Press any button to continue
  /// </summary>
  private static void PressToContinue()
  {
    Console.WriteLine();
    Console.WriteLine("Press any button to continue ... ");
    Console.ReadKey();
    StartApp();
  }

  /// <summary>
  /// Ask for user input
  /// </summary>
  private static int AskForInput()
  {
    string stringInput = Console.ReadLine();
    int numericalInput;
    bool isNumber;
    do
    {
      isNumber = int.TryParse(stringInput, out numericalInput);
      if (!isNumber)
      {
        Console.Write("[" + stringInput + "]" + " - is not a number or empty. Please try again: ");
        stringInput = Console.ReadLine();
      }
    } while (!isNumber);

    return numericalInput;
  }
}