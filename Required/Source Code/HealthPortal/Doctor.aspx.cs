using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HealthPortal
{
    public partial class Doctor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userDetails"] == null)
                Response.Redirect("Result.aspx?msg=User information not found!");
            else
            {

                Dictionary<string, object> userDetails = (Dictionary<string, object>)Session["userDetails"];

                try
                {
                    lblName.Text = userDetails["full_name"].ToString();
                    lblHomeAddress.Text = userDetails["home_address"].ToString();
                    lblContactNumber.Text = userDetails["contact_number"].ToString();
                    lblEmail.Text = userDetails["email"].ToString();
                    Int16 gender = (Int16)userDetails["gender"];
                    if (gender == 0)
                        lblGender.Text = "Male";
                    else if (gender == 1)
                        lblGender.Text = "Female";
                    else if (gender == 2)
                        lblGender.Text = "SheMale";
                    else
                        lblGender.Text = "Alien";

                    UInt64 dob = (UInt64)userDetails["dob"];
                    DateTime dtDOB = DateTime.FromFileTime((long)dob);
                    TimeSpan span = DateTime.Now.Subtract(dtDOB);

                    lblAge.Text = (span.Days / 365 / 12) + "";
                }
                catch (Exception ex)
                {
                    Response.Redirect("Result.aspx?msg=" + ex.Message);
                }
            }
        }
    }
}