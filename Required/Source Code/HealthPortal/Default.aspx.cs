using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HealthPortal
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void linkForgot_Click(object sender, EventArgs e)
        {
            string responseMsg = "If you have forgot your password then please try to recall it. Because this functionality has not been implemeted yet!";
            Response.Redirect("Result.aspx?msg=" + responseMsg);
        }

        protected void btnSingup_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientSignUP.aspx");
        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            UsersWS.UserManagementServiceClient usersWSClient = new UsersWS.UserManagementServiceClient();
            Dictionary<string, object> userDetails = usersWSClient.getCompleteUserDetails(txtUsername.Text, txtPassword.Text);
            string msg = "";
            if (userDetails.Count == 1)
                msg = userDetails["status"].ToString();
            else
            {
                String url = "";
                short userType = (short)(int)userDetails["user_type"];
                switch (userType)
                {
                    case 0:
                        url = "Administrator.aspx";
                        break;
                    case 1:
                        url = "Doctor.aspx";
                        break;
                    case 2:
                        url = "Patient.aspx";
                        break;
                    default:
                        url = "Result.aspx?msg=Invalid username/password!";
                        break;
                };

                Session.Add("userDetails", userDetails);
                Response.Redirect(url);
            }

            Response.Redirect("Result.aspx?msg="+msg);
        }
            
    }
}