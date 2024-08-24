using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows;
using CompanyMonitor.Core;
using CompanyMonitor.MVVM.Model.DataProviders;

namespace CompanyMonitor.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand GroupViewCommand { get; set; }
        public RelayCommand EmployeeViewCommand { get; set; }
        public RelayCommand ImportJsonCommand { get; set; }
        public RelayCommand ExportJsonCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public DepartmentViewModel DepartmentsVM { get; set; }
        public EmployeeViewModel EmployeeVM { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { 
                _currentView = value; 
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            DepartmentsVM = new DepartmentViewModel();
            EmployeeVM = new EmployeeViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            GroupViewCommand = new RelayCommand(o =>
            {
                CurrentView = DepartmentsVM;
            });

            EmployeeViewCommand = new RelayCommand(o =>
            {
                CurrentView = EmployeeVM;
                EmployeeVM.CurrentDepartment = o.ToString();
            });

            ImportJsonCommand = new RelayCommand(o =>
            {
                MyJsonObject jsonObject;
                var serializer = new DataContractJsonSerializer(typeof(MyJsonObject));

                using (var file = new FileStream("file.json", FileMode.OpenOrCreate))
                {
                    try
                    {
                        jsonObject = (MyJsonObject)serializer.ReadObject(file);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        jsonObject = null;
                    }
                }

                if (jsonObject != null)
                {
                    DepartmentsVM.Departments = new ObservableCollection<DepartmentModel>(jsonObject.Departments);
                    EmployeeVM.AllEmployees = new ObservableCollection<EmployeeModel>(jsonObject.Employees);
                }
            });

            ExportJsonCommand = new RelayCommand(o =>
            {
                var jsonObject = new MyJsonObject
                {
                    Departments = DepartmentsVM.Departments.ToList(),
                    Employees = EmployeeVM.AllEmployees.ToList()
                };

                var serializer = new DataContractJsonSerializer(typeof(MyJsonObject));

                using (var file = new FileStream("file.json", FileMode.Create))
                {
                    serializer.WriteObject(file, jsonObject);
                }
            });
        }

        [DataContract(Name = "root")]
        public class MyJsonObject
        {
            [DataMember(Name = "departments")]
            public List<DepartmentModel> Departments { get; set; }

            [DataMember(Name = "employees")]
            public List<EmployeeModel> Employees { get; set; }
        }
    }
}
