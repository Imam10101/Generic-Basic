using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Data Input
            EmployeeBase employeeBase = new EmployeeBase();
            employeeBase.Add(new Employee
            {
                 Id=1, Designation=Designation.Admin,
                 Name="After",
                 Salary=50000,
                 DeptId=2
            });
            employeeBase.Add(new Employee
            {
                Id = 2,
                Designation = Designation.SoftwareEngineer,
                Name = "Babu",
                Salary = 150000,
                DeptId = 3
            });
            employeeBase.Add(new Employee
            {
                Id = 3,
                Designation = Designation.Manager,
                Name = "Jamal",
                Salary = 500000,
                DeptId = 2
            });
            employeeBase.Add(new Employee
            {
                Id = 4,
                Designation = Designation.SoftwareEngineer,
                Name = "doyel",
                Salary = 50000,
                DeptId = 3
            });
            var dept = new Department { Id = 1, Name = "Sales" };
            var dept1 = new Department { Id = 2, Name = "HR" };
            var dept2 = new Department { Id = 3, Name = "IT" };
            DepartmentBase departmentBase = new DepartmentBase();
            departmentBase.Add(dept);
            departmentBase.Add(dept1);
            departmentBase.Add(dept2);
            //Data Display
            var employees = employeeBase.GetAll();
            var departments = departmentBase.GetAll();
            Console.WriteLine("-------All Employee--------------");
          
            Console.WriteLine($"Name\t\tSalary");
            Console.WriteLine("------------------------------");
            employees.ForEach(e => Console.Write($"{e.Name}\t\t{e.Salary}\n"));

            
            Console.WriteLine("-------All Department--------------");
       
            Console.WriteLine($"Id\t\tName");
            Console.WriteLine("------------------------------");
           departments.ForEach(e => Console.Write($"{e.Id}\t\t{e.Name}\n"));
            //Join Department & Employee
            var output = (from e in employees
                         join d in departments
                         on e.DeptId equals d.Id
                         orderby e.Name
                         select new
                         {
                             Department = d.Name,
                             Name = e.Name,
                             Salary = e.Salary
                         }).ToList();
            Console.WriteLine("-------All Employees with Department--------------");
            Console.WriteLine($"Name\t\tDepartment\t\tSalary");
            Console.WriteLine("--------------------------------------------------------");
            output.ForEach(e => Console.Write($"{e.Name}\t\t{e.Department}\t\t{e.Salary}\n"));
            Console.WriteLine("-------More expensive Employee--------------");
            var expensive = output.Where(e => e.Salary.Equals(output.Max(s => s.Salary))).FirstOrDefault();
            Console.WriteLine($"{expensive.Name}\t\t{expensive.Department}\t\t{expensive.Salary}\n");
            Console.WriteLine("-------  Employees salary less than 100000--------------");
            var salry = output.Where(e => e.Salary<=100000).ToList() ;
           salry.ForEach(s=> Console.WriteLine($"{s.Name}\t\t{s.Department}\t\t{s.Salary}\n"));

            Console.WriteLine(  "-------------------Group by------------------");
            var grp = (from e in employees
                          join d in departments
                          on e.DeptId equals d.Id
                            group d by d.Name into g  
                          select new
                          {
                              Department = g.Key,
                              Total_employee = g.Count(),
                              
                          }).ToList();
            Console.WriteLine($" Department \t Total_employee  ");
            grp.ForEach(s => Console.WriteLine($"{s.Department}\t\t{s.Total_employee} "));
            Console.ReadKey();
        }
    }
}
