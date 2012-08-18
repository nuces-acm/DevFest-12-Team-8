<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HealthPortal.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table style="width:100%;">
        <tr>
            <td style="width: 613px">
                <h1 style="color: #000066"><strong>Welcome to Punjab Health PortaL!</strong></h1><br />
                <br />
                </td>
            <td>
                <table style="width:100%; margin-left: 0px;">
                    <tr>
                        <td colspan="3" class="tableHead">
                            New User</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                If you are a patient and visiting this website for the first time then please 
                Sign-up and be a part of e-reforms.</td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align:center">
                            <asp:Button ID="btnSingup" runat="server" Text="Sign up here" Width="268px" 
                                onclick="btnSingup_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 128px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" class="tableHead">
                            Existing User</td>
                    </tr>
                    <tr>
                        <td style="width: 128px">
                            <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 128px">
                            <asp:Label ID="Label1" runat="server" Text="Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 128px">
                            <asp:LinkButton ID="linkForgot" runat="server" onclick="linkForgot_Click">Forgot Password</asp:LinkButton>
                        </td>
                        <td>
                            <asp:Button ID="btnSignin" runat="server" Text="Sign In" Width="125px" 
                                onclick="btnSignin_Click" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>
