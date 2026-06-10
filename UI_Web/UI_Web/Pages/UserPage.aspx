<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" %>
 
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
 
<div class="container mt-4">
 
    <!-- Header -->
    <div class="mb-4">
        <h2 class="fw-bold text-primary">User Dashboard</h2>
        <p class="text-muted">View your policy details and take actions</p>
    </div>
 
    <!-- Card -->
    <div class="card shadow rounded-4 p-4 mx-auto" style="max-width: 450px;">
 
        <!-- Policy Details -->
        <div class="mb-3">
            <p><b>Policy Number:</b> <span class="text-primary">#12345</span></p>
            <p><b>Vehicle Model:</b> Hyundai i20</p>
            <p><b>Registration Number:</b> TS09AB1234</p>
            <p><b>Claim Amount:</b> <span class="text-success">₹ 15,000</span></p>
        </div>
 
        <hr />
 
        <!-- Action Buttons -->
        <div class="d-flex justify-content-center gap-3 mt-3">
 
            <asp:Button ID="btnClaim" runat="server"
                Text="Claim"
                CssClass="btn btn-danger px-4" />
 
            <asp:Button ID="btnRenew" runat="server"
                Text="Renew"
                CssClass="btn btn-success px-4" />
 
        </div>
 
    </div>
 
</div>
 
</asp:Content>
 