<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" %>
 
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
 
<div class="container mt-4">
 
    <!-- Header -->
    <div class="mb-4">
        <h2 class="fw-bold text-primary">Insurance Estimate</h2>
        <p class="text-muted">Calculate premium for your vehicle instantly</p>
    </div>
 
    <div class="row g-4">
 
        <!-- 4 Wheeler -->
        <div class="col-md-6">
            <div class="card shadow rounded-4 p-4">
 
                <h4 class="text-center text-dark mb-3">4 Wheeler</h4>
 
                <div class="mb-3">
                    <label class="form-label">Car Model</label>
                    <asp:TextBox ID="txtCarModel" runat="server"
                        CssClass="form-control"
                        placeholder="Enter car model"></asp:TextBox>
                </div>
 
                <div class="mb-3">
                    <label class="form-label">Vehicle Age</label>
                    <asp:TextBox ID="txtCarAge" runat="server"
                        CssClass="form-control"
                        placeholder="Enter age"></asp:TextBox>
                </div>
 
                <div class="d-grid">
                    <asp:Button ID="btnCalcCar" runat="server"
                        Text="Calculate Premium"
                        CssClass="btn btn-dark" />
                </div>
 
                <!-- Result -->
                <div class="mt-3 text-center">
                    <asp:Label ID="lblCarResult" runat="server"
                        CssClass="fw-bold text-success"></asp:Label>
                </div>
 
            </div>
        </div>
 
        <!-- 2 Wheeler -->
        <div class="col-md-6">
            <div class="card shadow rounded-4 p-4">
 
                <h4 class="text-center text-dark mb-3">2 Wheeler</h4>
 
                <div class="mb-3">
                    <label class="form-label">Bike Model</label>
                    <asp:TextBox ID="txtBikeModel" runat="server"
                        CssClass="form-control"
                        placeholder="Enter bike model"></asp:TextBox>
                </div>
 
                <div class="mb-3">
                    <label class="form-label">Vehicle Age</label>
                    <asp:TextBox ID="txtBikeAge" runat="server"
                        CssClass="form-control"
                        placeholder="Enter age"></asp:TextBox>
                </div>
 
                <div class="d-grid">
                    <asp:Button ID="btnCalcBike" runat="server"
                        Text="Calculate Premium"
                        CssClass="btn btn-dark" />
                </div>
 
                <!-- Result -->
                <div class="mt-3 text-center">
                    <asp:Label ID="lblBikeResult" runat="server"
                        CssClass="fw-bold text-success"></asp:Label>
                </div>
 
            </div>
        </div>
 
    </div>
 
</div>
 
</asp:Content>
 