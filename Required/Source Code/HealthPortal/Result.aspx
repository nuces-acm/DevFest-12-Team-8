<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="HealthPortal.Result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="text-align:center">
                <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
        <td style="text-align:center">
            <asp:LinkButton ID="linkBackToHome" runat="server" 
                onclick="linkBackToHome_Click">[Back to Home]</asp:LinkButton>  
            </td>
        </tr>
    </table>
</asp:Content>
