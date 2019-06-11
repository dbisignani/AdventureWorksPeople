using System.Web.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Configuration;

namespace AdventureWorksPeople.Models
{
    public class Departments
    {
        public List<SelectListItem> DepartmentList { get; set; }

        protected APIConnect _api;
        protected string BaseAddress { get; set; }
        public Departments(APIConnect api)
        {
            _api = api;
            BaseAddress = ConfigurationManager.AppSettings["BaseAddress"].ToString();
        }


        public bool GetDepartmentsSync()
        {
            string Departments=string.Empty;
            SelectListItem sli;
            DepartmentList = new List<SelectListItem>();
            //No await keyword runs the routine synchronously; in this case, we need to insure the loist of departments is returned
            //so that the model has the list of selectlist items for the @Html.SelectListFor.
            if (_api.GetDataSync(BaseAddress + "/Department"))
            {
                Departments = _api.Results;
                List<DepartmentModel> DepartmentModelList = JsonConvert.DeserializeObject<List<DepartmentModel>>(Departments);
                foreach (DepartmentModel dm in DepartmentModelList)
                {
                    sli = new SelectListItem();
                    sli.Text = dm.Name;
                    sli.Value = dm.DepartmentID.ToString();
                    DepartmentList.Add(sli);
                }
                return true;
            }
            else
            {
                return false;
            }

        }

    }


}