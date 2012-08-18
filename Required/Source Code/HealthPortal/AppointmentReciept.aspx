<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AppointmentReciept.aspx.cs" Inherits="HealthPortal.AppointmentReciept" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table style="width:100%;">
        <tr>
            <td style="text-align:center">
                <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align:center">
                <asp:LinkButton ID="linkBackToProfile" runat="server" 
                    onclick="linkBackToProfile_Click">[Back to Profile]</asp:LinkButton>
            </td>
        </tr>
    </table>

</asp:Content>
