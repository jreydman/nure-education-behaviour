using System;
using System.Collections.Generic;

using CompanyMonitor.MVVM.Model.DataProviders;

namespace CompanyMonitor.MVVM.Model.DataControllers
{
    internal class DataEmployee
    {
        public List<EmployeeModel> CreateEmployees(int total = 2)
        {
            List<EmployeeModel> output = new List<EmployeeModel>();

            for (int i = 0; i < total; i++)
            {

                output.Add(CreateEmployee());
            }

            return output;
        }

        public EmployeeModel addEmployee(string sfullname, string sSalary, string sDepartment)
        {
            EmployeeModel output = new EmployeeModel();

            output.Fullname = sfullname;
            output.Salary = sSalary;
            output.Department = sDepartment;

            return output;
        }

        private EmployeeModel CreateEmployee()
        {
            EmployeeModel output = new EmployeeModel();
            Random rnd = new Random();

            output.Fullname = rnd.Next(1, 25).ToString();
            output.Salary = rnd.Next(1, 10000).ToString();
            output.Department = "Department";

            return output;
        }
    }
}
