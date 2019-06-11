using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AdventureWorksPeople.Models
{
    public class DepartmentEmployees
    {
        protected APIConnect _api;
        protected string BaseAddress { get; set; }
        public DepartmentEmployees(APIConnect api)
        {
            _api = api;
            BaseAddress = ConfigurationManager.AppSettings["BaseAddress"].ToString();
        }

        public string GetEmployeesInDepartment(int DepartmentID)
        {
            if (_api.GetDataSync(BaseAddress + @"/Department/" + DepartmentID.ToString()))
            {
                return _api.Results;
                //List<EmployeeAddressDepartment> DepartmentModelList = JsonConvert.DeserializeObject<List<EmployeeAddressDepartment>>(_api.Results);
            }
            else
            {
                return null;
            }
        }

        public string UpdateEmployeeAddress()
        {
            return null;
        }

    }
}