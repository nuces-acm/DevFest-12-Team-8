using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HealthPortal
{
    public partial class AppointmentReciept : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = Request["msg"];
        }

        protected void linkBackToProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Patient.aspx");
        }
    }
}