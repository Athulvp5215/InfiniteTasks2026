<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuDetails.aspx.cs" Inherits="Assessment1.MenuDetails" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <h2>Menu Details</h2>

    Name: <asp:Label ID="lblName" runat="server" /><br />
    Price: <asp:Label ID="lblPrice" runat="server" /><br />
    Category: <asp:Label ID="lblCategory" runat="server" /><br />
    Description: <asp:Label ID="lblDesc" runat="server" /><br />

</asp:Content>
