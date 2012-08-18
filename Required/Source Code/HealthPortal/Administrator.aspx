<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="HealthPortal.Administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="2">
                <h1>Administrator</h1></td>
        </tr>
        <tr>
            <td style="width: 145px">
                Full Name:</td>
            <td>
                <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 145px">
                Gender:</td>
            <td>
                <asp:Label ID="lblGender" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 145px">
                Age:</td>
            <td>
                <asp:Label ID="lblAge" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 145px">
                Email:</td>
            <td>
                <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 145px">
                Home Address:</td>
            <td>
                <asp:Label ID="lblHomeAddress" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 145px">
                Contact Number</td>
            <td>
                <asp:Label ID="lblContactNumber" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
