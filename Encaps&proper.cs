  using System;

  namespace Task7; 

public class Person{
 private string _name;   
 public string Name
 {
    get 
    {
        return _name;
    } 
    set
    {
         if(value == null || value =="" || value.Length>=32)
    {
        throw new Exception("invalid name");
    } 
        _name=value;
    }
 }
 private int _age;
 public int Age{
    get{
        return _age;
    }
    set{
        if ( value <= 0 || value > 128 ){
    Console.WriteLine("invalid age");
    }
    _age=value;
 }
 }

 public Person(string name,int age)
 {
  Name = name;
  Age = age;
 }
 public virtual void Print()
    {
      Console.WriteLine($"My name is {Name}, my age is {Age}");
    }

}

public class Student :  Person
{
    private int _year;
    public int Year{
        get{
            return _year;
        }
        set{
         if ( value<1 || value>5 )
        {
            throw new ArgumentNullException("invalid year");
        }
        _year=value;
    } 
    }
    private float _gpa;
    public float Gpa{
        get{
            return _gpa;
        }
        set{
          if( value<=0 || value>4 )
        {
            throw new ArgumentNullException("invalid gpa");
        }
        _gpa=value;
        }
    }
    
    
    public Student(string name,int age,int year,float gpa ):base(name, age)
    {
        Year=year;
        Gpa=gpa; 
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"my gpa is {Gpa}");
    }
}
public class Staff :Person 
{
    private int _joinYear;
    public int JoinYear{
        get{
          return  _joinYear;
        }
        set{
            if( Age<=21 )
        {
             throw new Exception("invalid joinyear");
        }
         _joinYear=JoinYear;
        }
    }
    private double _salary;
    public double Salary{
        get{
            return _salary;
        }
        set{
        if( value<=0 || value>120000 )
        {
           throw new Exception("invalid salary");  
        }
        _salary=value;
        }
    }
    public Staff(string name,int age, double salary ,int joinyear ):base(name, age)
    
    {
        Salary=salary;
        JoinYear=joinyear;
    }
     public override void Print()
    {
        base.Print();
        Console.WriteLine($"my salary is{Salary}");
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
public class program{
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
                     try{
                      var student = new Student(name, age, year, gpa);
                    database.AddStudent(student);
                    student.Gpa=-1;
                     }
                     catch(ArgumentNullException e){
                        Console.WriteLine(e.Message);
                     }
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
                    try{
                     var staff = new Staff(name1, age1, salary,  joinyear);
                    database.AddStaff(staff);
                    staff.Salary=-200;
                    }
                    catch(Exception e){
                     Console.WriteLine(e.Message);
                    }
                    break;
                case 3:
                //person
                 Console.Write("Name: ");
                var name2 = Console.ReadLine();
                 Console.Write("Age: ");
                var age2 = Convert.ToInt32(Console.ReadLine());
                try{
               var person = new Person(name2, age2);
               database.AddPerson(person);
                person.Name=null;
                }
                catch(Exception e){
                    Console.WriteLine(e.Message);
                }
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
