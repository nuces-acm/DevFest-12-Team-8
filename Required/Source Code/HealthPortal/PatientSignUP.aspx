<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientSignUP.aspx.cs" Inherits="HealthPortal.PatientSignUP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table align="right" style="width: 100%; height: 100%;">
        <tr>
            <td colspan="3">
                <h1>Patient Signup</h1>
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td align="right" style="width: 326px">
                <asp:Label ID="lblUserName" runat="server" Text="Username:"></asp:Label>
            </td>
            <td class="style2" style="width: 206px">
                <asp:TextBox ID="txtUserName" runat="server" Width="197px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtUserName" Display="Dynamic" 
                    ErrorMessage="Please enter Username." ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1" style="width: 326px">
                <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            </td>
            <td class="style2" style="width: 206px">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="197px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtPassword" Display="Dynamic" 
                    ErrorMessage="Please enter Password." ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1" style="width: 326px">
                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:"></asp:Label>
            </td>
            <td class="style2" style="width: 206px">
                <asp:TextBox ID="txtConfirmPassword" runat="server" Width="197px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtConfirmPassword" Display="Dynamic" 
                    ErrorMessage="Please confirm your password." ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1" style="width: 326px">
                <asp:Label ID="lblFullName" runat="server" Text="Full Name:"></asp:Label>
            </td>
            <td class="style2" style="width: 206px">
                <asp:TextBox ID="txtFullName" runat="server" Width="197px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtFullName" Display="Dynamic" 
                    ErrorMessage="Please enter your Fullname." ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1" style="width: 326px">
                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            </td>
            <td class="style2" style="width: 206px">
                <asp:TextBox ID="txtEmail" runat="server" Width="197px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtEmail" Display="Dynamic" 
                    ErrorMessage="Please enter your Email." ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1" style="width: 326px">
                <asp:Label ID="lblContactNumber" runat="server" Text="ContactNumber:"></asp:Label>
            </td>
            <td class="style2" style="width: 206px">
                <asp:TextBox ID="txtContactNumber" runat="server" Width="197px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtContactNumber" Display="Dynamic" 
                    ErrorMessage="Please enter your ContactNumber." ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1" style="width: 326px">
                <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
            </td>
            <td class="style2" style="width: 206px">
                <asp:DropDownList ID="dwGender" runat="server" Width="197px">
                    <asp:ListItem Selected="True" Value="0">Male</asp:ListItem>
                    <asp:ListItem Value="1">Female</asp:ListItem>
                    <asp:ListItem Value="2">Shemale</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="dwGender" Display="Dynamic" 
                    ErrorMessage="Please Select your gender." ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1" style="width: 326px">
                <asp:Label ID="lblDob" runat="server" Text="DOB:"></asp:Label>
            </td>
            <td class="style2" style="width: 206px">
                <asp:TextBox ID="txtDob" runat="server" Width="197px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtDob" Display="Dynamic" 
                    ErrorMessage="Please enter your DOB." ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1" style="width: 326px">
                <asp:Label ID="lblBloodGroup" runat="server" Text="BloodGroup:"></asp:Label>
            </td>
            <td class="style2" style="width: 206px">
                <asp:DropDownList ID="dwBloodGroup" runat="server" Width="197px">
                    <asp:ListItem Value="0">A+</asp:ListItem>
                    <asp:ListItem Value="1">B+</asp:ListItem>
                    <asp:ListItem Value="2" >AB+</asp:ListItem>
                    <asp:ListItem Value="3">O+</asp:ListItem>
                    <asp:ListItem Value="4">A-</asp:ListItem>
                    <asp:ListItem Value="5">B-</asp:ListItem>
                    <asp:ListItem Value="6">AB-</asp:ListItem>
                    <asp:ListItem Value="7">O-</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="dwBloodGroup" Display="Dynamic" 
                    ErrorMessage="Please select your blood group." ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1" style="width: 326px">
                <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
            </td>
            <td class="style2" style="width: 206px">
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="197px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ControlToValidate="txtAddress" Display="Dynamic" 
                    ErrorMessage="Please enter your Address." ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1" style="width: 326px">
                &nbsp;</td>
            <td class="style2" style="width: 206px">
                <asp:Button ID="btnSignUpPat" runat="server" Font-Bold="True" Text="SignUp" 
                    onclick="btnSignUpPat_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </asp:Content>
