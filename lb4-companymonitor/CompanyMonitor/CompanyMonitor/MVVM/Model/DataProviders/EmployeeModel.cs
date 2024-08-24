using System.Runtime.Serialization;

namespace CompanyMonitor.MVVM.Model.DataProviders
{
    [DataContract]
    public class EmployeeModel
    {
        [DataMember]
        public string Fullname { get; set; }

        [DataMember]
        public string Salary { get; set; }
        [DataMember]
        public string Department { get; set; }
    }
}
