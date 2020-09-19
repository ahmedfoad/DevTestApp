using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevTest_Data;
using DevTest_Data.Models;
using DevTest_Repository;
using DevTest_Repository.Repos;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;
using System.Linq;
using DevExpress.Web;

namespace DevTestApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            UnitOfWork unitOfWork =new UnitOfWork(new TestModel());
           var accounts = unitOfWork._Repository.GetAccountAll();
           grid.DataSource = accounts;
           grid.DataBind();
        }
       
    
    }
}