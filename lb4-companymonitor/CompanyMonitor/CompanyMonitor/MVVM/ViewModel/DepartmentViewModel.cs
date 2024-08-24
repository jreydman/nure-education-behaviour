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
    internal class DepartmentViewModel : INotifyPropertyChanged
    {
        private DepartmentModel oldDepartment;

        private string _departmentName;


        public string DepartmentName
        {
            get => _departmentName;
            set
            {
                _departmentName = value;
                OnPropertyChanged("DepartmentName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public ObservableCollection<DepartmentModel> Departments { get; set; }
        public RelayCommand EditDepartmentCommand { get; set; }
        public RelayCommand DeleteDepartmentCommand { get; set; }
        public RelayCommand AddDepartmentCommand { get; set; }

        private bool IsEditing = false;

        public DepartmentViewModel()
        {
            DataDepartment dataDepartment = new DataDepartment();
            Departments = new ObservableCollection<DepartmentModel>(dataDepartment.CreateDepartments());

            DeleteDepartmentCommand = new RelayCommand(o =>
            {
                var department = Departments.FirstOrDefault(x => x.Name == o.ToString());

                if (department != null)
                {
                    Departments.Remove(department);
                }
                else
                {
                    throw new ArgumentException($"Department named {o} was not found");
                }
            });

            AddDepartmentCommand = new RelayCommand(o =>
            {
                if (IsEditing)
                {
                    IsEditing = false;

                    var newDepartment = dataDepartment.AddDepartment(DepartmentName);
                    var isDepExsist = (Departments.FirstOrDefault(x => x.Name == newDepartment.Name) != null);

                    if (isDepExsist) MessageBox.Show($"Department with name {newDepartment.Name} is already exsist!");
                    else
                    {
                        var department = Departments.FirstOrDefault(x => x.Name == oldDepartment.Name);

                        var index = Departments.IndexOf(department);
                        Departments[index] = newDepartment;
                    }
                }
                else
                {
                  
                    var department = Departments.FirstOrDefault(x => x.Name == DepartmentName);
                    if (department == null)
                    {
                        try
                        {
                            var newDepartment = dataDepartment.AddDepartment(DepartmentName);
                            Departments.Add(newDepartment);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else MessageBox.Show($"Department with name {DepartmentName} is already exsist!");
                }
            });

            EditDepartmentCommand = new RelayCommand(o =>
            {
                oldDepartment = Departments.FirstOrDefault(x => x.Name == o.ToString());

                if (oldDepartment != null)
                {
                    DepartmentName = oldDepartment.Name;

                    IsEditing = true;
                }
                else throw new ArgumentException($"Department named {o} was not found");
            });
        }
    }
}
