<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Patient.aspx.cs" Inherits="HealthPortal.Patient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="3">
                <h1>PATIENT</h1></td>
        </tr>
        <tr>
            <td style="width: 145px">
                Full Name:</td>
            <td style="width: 604px">
                <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="tableHead">
                Tasks</td>
        </tr>
        <tr>
            <td style="width: 145px">
                Gender:</td>
            <td style="width: 604px">
                <asp:Label ID="lblGender" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:LinkButton ID="linkSetAppointment" runat="server" 
                    onclick="linkSetAppointment_Click">Set an appointment</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="width: 145px">
                Age:</td>
            <td style="width: 604px">
                <asp:Label ID="lblAge" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 145px">
                Email:</td>
            <td style="width: 604px">
                <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 145px">
                Home Address:</td>
            <td style="width: 604px">
                <asp:Label ID="lblHomeAddress" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 145px">
                Contact Number</td>
            <td style="width: 604px">
                <asp:Label ID="lblContactNumber" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
