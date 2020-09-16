using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Repository;

namespace App
{
    public partial class ManageEmployeePage : Form
    {
        Login l;
        EmployeeRepo er;
        LoginRepo lr;


        public ManageEmployeePage(Login l)
        {
            InitializeComponent();
            this.l = l;
            WelcomeLabel.Text += l.Id;
            this.er = new EmployeeRepo();
            this.l = l;
            this.lr = new LoginRepo();

        }

        private void OnFormClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void ManageEmployeePage_Load(object sender, EventArgs e)
        {
            this.EmpPhoneTB1.Enabled = false;
            this.EmpRefreshBtn_Click(sender, e);

        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            DashboardPage hp = new DashboardPage(l);
            this.Visible = false;
            hp.Visible = true;
        }

        private void ManageEmpBtn_Click(object sender, EventArgs e)
        {
        }

        private void ManageProduct_Click(object sender, EventArgs e)
        {
            ManageProductPage hp = new ManageProductPage(l);
            this.Visible = false;
            hp.Visible = true;
        }

        private void ManageTable_Click(object sender, EventArgs e)
        {
            ManageTablePage hp = new ManageTablePage(l);
            this.Visible = false;
            hp.Visible = true;
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordPage hp = new ChangePasswordPage();
            this.Visible = false;
            hp.Visible = true;
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            LoginForm hp = new LoginForm();
            this.Visible = false;
            hp.Visible = true;
        }

        private void EmpLoadBtn_Click(object sender, EventArgs e)
        {
            string empId = this.EmpIdTB.Text;
            Employee emp = er.GetEmployee(empId);

            if (emp == null)
            {
                MessageBox.Show("Invalid ID");
            }
            else
            {
                this.EmpNameTB.Text = emp.Name;
                this.EmpPhoneTB2.Text = emp.PhnNumber.Substring(4);
                this.EmpSalaryTB.Text = emp.Salary + "";
                this.EmpRoleTB.Text = emp.Designation;
                this.EmpRefreshBtn.Enabled = true;
                this.EmpLoadBtn.Enabled = false;
                this.EmpInsertBtn.Enabled = false;
                this.EmpUpdateBtn.Enabled = true;
                this.EmpDeleteBtn.Enabled = true;
                this.EmpIdTB.Enabled = false;
            }
        }

        private void EmpInsertBtn_Click(object sender, EventArgs e)
        {
            Login user = new Login();
            Employee emp = new Employee();

            int p = new Random().Next(99999999) + 10000000;
            user.Id = this.EmpIdTB.Text;
            user.Password = p + "";

            emp.EmpId = this.EmpIdTB.Text;
            emp.Name = this.EmpNameTB.Text;
            try
            {
                int i = Convert.ToInt32(this.EmpPhoneTB2.Text);
                emp.PhnNumber = this.EmpPhoneTB1.Text + this.EmpPhoneTB2.Text;
                double sal = Convert.ToDouble(this.EmpSalaryTB.Text);
                emp.Salary = sal;
                emp.Designation = this.EmpRoleTB.Text;

                if ((emp.Designation.ToLower()).Equals("admin"))
                {
                    user.Role = 0;
                }

                else if ((emp.Designation.ToLower()).Equals("manager"))
                {
                    user.Role = 1;
                }

                else
                {
                    user.Role = 2;
                }

                if (lr.InsertUser(user))
                {
                    if (er.InsertEmployee(emp))
                    {
                        MessageBox.Show("Employee Added with Id: " + user.Id + " & Password: " + user.Password);
                        this.EmpRefreshBtn_Click(sender, e);
                      
                    }
                }
                else
                {
                    MessageBox.Show("Can Not Add" + user.Id);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Invalid Data" + exp.StackTrace);

            }
        }

        private void EmpRefreshBtn_Click(object sender, EventArgs e)
        {
            this.EmpIdTB.Text = "";
            this.EmpNameTB.Text = "";
            this.EmpPhoneTB2.Text = "";
            this.EmpSalaryTB.Text = "";
            this.EmpRoleTB.Text = "";


            this.EmpRefreshBtn.Enabled = false;
            this.EmpLoadBtn.Enabled = true;
            this.EmpInsertBtn.Enabled = true;
            this.EmpUpdateBtn.Enabled = false;
            this.EmpDeleteBtn.Enabled = false;

            this.EmpIdTB.Enabled = true;
        }

        private void EmpDeleteBtn_Click(object sender, EventArgs e)
        {
            Login user = new Login();
            user.Id = this.EmpIdTB.Text;

            Employee emp = new Employee();
            emp.EmpId = this.EmpIdTB.Text;

            if (lr.DeleteUser(user))
            {
                if (er.DeleteEmployee(emp))
                {
                    MessageBox.Show("Employee Removed");
                    this.EmpRefreshBtn_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Can Not Remove");
            }
        }

        private void EmpUpdateBtn_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.EmpId = this.EmpIdTB.Text;
            emp.Name = this.EmpNameTB.Text;
            emp.PhnNumber = this.EmpPhoneTB1.Text + this.EmpPhoneTB2.Text;
            emp.Salary = Convert.ToDouble(this.EmpSalaryTB.Text);
            emp.Designation = this.EmpRoleTB.Text;

            if (er.UpdateEmployee(emp))
            {
                MessageBox.Show("Employee Updated");
            }
            else
            {
                MessageBox.Show("Can NOT Update");
            }
        }

       

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            DashboardPage hp = new DashboardPage(l);
            this.Visible = false;
            hp.Visible = true;
        }



    }
}

