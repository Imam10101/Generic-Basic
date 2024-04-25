using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Generic
{
  public  enum Designation
    {
        Manager=1,Admin,SoftwareEngineer
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public Designation  Designation { get; set; }
        public int DeptId { get; set; }
    }
}
