<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Appointment.aspx.cs" Inherits="HealthPortal.Appointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <table style="width:100%;">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Appointment"></asp:Label>
                </td>
                <td class="style1" style="width: 683px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblHospital" runat="server" Text="Hospital:"></asp:Label>
                </td>
                <td class="style1" style="width: 683px">
                    <asp:DropDownList ID="dwHospital" runat="server" Width="197px" 
                        onselectedindexchanged="dwHospital_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label>
                </td>
                <td class="style1" style="width: 683px">
                    <asp:DropDownList ID="dwDepartment" runat="server" Width="197px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;</td>
                <td class="style1" style="width: 683px">
                    <asp:Button ID="btnAppointment" runat="server" Font-Bold="True" 
                        onclick="btnSignIn_Click" Text="Take Appointment" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
</asp:Content>
