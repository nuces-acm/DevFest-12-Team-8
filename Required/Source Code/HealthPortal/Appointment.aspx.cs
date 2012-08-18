using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HealthPortal.AdminWS;
using HealthPortalWebServices;

namespace HealthPortal
{
    public partial class Appointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminWS.AdminServiceClient adminWSClient = new AdminWS.AdminServiceClient();
            Hospital[] hospitals = adminWSClient.getListOfHospitals();
            if (hospitals == null)
            {
                Response.Redirect("Result.aspx?msg=Error loading hospitals list");
                return;
            }

            foreach (Hospital hospital in hospitals)
            {
                dwHospital.Items.Add(new ListItem(hospital.Name, hospital.ID.ToString()));
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            AppointmentsWS.AppointmentServiceClient asClient = new AppointmentsWS.AppointmentServiceClient();
            Dictionary<string, object> appointmentDetails = asClient.GetAppointment(Session["username"].ToString(), Session["password"].ToString(), UInt32.Parse(dwHospital.SelectedValue), UInt64.Parse(dwDepartment.SelectedValue));
            DateTime time = DateTime.FromFileTime((long)(UInt64.Parse(appointmentDetails["appointment_time"].ToString())));
            string msg = "[Success]:\tYour appointment has been scheduled on " + time.ToLongDateString() + " " + time.ToShortTimeString() + " at " + dwDepartment.SelectedItem.Text + ", " + dwHospital.SelectedItem.Text + "!";
            Response.Redirect("AppointmentReciept.aspx?msg=" + msg);

        }

        protected void dwHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdminWS.AdminServiceClient adminWSClient = new AdminWS.AdminServiceClient();
            Department[] departments = adminWSClient.getListOfDepartments(UInt32.Parse(dwHospital.SelectedValue));
            if (departments == null)
            {
                Response.Redirect("Result.aspx?msg=Error loading departments list");
                return;
            }

            foreach (Department department in departments)
            {
                dwDepartment.Items.Add(new ListItem(department.Name, department.ID.ToString()));
            }
        }
    }
}