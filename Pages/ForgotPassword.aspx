<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" %>
 
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
 
<div class="container mt-5">
 
    <!-- Header -->
    <div class="text-center mb-4">
        <h2 class="fw-bold text-primary">Forgot Password</h2>
        <p class="text-muted">Enter your email to reset your password</p>
    </div>
 
    <!-- Centered Card -->
    <div class="row justify-content-center">
 
        <div class="col-md-4">
 
            <div class="card shadow rounded-4 p-4">
 
                <!-- Email -->
                <div class="mb-3">
                    <label class="form-label">Email ID</label>
                    <asp:TextBox ID="txtEmail" runat="server"
                        CssClass="form-control"
                        placeholder="Enter email"></asp:TextBox>
                </div>
 
                <!-- Captcha -->
                <div class="mb-3">
                    <label class="form-label">Captcha</label>
                    <asp:TextBox ID="txtCaptcha" runat="server"
                        CssClass="form-control"
                        placeholder="Enter captcha"></asp:TextBox>
                </div>
 
                <!-- Submit Button -->
                <div class="d-grid">
                    <asp:Button ID="btnSubmit" runat="server"
                        Text="Submit"
                        CssClass="btn btn-primary" />
                </div>
 
                <!-- Links -->
                <div class="text-center mt-3">
                    <a href="Login.aspx" class="small">Back to Login</a>
                </div>
 
            </div>
 
        </div>
 
    </div>
 
</div>
 
</asp:Content>
 