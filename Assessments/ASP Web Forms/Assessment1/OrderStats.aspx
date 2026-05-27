<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderStats.aspx.cs" Inherits="Assessment1.OrderStats" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <h2>Application Statistics</h2>


    <p>Total Visitors:
        <asp:Label ID="lblVisitors" runat="server" />
    </p>

    <p>Active Users:
        <asp:Label ID="lblActiveUsers" runat="server" />
    </p>

    <hr />

    
    <h3>Food Category Summary (Cached)</h3>

    <asp:GridView ID="gvCategoryStats" runat="server" AutoGenerateColumns="true">
    </asp:GridView>

</asp:Content>