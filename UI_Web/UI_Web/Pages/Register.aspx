<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" %>
 
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
 
<div class="container mt-5">
 
    <!-- Header -->
    <div class="text-center mb-4">
        <h2 class="fw-bold text-primary">User Registration</h2>
        <p class="text-muted">Create your account to access insurance services</p>
    </div>
 
    <!-- Card -->
    <div class="row justify-content-center">
        <div class="col-md-5">
 
            <div class="card shadow rounded-4 p-4">
 
                <!-- Name -->
                <div class="mb-3">
                    <label class="form-label">Full Name</label>
                    <asp:TextBox ID="txtName" runat="server"
                        CssClass="form-control"
                        placeholder="Enter your name"></asp:TextBox>
                </div>
 
                <!-- Email -->
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server"
                        CssClass="form-control"
                        placeholder="Enter email"></asp:TextBox>
                </div>
 
                <!-- Date of Birth -->
                <div class="mb-3">
                    <label class="form-label">Date of Birth</label>
                    <asp:TextBox ID="txtDOB" runat="server"
                        TextMode="Date"
                        CssClass="form-control"></asp:TextBox>
                </div>
 
                <!-- Contact -->
                <div class="mb-3">
                    <label class="form-label">Contact Number</label>
                    <asp:TextBox ID="txtContact" runat="server"
                        CssClass="form-control"
                        placeholder="Enter contact number"></asp:TextBox>
                </div>
 
                <!-- Address -->
                <div class="mb-3">
                    <label class="form-label">Address</label>
                    <asp:TextBox ID="txtAddress" runat="server"
                        TextMode="MultiLine"
                        Rows="2"
                        CssClass="form-control"
                        placeholder="Enter your address"></asp:TextBox>
                </div>
 
                <!-- Password -->
                <div class="mb-3">
                    <label class="form-label">Password</label>
                    <asp:TextBox ID="txtPassword" runat="server"
                        TextMode="Password"
                        CssClass="form-control"
                        placeholder="Enter password"></asp:TextBox>
                </div>
 
                <!-- Confirm Password -->
                <div class="mb-3">
                    <label class="form-label">Confirm Password</label>
                    <asp:TextBox ID="txtConfirm" runat="server"
                        TextMode="Password"
                        CssClass="form-control"
                        placeholder="Confirm password"></asp:TextBox>
                </div>
 
                <!-- Submit -->
                <div class="d-grid">
                    <asp:Button ID="btnSubmit" runat="server"
                        Text="Register"
                        CssClass="btn btn-primary" />
                </div>
 
                <!-- Link -->
                <div class="text-center mt-3">
                    <span class="small">Already have an account?</span>
                    <a href="Login.aspx" class="fw-bold small"> Login</a>
                </div>
 
            </div>
 
        </div>
    </div>
 
</div>
 
</asp:Content>
 