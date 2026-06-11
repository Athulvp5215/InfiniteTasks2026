<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" %>
 
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
 
<div class="container mt-4">
 
    <!-- Header -->
    <div class="mb-4">
        <h2 class="fw-bold text-primary">Claim Insurance</h2>
        <p class="text-muted">Submit your insurance claim easily</p>
    </div>
 
    <!-- Card -->
    <div class="card shadow rounded-4 p-4 mx-auto" style="max-width: 450px;">
 
        <!-- Policy Number -->
        <div class="mb-3">
            <label class="form-label">Policy Number</label>
            <asp:TextBox ID="txtPolicy" runat="server"
                CssClass="form-control"
                placeholder="Enter policy number"></asp:TextBox>
        </div>
 
        <!-- Mobile Number -->
        <div class="mb-3">
            <label class="form-label">Mobile Number</label>
            <asp:TextBox ID="txtMobile" runat="server"
                CssClass="form-control"
                placeholder="Enter mobile number"></asp:TextBox>
        </div>
 
        <!-- Reason Section -->
        <div class="mb-3 text-center">
            <label class="form-label fw-bold">Select Reason</label><br />
 
            <asp:Button ID="btnNatural" runat="server"
                Text="Natural Disaster"
                CssClass="btn btn-secondary m-1 px-3" />
 
            <asp:Button ID="btnManMade" runat="server"
                Text="Man-Made"
                CssClass="btn btn-secondary m-1 px-3" />
 
            <asp:Button ID="btnAccident" runat="server"
                Text="Accident"
                CssClass="btn btn-secondary m-1 px-3" />
 
            <asp:Button ID="btnTheft" runat="server"
                Text="Theft"
                CssClass="btn btn-secondary m-1 px-3" />
        </div>
 
        <!-- Extra Remarks -->
        <div class="mb-3">
            <label class="form-label">Additional Details</label>
            <asp:TextBox ID="txtRemarks" runat="server"
                TextMode="MultiLine"
                Rows="3"
                CssClass="form-control"
                placeholder="Enter additional details"></asp:TextBox>
        </div>
 
        <!-- Submit Button -->
        <div class="d-grid">
            <asp:Button ID="btnSubmit" runat="server"
                Text="Submit Claim"
                CssClass="btn btn-danger" />
        </div>
 
    </div>
 
</div>
 
</asp:Content>
