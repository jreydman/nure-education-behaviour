using System;
using System.Linq;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;

using CompanyMonitor.Core;
using CompanyMonitor.MVVM.Model.DataProviders;
using CompanyMonitor.MVVM.Model.DataControllers;

namespace CompanyMonitor.MVVM.ViewModel
{
    internal class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public ObservableCollection<EmployeeModel> AllEmployees { get; set; }
        public ObservableCollection<EmployeeModel> Employees { get; set; }

        private string _currentDepartment;
        public string CurrentDepartment
        {
            get => _currentDepartment;
            set
            {
                _currentDepartment = value;
                Employees = new ObservableCollection<EmployeeModel>(AllEmployees.Where<EmployeeModel>(o => o.Department == CurrentDepartment));
            }
        }

        public RelayCommand DeleteEmployeeCommand { get; set; }
        public RelayCommand EditEmployeeCommand { get; set; }
        public RelayCommand AddEmployeeCommand { get; set; }

        public string _employeeFullname;
        public string _employeeSalary;
        public string _employeeDepartment;

        public string EmployeeFullname
        {
            get => _employeeFullname;
            set
            {
                _employeeFullname = value;
                OnPropertyChanged("EmployeeFullname");
            }
        }
        public string EmployeeSalary
        {
            get => _employeeSalary;
            set
            {
                _employeeSalary = value;
                OnPropertyChanged("EmployeeSalary");
            }
        }
        public string EmployeeDepartment
        {
            get => _employeeDepartment;
            set
            {
                _employeeDepartment = value;
                OnPropertyChanged("EmployeeDepartment");
            }
        }

        private bool IsEditing = false;
        private EmployeeModel oldEmployee;

        public EmployeeViewModel()
        {
            DataEmployee dataEmployee = new DataEmployee();
            AllEmployees = new ObservableCollection<EmployeeModel>(dataEmployee.CreateEmployees());

            DeleteEmployeeCommand = new RelayCommand(o =>
            {
                var employee = AllEmployees.FirstOrDefault(x => x.Fullname == _employeeFullname);

                if (employee != null)
                {
                    AllEmployees.Remove(employee);
                    Employees = new ObservableCollection<EmployeeModel>(AllEmployees.Where<EmployeeModel>(o => o.Department == CurrentDepartment));
                    OnPropertyChanged(nameof(Employees));
                }
                else
                {
                    throw new ArgumentException($"Department named {o} was not found");
                }
            });

            AddEmployeeCommand = new RelayCommand(o =>
            {
                if (IsEditing)
                {
                    IsEditing = false;

                  
                    var newEmployee = dataEmployee.addEmployee(EmployeeFullname, EmployeeSalary, EmployeeDepartment);
                    var istExsist = (AllEmployees.FirstOrDefault(x => x.Fullname == newEmployee.Fullname) != null);

                    if (istExsist)
                    {
                        MessageBox.Show($"{newEmployee.Fullname} is already exsist!");
                    }
                    else
                    {
                        var count = AllEmployees.Where<EmployeeModel>(o => o.Department == EmployeeDepartment).Count();
                            var employee = AllEmployees.FirstOrDefault(x => x.Fullname == oldEmployee.Fullname);

                            var index = AllEmployees.IndexOf(employee);
                            AllEmployees[index] = newEmployee;

                            Employees = new ObservableCollection<EmployeeModel>(AllEmployees.Where<EmployeeModel>(o => o.Department == CurrentDepartment));
                            OnPropertyChanged(nameof(Employees));
                    }
                }
                else
                {
                    var employee = AllEmployees.FirstOrDefault(x => x.Fullname == EmployeeFullname);
                    if (employee == null)
                    {
                        var count = AllEmployees.Where<EmployeeModel>(o => o.Department == EmployeeDepartment).Count();
                        try
                            {
                                var newEmployee = dataEmployee.addEmployee(EmployeeFullname, EmployeeSalary, EmployeeDepartment);
                                AllEmployees.Add(newEmployee);
                                Employees = new ObservableCollection<EmployeeModel>(AllEmployees.Where<EmployeeModel>(o => o.Department == CurrentDepartment));
                                OnPropertyChanged(nameof(Employees));
                        }
                        catch (Exception ex)
                        {
                          MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"{EmployeeFullname} is already exsist!");
                    }
                }
            });

            EditEmployeeCommand = new RelayCommand(o =>
            {
                oldEmployee = AllEmployees.FirstOrDefault(x => x.Fullname == EmployeeFullname);

                if (oldEmployee != null)
                {
                    EmployeeFullname = oldEmployee.Fullname;
                    EmployeeSalary = oldEmployee.Salary;
                    EmployeeDepartment = oldEmployee.Department;

                    IsEditing = true;
                }
                else
                {
                    throw new ArgumentException($"{o} was not found");
                }
            });
        }
    }
}
