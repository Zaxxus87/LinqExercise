using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var avg = numbers.Average();
            var sum = numbers.Sum();
            Console.WriteLine($"Sum: {sum}\nAvg: {avg}");
            //Order numbers in ascending order and decsending order. Print each to console.
            var a = numbers.OrderBy(x => x);
            var d = numbers.OrderByDescending(x => x);
            Console.WriteLine();
            foreach(int num in a)
                Console.WriteLine(num);
            Console.WriteLine();
            foreach (int num in d)
                Console.WriteLine(num);
            //Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(x => x > 6);
            Console.WriteLine();
            foreach (int num in greaterThanSix)
                Console.WriteLine(num);
            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var highestFour = a.Take(4);
            Console.WriteLine();
            foreach (int num in highestFour)
                Console.WriteLine(num);
            //Change the value at index 4 to your age, then print the numbers in decsending order
            var lastOne = d.Select((x, i) => i==4 ? 54 : x);
            Console.WriteLine();
            foreach(int num in lastOne)
                Console.WriteLine(num);
            Console.WriteLine("\n-------------------------------------------");

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var taskOne = employees.Where(x => x.FirstName[0] == 'C' ||
                                          x.FirstName[0] == 'S').OrderBy(x => x.FirstName);
            foreach(Employee person in taskOne)
                Console.WriteLine(person.FullName);

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("-----------------------------------------");
            var taskTwo = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            foreach (Employee person in taskTwo)
                Console.WriteLine($"{person.FullName}\nAge: {person.Age}\n");
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("\n-----------------------------------------");
            var taskThree = employees.Where(x => x.YearsOfExperience < 11 && x.Age > 35);
            var sYOE = taskThree.Sum(x => x.YearsOfExperience);
            var aYOE = taskThree.Average(x => x.YearsOfExperience);
            Console.WriteLine($"Years of Experience < 10" +
                              $" and Age is greater than 35\n" +
                              $"Sum YOE: {sYOE}\nAvg YOE: {aYOE}");
            //Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("\n-----------------------------------------");
            var newEmployeesList = employees.Append(new Employee("Jeff", "Baker", 54, 0));
            foreach (Employee person in newEmployeesList)
                Console.WriteLine(person.FullName);
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
