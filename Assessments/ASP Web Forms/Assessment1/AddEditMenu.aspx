<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditMenu.aspx.cs" Inherits="Assessment1.AddEditMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add / Edit Menu Item</h2>

    
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />

    <table>

        <!-- NAME -->
        <tr>
            <td>Name:</td>
            <td>
                <asp:TextBox ID="txtName" runat="server" />
                
             
                <asp:RequiredFieldValidator 
                    ControlToValidate="txtName"
                    ErrorMessage="Name is required"
                    ForeColor="Red"
                    runat="server" />

              
                <asp:RegularExpressionValidator 
                    ControlToValidate="txtName"
                    ValidationExpression="^[a-zA-Z ]+$"
                    ErrorMessage="Only letters allowed"
                    ForeColor="Red"
                    runat="server" />
            </td>
        </tr>

        <tr>
            <td>Price:</td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server" />

              
                <asp:RequiredFieldValidator 
                    ControlToValidate="txtPrice"
                    ErrorMessage="Price is required"
                    ForeColor="Red"
                    runat="server" />

             
                <asp:RangeValidator 
                    ControlToValidate="txtPrice"
                    MinimumValue="1"
                    MaximumValue="1000"
                    Type="Double"
                    ErrorMessage="Price must be between 1 and 1000"
                    ForeColor="Red"
                    runat="server" />
            </td>
        </tr>

        <tr>
            <td>Category:</td>
            <td>
                <asp:TextBox ID="txtCategory" runat="server" />

                <asp:RequiredFieldValidator 
                    ControlToValidate="txtCategory"
                    ErrorMessage="Category is required"
                    ForeColor="Red"
                    runat="server" />
            </td>
        </tr>

        <tr>
            <td>Description:</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" />

         
                <asp:RequiredFieldValidator 
                    ControlToValidate="txtDescription"
                    ErrorMessage="Description is required"
                    ForeColor="Red"
                    runat="server" />
            </td>
        </tr>

        <tr>
            <td>Confirm Price:</td>
            <td>
                <asp:TextBox ID="txtConfirmPrice" runat="server" />

        
                <asp:CompareValidator 
                    ControlToValidate="txtConfirmPrice"
                    ControlToCompare="txtPrice"
                    ErrorMessage="Prices must match"
                    ForeColor="Red"
                    runat="server" />
            </td>
        </tr>


        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </td>
        </tr>

    </table>

</asp:Content>
