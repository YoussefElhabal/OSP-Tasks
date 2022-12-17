using System;

namespace Tasks;
public class Person
{
    public string Name;
    public int Age;
    public Person(string name, int age)
    {
        if (name == null || name == "" || name.Length >= 32)
        {
            throw new Exception("Invalid name");
        }
        if (age <= 0 || age > 128)
        {
            throw new Exception("Invalid age");
        }

        Name = name;
        Age = age;
    }
    public virtual void Print()
    {
        Console.WriteLine($"Name : {Name}, Age : {Age}");
    }
}

public class Student : Person
{
    public int Year;
    public float Gpa;
    public Student(string name, int age, int year, float gpa) : base(name, age)
    {
        if(year < 1 || year > 5)
        {
            throw new Exception("Invalid year");
        }
        if(gpa < 0 || gpa > 4)
        {
            throw new Exception("Invalid gpa");
        }

        Year = year;
        Gpa = gpa;
    }
    public override void Print()
    {
        Console.WriteLine($"My name is {Name}, my age is {Age} and my gpa is {Gpa}");
    }
}

public class Staff : Person
{
    public double Salary;
    public int JoinYear;
    public Staff(string name, int age, double salary, int joinyear) : base(name, age)
    {
        if(salary < 0 || salary > 120000) 
        {
            throw new Exception("Invalid salary");
        }
        int z = joinyear - age;
        if( z < 21)
        {
            throw new Exception("Invalid join year");
        }

        Salary = salary;
        JoinYear = joinyear;
    }
    public override void Print()
    {
        Console.WriteLine($"My name is {Name}, my age is {Age} and my salary is {Salary}");
    }

}
public class Database
{
    private int _currentIndex;
    public Person[] People = new Person[50];
    public void AddStudent(Student student)
    {
        People[_currentIndex++] = student;
    }
    public void AddStaff(Staff staff)
    {
        People[_currentIndex++] = staff;
    }
    public void AddPerson(Person person)
    {
        People[_currentIndex++] = person;
    }
    public void PrintAll()
    {
        for (int i = 0; i < _currentIndex; i++)
        {
            People[i].Print(); 
        }
    }
}

public class program
    {
        private static void Main()
        {
            var database = new Database();
            while (true)
            {
                Console.WriteLine("Enter an option : \n 1-for adding a student \n 2-for adding a staff \n 3-for adding a person \n 4-for printing out all people in people array");
                Console.Write("Option: ");
                var x = Convert.ToInt32(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        Console.Write("Name: ");
                        var name = Console.ReadLine();
                        Console.Write("age: ");
                        var age = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Year: ");
                        var year = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Gpa: ");
                        var gpa = Convert.ToSingle(Console.ReadLine());
                        try 
                        {
                            var student = new Student(name, age, year, gpa);
                            database.AddStudent(student);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break ;

                    case 2:
                        Console.Write("Name: ");
                        var name2 = Console.ReadLine();
                        Console.Write("age: ");
                        var age2 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Salary: ");
                        var Salary = Convert.ToInt32(Console.ReadLine());
                        Console.Write("JoinYear: ");
                        var JoinYear = Convert.ToInt32(Console.ReadLine());
                        try 
                        {
                            var staff= new Staff(name2, age2, Salary, JoinYear);
                            database.AddStaff(staff);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        
                        break;

                    case 3:
                        Console.Write("Name: ");
                        var name3 = Console.ReadLine();
                        Console.Write("age: ");
                        var age3 = Convert.ToInt32(Console.ReadLine());
                        try 
                        {
                            var person = new Person(name3, age3);
                            database.AddPerson(person);
                        }
                        catch (Exception e) 
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    case 4:
                        database.PrintAll();
                        break;

                    default:
                        return;
                }
            }
        }
    }