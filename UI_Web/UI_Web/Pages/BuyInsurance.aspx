<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" %>
 
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
 
<div class="container mt-4">
 
    <!-- Header -->
    <div class="mb-4">
        <h2 class="fw-bold text-primary">Buy Insurance</h2>
        <p class="text-muted">Choose your vehicle and enter details</p>
    </div>
 
    <!-- Card -->
    <div class="card shadow rounded-4 p-4">
 
        <!-- Vehicle Selection -->
        <div class="mb-4 text-center">
            <label class="form-label fw-bold">Select Vehicle Type</label><br />
            <asp:Button ID="btnFour" runat="server"
                Text="4 Wheeler"
                CssClass="btn btn-primary m-2 px-4" />
 
            <asp:Button ID="btnTwo" runat="server"
                Text="2 Wheeler"
                CssClass="btn btn-secondary m-2 px-4" />
        </div>
 
        <!-- Vehicle Details -->
        <div class="row">
 
            <div class="col-md-6 mb-3">
                <label class="form-label">Manufacturer</label>
                <asp:TextBox ID="txtManufacturer" runat="server"
                    CssClass="form-control"
                    placeholder="Enter manufacturer"></asp:TextBox>
            </div>
 
            <div class="col-md-6 mb-3">
                <label class="form-label">Model</label>
                <asp:TextBox ID="txtModel" runat="server"
                    CssClass="form-control"
                    placeholder="Enter model"></asp:TextBox>
            </div>
 
            <div class="col-md-6 mb-3">
                <label class="form-label">Driving License</label>
                <asp:TextBox ID="txtDL" runat="server"
                    CssClass="form-control"
                    placeholder="Enter license number"></asp:TextBox>
            </div>
 
            <div class="col-md-6 mb-3">
                <label class="form-label">Purchase Date</label>
                <asp:TextBox ID="txtDate" runat="server"
                    CssClass="form-control"
                    TextMode="Date"></asp:TextBox>
            </div>
 
            <div class="col-md-6 mb-3">
                <label class="form-label">Registration Number</label>
                <asp:TextBox ID="txtReg" runat="server"
                    CssClass="form-control"
                    placeholder="Enter registration number"></asp:TextBox>
            </div>
 
            <div class="col-md-6 mb-3">
                <label class="form-label">Engine Number</label>
                <asp:TextBox ID="txtEngine" runat="server"
                    CssClass="form-control"
                    placeholder="Enter engine number"></asp:TextBox>
            </div>
 
            <div class="col-md-6 mb-3">
                <label class="form-label">Chassis Number</label>
                <asp:TextBox ID="txtChassis" runat="server"
                    CssClass="form-control"
                    placeholder="Enter chassis number"></asp:TextBox>
            </div>
 
        </div>
 
        <hr />
 
        <!-- Plan Selection -->
        <div class="mb-3">
            <label class="form-label fw-bold">Choose Plan</label><br />
 
            <asp:Button ID="btnThird" runat="server"
                Text="Third Party"
                CssClass="btn btn-info m-1 px-4 text-white" />
 
            <asp:Button ID="btnComp" runat="server"
                Text="Comprehensive"
                CssClass="btn btn-info m-1 px-4 text-white" />
        </div>
 
        <!-- Duration -->
        <div class="mb-4">
            <label class="form-label fw-bold">Select Duration</label><br />
 
            <asp:Button ID="btn1Year" runat="server"
                Text="1 Year"
                CssClass="btn btn-success m-1 px-4" />
 
            <asp:Button ID="btn3Year" runat="server"
                Text="3 Years"
                CssClass="btn btn-success m-1 px-4" />
        </div>
 
        <!-- Payment Button -->
        <div class="text-center">
            <asp:Button ID="btnPay" runat="server"
                Text="Make Payment"
                CssClass="btn btn-primary px-5" />
        </div>
 
    </div>
 
</div>
 
</asp:Content>
