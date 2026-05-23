<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Assignment1.Validator" %>
 
<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Validator Form</title>
 
    <style>
        body {
            font-family: Arial;
        }
 
        table {
            margin-top: 30px;
        }
 
        td {
            padding: 8px;
        }
 
        .error {
            color: red;
        }
</style>
</head>
 
<body>
<form id="form1" runat="server">
 
        <h2>Insert your details</h2>
 
        <table border="0">
 
            <!-- Name -->
<tr>
<td>Name :</td>
 
                <td>
<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
</td>
 
                <td>
<asp:RequiredFieldValidator
                        ID="rfvName"
                        runat="server"
                        ControlToValidate="txtName"
                        ErrorMessage="Name required"
                        CssClass="error">
</asp:RequiredFieldValidator>
</td>
</tr>
 
            <!-- Family Name -->
<tr>
<td>Family Name :</td>
 
                <td>
<asp:TextBox ID="txtFamily" runat="server"></asp:TextBox>
</td>
 
                <td>
 
                    <asp:RequiredFieldValidator
                        ID="rfvFamily"
                        runat="server"
                        ControlToValidate="txtFamily"
                        ErrorMessage="Family name required"
                        CssClass="error">
</asp:RequiredFieldValidator>
 
                    <br />
 
                    <asp:CompareValidator
                        ID="cvNameFamily"
                        runat="server"
                        ControlToValidate="txtFamily"
                        ControlToCompare="txtName"
                        Operator="NotEqual"
                        Type="String"
                        ErrorMessage="Family name must differ from Name"
                        CssClass="error">
</asp:CompareValidator>
 
                </td>
</tr>
 
            <!-- Address -->
<tr>
<td>Address :</td>
 
                <td>
<asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
</td>
 
                <td>
<asp:RegularExpressionValidator
                        ID="revAddress"
                        runat="server"
                        ControlToValidate="txtAddress"
                        ValidationExpression="^.{2,}$"
                        ErrorMessage="Address must contain at least 2 characters"
                        CssClass="error">
</asp:RegularExpressionValidator>
</td>
</tr>
 
            <!-- City -->
<tr>
<td>City :</td>
 
                <td>
<asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
</td>
 
                <td>
<asp:RegularExpressionValidator
                        ID="revCity"
                        runat="server"
                        ControlToValidate="txtCity"
                        ValidationExpression="^.{2,}$"
                        ErrorMessage="City must contain at least 2 characters"
                        CssClass="error">
</asp:RegularExpressionValidator>
</td>
</tr>
 
            <!-- Zip Code -->
<tr>
<td>Zip Code :</td>
 
                <td>
<asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
</td>
 
                <td>
<asp:RegularExpressionValidator
                        ID="revZip"
                        runat="server"
                        ControlToValidate="txtZip"
                        ValidationExpression="^\d{5}$"
                        ErrorMessage="Zip code must be 5 digits"
                        CssClass="error">
</asp:RegularExpressionValidator>
</td>
</tr>
 
            <!-- Phone -->
<tr>
<td>Phone :</td>
 
                <td>
<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
</td>
 
                <td>
<asp:RegularExpressionValidator
                        ID="revPhone"
                        runat="server"
                        ControlToValidate="txtPhone"
                        ValidationExpression="^(\d{2}-\d{7}|\d{3}-\d{7})$"
                        ErrorMessage="Format: XX-XXXXXXX or XXX-XXXXXXX"
                        CssClass="error">
</asp:RegularExpressionValidator>
</td>
</tr>
 
            <!-- Email -->
<tr>
<td>E-Mail :</td>
 
                <td>
<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
</td>
 
                <td>
<asp:RegularExpressionValidator
                        ID="revEmail"
                        runat="server"
                        ControlToValidate="txtEmail"
                        ValidationExpression="\w+([-\+.'']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ErrorMessage="Invalid Email"
                        CssClass="error">
</asp:RegularExpressionValidator>
</td>
</tr>
 
            <!-- Button -->
<tr>
<td colspan="2">
 
                    <asp:Button
                        ID="btnCheck"
                        runat="server"
                        Text="Check"
                        OnClick="btnCheck_Click" />
 
                </td>
</tr>
 
            <!-- Success Message -->
<tr>
<td colspan="3">
 
                    <asp:Label
                        ID="lblMessage"
                        runat="server"
                        ForeColor="Green"
                        Font-Bold="true">
</asp:Label>
 
                </td>
</tr>
 
            <!-- Validation Summary -->
<tr>
<td colspan="3">
 
                    <asp:ValidationSummary
                        ID="ValidationSummary1"
                        runat="server"
                        HeaderText="Validation Errors"
                        CssClass="error" />
 
                </td>
</tr>
 
        </table>
 
    </form>
</body>
</html>