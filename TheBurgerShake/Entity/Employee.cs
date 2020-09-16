using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Employee
    {
        string empId;

        public string EmpId
        {
            get { return empId; }
            set { empId = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        string phnNumber;

        public string PhnNumber
        {
            get { return phnNumber; }
            set { phnNumber = value; }
        }

        double salary;

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        string designation;

        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }
    }
}
