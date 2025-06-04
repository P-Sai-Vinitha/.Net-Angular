using System;

class Program
{
    // 1. Factorial using function
    static int Factorial(int num)
    {
        if (num < 0)
            throw new ArgumentException("Number must be non-negative.");
        int result = 1;
        for (int i = 2; i <= num; i++)
            result *= i;
        return result;
    }

    // 2. Simple Interest using function
    static double CalculateSI(double principal, double rate, int time)
    {
        if (principal < 0 || rate < 0 || time < 0)
            throw new ArgumentException("Values cannot be negative.");
        return (principal * rate * time) / 100;
    }

    // 3. Simple Interest and total using out parameters
    static void CalculateSIWithOut(double principal, double rate, int time, out double interest, out double total)
    {
        if (principal < 0 || rate < 0 || time < 0)
            throw new ArgumentException("Values cannot be negative.");
        interest = (principal * rate * time) / 100;
        total = principal + interest;
    }

    // 4. Simple Interest using optional parameter
    static double CalculateSIOptional(double principal, int time, double rate = 10)
    {
        if (principal < 0 || rate < 0 || time < 0)
            throw new ArgumentException("Values cannot be negative.");
        return (principal * rate * time) / 100;
    }

    static void Main()
    {
        // 1. Factorial
        try
        {
            Console.WriteLine("------ Factorial ------");
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            int fact = Factorial(num);
            Console.WriteLine($"Factorial of {num} is {fact}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in Factorial: " + ex.Message + "\n");
        }

        // 2. Simple Interest using function
        try
        {
            Console.WriteLine("------ Simple Interest (Function) ------");
            Console.Write("Enter Principal: ");
            double p = double.Parse(Console.ReadLine());
            Console.Write("Enter Rate: ");
            double r = double.Parse(Console.ReadLine());
            Console.Write("Enter Time: ");
            int t = int.Parse(Console.ReadLine());

            double si = CalculateSI(p, r, t);
            Console.WriteLine($"Simple Interest: {si}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in Simple Interest (Function): " + ex.Message + "\n");
        }

        // 3. Simple Interest using out parameters
        try
        {
            Console.WriteLine("------ Simple Interest with Out Parameters ------");
            Console.Write("Enter Principal: ");
            double p2 = double.Parse(Console.ReadLine());
            Console.Write("Enter Rate: ");
            double r2 = double.Parse(Console.ReadLine());
            Console.Write("Enter Time: ");
            int t2 = int.Parse(Console.ReadLine());

            CalculateSIWithOut(p2, r2, t2, out double interest, out double total);
            Console.WriteLine($"Simple Interest: {interest}, Total Payable: {total}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in SI with Out Parameters: " + ex.Message + "\n");
        }

        // 4. Simple Interest using optional parameter
        try
        {
            Console.WriteLine("------ Simple Interest (Optional Parameter) ------");
            Console.Write("Enter Principal: ");
            double p3 = double.Parse(Console.ReadLine());
            Console.Write("Enter Time: ");
            int t3 = int.Parse(Console.ReadLine());

            double siDefault = CalculateSIOptional(p3, t3); // default 10% rate used
            Console.WriteLine($"Simple Interest (default rate 10%): {siDefault}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in Optional Parameter SI: " + ex.Message + "\n");
        }

        Console.WriteLine("------ Program Completed ------");
    }
}
