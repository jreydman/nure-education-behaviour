using System.Collections.Generic;

using CompanyMonitor.MVVM.Model.DataProviders;

namespace CompanyMonitor.MVVM.Model.DataControllers
{
    internal class DataDepartment
    {
        readonly string depName = "Department";

        public List<DepartmentModel> CreateDepartments()
        {
            List<DepartmentModel> output = new List<DepartmentModel>();

            output.Add(AddDepartment(depName));

            return output;
        }

        public DepartmentModel AddDepartment(string dName)
        {
            DepartmentModel output = new DepartmentModel();

            output.Name = dName;

            return output;
        }
    }
}
