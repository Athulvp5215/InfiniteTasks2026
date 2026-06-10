<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" %>
 
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
 
<div class="container mt-5">
 
    <!-- Header -->
    <div class="text-center mb-4">
        <h2 class="fw-bold text-primary">Renew Insurance</h2>
        <p class="text-muted">Renew your existing insurance policy easily</p>
    </div>
 
    <!-- Card -->
    <div class="row justify-content-center">
        <div class="col-md-4">
 
            <div class="card shadow rounded-4 p-4">
 
                <!-- Policy Number -->
                <div class="mb-3">
                    <label class="form-label">Policy Number</label>
                    <asp:TextBox ID="txtPolicy" runat="server"
                        CssClass="form-control"
                        placeholder="Enter policy number"></asp:TextBox>
                </div>
 
                <!-- Mobile -->
                <div class="mb-3">
                    <label class="form-label">Mobile Number</label>
                    <asp:TextBox ID="txtMobile" runat="server"
                        CssClass="form-control"
                        placeholder="Enter mobile number"></asp:TextBox>
                </div>
 
                <!-- Email -->
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server"
                        CssClass="form-control"
                        placeholder="Enter email"></asp:TextBox>
                </div>
 
                <!-- Plan Selection -->
                <div class="mb-3 text-center">
                    <label class="form-label fw-bold">Choose Plan</label><br />
 
                    <asp:Button ID="btnThird" runat="server"
                        Text="Third Party"
                        CssClass="btn btn-warning m-1 px-3" />
 
                    <asp:Button ID="btnComprehensive" runat="server"
                        Text="Comprehensive"
                        CssClass="btn btn-warning m-1 px-3" />
                </div>
 
                <!-- Duration -->
                <div class="mb-4 text-center">
                    <label class="form-label fw-bold">Duration</label><br />
 
                    <asp:Button ID="btn1Year" runat="server"
                        Text="1 Year"
                        CssClass="btn btn-success m-1 px-3" />
 
                    <asp:Button ID="btn3Year" runat="server"
                        Text="3 Years"
                        CssClass="btn btn-success m-1 px-3" />
                </div>
 
                <!-- Payment Button -->
                <div class="d-grid">
                    <asp:Button ID="btnPay" runat="server"
                        Text="Make Payment"
                        CssClass="btn btn-primary" />
                </div>
 
            </div>
 
        </div>
    </div>
 
</div>
 
</asp:Content>
