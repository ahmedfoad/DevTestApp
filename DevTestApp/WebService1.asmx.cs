using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DevTest_Data.Models;
using DevTest_Repository;

namespace DevTestApp
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetAddition(string Acc_Number)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new TestModel());
            var message = unitOfWork._Repository.GetAccountAll_Text(Acc_Number);
          

            return message;
        }
    }
}
