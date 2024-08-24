using System;
using System.Runtime.Serialization;

namespace CompanyMonitor.MVVM.Model.DataProviders
{
    [DataContract]
    public class DepartmentModel
    {

        [DataMember]
        public string Name { get; set; }

    }
}
