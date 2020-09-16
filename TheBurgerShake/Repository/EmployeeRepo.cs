using Entity;
using Interfaces;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        DatabaseConnectionClass dcc;

        public EmployeeRepo()
        {
            dcc = new DatabaseConnectionClass();
        }

        public bool InsertEmployee(Employee emp)
        {
            string query = "INSERT into Employees VALUES ('"+emp.EmpId+"', '"+emp.Name+"', '"+emp.PhnNumber+"', "+emp.Salary+", '"+emp.Designation+"')";
            try
            {
                dcc.ConnectWithDB();
                int n = dcc.ExecuteSQL(query);
                dcc.CloseConnection();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        public bool DeleteEmployee(Employee emp)
        {
            string query = "DELETE from Employees WHERE EmpId = '" + emp.EmpId + "'";
            try
            {
                dcc.ConnectWithDB();
                int n = dcc.ExecuteSQL(query);
                dcc.CloseConnection();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }   
        }

        public bool UpdateEmployee(Employee emp)
        {
            string query = "UPDATE Employees SET Name = '"+emp.Name+"', PhnNumber = '"+ emp.PhnNumber+"', Salary = "+emp.Salary+", Designation = '"+emp.Designation+"' WHERE EmpId = '" + emp.EmpId + "'";
            try
            {
                dcc.ConnectWithDB();
                int n = dcc.ExecuteSQL(query);
                dcc.CloseConnection();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }   
        }

        public Employee GetEmployee(string empId)
        {
            Employee emp = null;
            string query = "SELECT * from Employees WHERE EmpId = '" + empId + "'";

            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while (sdr.Read())
            {
                emp = new Employee();
                emp.EmpId = sdr["EmpId"].ToString();
                emp.Name = sdr["Name"].ToString();
                emp.PhnNumber = sdr["PhnNumber"].ToString();
                emp.Salary = Convert.ToDouble(sdr["Salary"].ToString());
                emp.Designation = sdr["Designation"].ToString();
            }

            dcc.CloseConnection();
            return emp;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> listOfEmployee = new List<Employee>();

            string query = "SELECT * from Employees";

            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while (sdr.Read())
            {
                Employee emp = new Employee();
                emp.EmpId = sdr["EmpId"].ToString();
                emp.Name = sdr["Name"].ToString();
                emp.PhnNumber = sdr["PhnNumber"].ToString();
                emp.Salary = Convert.ToDouble(sdr["Salary"].ToString());
                emp.Designation = sdr["Designation"].ToString();

                listOfEmployee.Add(emp);
            }

            dcc.CloseConnection();

            return listOfEmployee;



        }
    }
}
