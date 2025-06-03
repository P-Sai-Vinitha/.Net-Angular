using System;

// 1. Base Employee class
public class Employee
{
    public int EmpCode { get; set; }
    public string EmpName { get; set; }
    public string Email { get; set; }
    public string DeptName { get; set; }
    public string Location { get; set; }

    public void Display()
    {
        Console.WriteLine(EmpCode);
        Console.WriteLine(EmpName);
        Console.WriteLine($"{Email} {DeptName}");
        Console.WriteLine(Location);
    }
}

// 2. Generic IEmployee interface
public interface IEmployee<T> where T : Employee
{
    string PrintEmployeeDetails(T employee);
}

// 3. Full-Time Employee Interface
public interface IFullTimeEmployee : IEmployee<Employee>
{
    double Basic { get; set; }
    double Hra { get; set; }
    double Da { get; set; }
    double NetSalary { get; set; }

    double CalculateSalary();
}

// 4. Part-Time Employee Interface
public interface IPartTimeEmployee : IEmployee<Employee>
{
    double Basic { get; set; }
    double Da { get; set; }
    double NetSalary { get; set; }

    double CalculateSalary();
}

// 5. FullTimeEmployee Class
public class FullTimeEmployee : Employee, IFullTimeEmployee
{
    public double Basic { get; set; }
    public double Hra { get; set; }
    public double Da { get; set; }
    public double NetSalary { get; set; }

    public double CalculateSalary()
    {
        Hra = 0.15 * Basic;
        Da = 0.10 * Basic;
        NetSalary = Basic + Hra + Da;
        return NetSalary;
    }

    public string PrintEmployeeDetails(Employee employee)
    {
        return $"Net Salary For Full Time Employee is: {NetSalary}";
    }
}

// 6. PartTimeEmployee Class
public class PartTimeEmployee : Employee, IPartTimeEmployee
{
    public double Basic { get; set; }
    public double Da { get; set; }
    public double NetSalary { get; set; }

    public double CalculateSalary()
    {
        Da = 0.05 * Basic;
        NetSalary = Basic + Da;
        return NetSalary;
    }

    public string PrintEmployeeDetails(Employee employee)
    {
        return $"Net Salary For Part Time Employee is: {NetSalary}";
    }
}

// 7. Program class with Main
public class Program
{
    public static void Main(string[] args)
    {
        // a. Base employee
        Employee emp = new Employee
        {
            EmpCode = 101,
            EmpName = "John Doe",
            Email = "john.doe@abc.com",
            DeptName = "Development",
            Location = "Hyderabad"
        };
        emp.Display();
        Console.WriteLine();

        // b. Part-Time Employee
        PartTimeEmployee pte = new PartTimeEmployee
        {
            EmpCode = 201,
            EmpName = "Alice Smith",
            Email = "alice@abc.com",
            DeptName = "Support",
            Location = "Chennai",
            Basic = 20000
        };
        pte.Display();
        pte.CalculateSalary();
        Console.WriteLine(pte.PrintEmployeeDetails(pte));
        Console.WriteLine();

        // c. Full-Time Employee
        FullTimeEmployee fte = new FullTimeEmployee
        {
            EmpCode = 301,
            EmpName = "Bob Williams",
            Email = "bob@abc.com",
            DeptName = "Testing",
            Location = "Bangalore",
            Basic = 40000
        };
        fte.Display();
        fte.CalculateSalary();
        Console.WriteLine(fte.PrintEmployeeDetails(fte));

        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
    }
}
