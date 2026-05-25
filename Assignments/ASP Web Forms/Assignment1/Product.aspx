<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Assignment1.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Appliances</title>

    <style>
        body {
            font-family: Arial;
            margin: 30px;
        }

        h2 {
            color: darkblue;
        }
    </style>
</head>

<body>
<form id="form1" runat="server">

    <h2>Home Appliances</h2>

    <!-- Dropdown List -->
    <asp:DropDownList
        ID="ddlProducts"
        runat="server"
        AutoPostBack="True"
        OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">

        <asp:ListItem Text="Select Product" Value="" Selected="True"></asp:ListItem>
        <asp:ListItem Text="Fan" Value="fan"></asp:ListItem>
        <asp:ListItem Text="Fridge" Value="fridge"></asp:ListItem>
        <asp:ListItem Text="Washing Machine" Value="washingmachine"></asp:ListItem>

    </asp:DropDownList>

    <br /><br />

    <!-- Image Control -->
    <asp:Image
        ID="imgProduct"
        runat="server"
        Width="250px"
        Height="200px" />

    <br /><br />

    <!-- Button -->
    <asp:Button
        ID="btnPrice"
        runat="server"
        Text="Get Price"
        OnClick="btnPrice_Click" />

    <br /><br />

    <!-- Label -->
    <asp:Label
        ID="lblPrice"
        runat="server"
        Font-Bold="true"
        ForeColor="Green">
    </asp:Label>

</form>
</body>
</html>