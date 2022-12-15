 using System;

namespace Task3;
public class Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public virtual void Print(){
        Console.WriteLine($"My name is {Name}, my age is {Age}");
    }
}
public class Student : Person
{
    public int Year;
    public float Gpa;
    public Student(string name, int age, int year, float gpa) : base(name, age)
    {
        Year = year;
        Gpa = gpa;
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($" Gpa: {Gpa}");
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
     public void AddPerson(Person person){
    People[_currentIndex++] = person;
  } 
    public void PrintAll()
    {
        foreach(var item in People){
            item?.Print();
        }

    }

}

public class Staff : Person
{
    public double Salary;
    public int JoinYear;
    public Staff(string name, int age, double salary, int joinyear) : base(name, age)
    {
        Salary = salary;
        JoinYear = joinyear;
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Salary: {Salary}");
    }

}
public class Program
{
    private static void Main()
    {
        var database = new Database();
        while (true)
        {
             Console.WriteLine("option(1)--> add student , option(2)--> add staff , option(3)--> add person ,option(4)--> print all");
             Console.Write("enter option : ");
             var option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                //student
                    Console.Write("Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Age: ");
                    var age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Year: ");
                    var year = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Gpa: ");
                     var gpa = Convert.ToSingle(Console.ReadLine());
                      var student = new Student(name, age, year, gpa);
                    database.AddStudent(student);
                    break;
                case 2:
                //staff
                    Console.Write("Name: ");
                   var name1 = Console.ReadLine();
                    Console.Write("Age: ");
                    var age1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Salary: ");
                    var salary = Convert.ToDouble(Console.ReadLine());
                    Console.Write("JoinYear: ");
                    var joinyear = Convert.ToInt32(Console.ReadLine());
                     var staff = new Staff(name1, age1, salary,  joinyear);
                    database.AddStaff(staff);
                    break;
                case 3:
                //person
                 Console.Write("Name: ");
                var name2 = Console.ReadLine();
                 Console.Write("Age: ");
                var age2 = Convert.ToInt32(Console.ReadLine());

               var person = new Person(name2, age2);
               database.AddPerson(person);
                break;
                case 4:
                //print all
              database.PrintAll();
                break;
                default:
                    return;

            }
        }
            
    }
}

