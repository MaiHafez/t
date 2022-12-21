using System;
namespace TaskSec;
public class Department{
    public string Name;
    public float Compensation;
    public Department(string name,float compensation){
        Name=name;
        Compensation=compensation;
    }
    public double GetSalary(double salary,int workinDays){
        return (salary *workinDays ) + (salary * workinDays) * (Compensation / 100);
    }
}

public class Employee{
    public string FirstName;
     public string LastName;
     public double Salary;
     public Department Department ;
     public Employee(string firstName, string lastName, double salary, Department department){
        FirstName= firstName;
        LastName= lastName;
        Salary =salary;
        Department= department;
     }
     public double GetSalary(double salary,int workinDays){
        return Department. GetSalary(salary , workinDays);
     }
    
}
public class Database{
    private int _currentIndex;
    public Department[] Departments=new Department[50];
    public Employee[] Employees =new Employee[50];
    public void AddDepartment(Department department){
            Departments[_currentIndex++]=department;
    }
    public void AddEmployee(Employee employee){
            Employees[_currentIndex++]=employee;
    }
}

public class program{
private static void Main(){
    var database=new Database();

    Console.WriteLine("enter department name :");
    var name=Console.ReadLine();

    Console.WriteLine("enter compensation :");
     var compensation=Convert.ToSingle(Console.ReadLine());

     Console.WriteLine("enter employee's firstname :");
     var firstname=Console.ReadLine();

     Console.WriteLine("enter employee's lastname :");
     var lastname=Console.ReadLine();

     Console.WriteLine("enter employee's salary :");
     var salary=Convert.ToDouble(Console.ReadLine());

     var department=new Department(name,compensation);

  var employee=new Employee(firstname, lastname,salary,department);
               
               database.AddDepartment(department);
               database.AddEmployee(employee);
}
}




