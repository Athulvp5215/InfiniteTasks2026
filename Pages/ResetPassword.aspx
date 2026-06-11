<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" %>
 
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
 
<div class="container mt-5">
 
    <!-- Header -->
    <div class="text-center mb-4">
        <h2 class="fw-bold text-primary">Reset Password</h2>
        <p class="text-muted">Update your password securely</p>
    </div>
 
    <!-- Center Card -->
    <div class="row justify-content-center">
        <div class="col-md-4">
 
            <div class="card shadow rounded-4 p-4">
 
                <h5 class="text-center mb-3">Reset Your Password</h5>
 
                <!-- Email -->
                <div class="mb-3">
                    <label class="form-label">Email ID</label>
                    <asp:TextBox ID="txtEmail" runat="server"
                        CssClass="form-control"
                        placeholder="Enter email"></asp:TextBox>
                </div>
 
                <!-- New Password -->
                <div class="mb-3">
                    <label class="form-label">New Password</label>
                    <asp:TextBox ID="txtNewPassword" runat="server"
                        TextMode="Password"
                        CssClass="form-control"
                        placeholder="Enter new password"></asp:TextBox>
                </div>
 
                <!-- Confirm Password -->
                <div class="mb-3">
                    <label class="form-label">Confirm Password</label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server"
                        TextMode="Password"
                        CssClass="form-control"
                        placeholder="Confirm password"></asp:TextBox>
                </div>
 
                <!-- Button -->
                <div class="d-grid mt-2">
                    <asp:Button ID="btnReset" runat="server"
                        Text="Reset Password"
                        CssClass="btn btn-success" />
                </div>
 
                <!-- Back Link -->
                <div class="text-center mt-3">
                    <a href="Login.aspx" class="small">Back to Login</a>
                </div>
 
            </div>
 
        </div>
    </div>
 
</div>
 
</asp:Content>
