<%@ Page Language="C#" AutoEventWireup="true" %>
 
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Insurance Login</title>
 
    <!-- Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
 
    <!-- Font Awesome (icons) -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" rel="stylesheet" />
 
    <style>
        body {
            background: linear-gradient(to right, #007bff, #00c6ff);
            height: 100vh;
        }
 
        .login-card {
            border-radius: 15px;
            box-shadow: 0 6px 20px rgba(0,0,0,0.2);
        }
 
        .form-control {
            border-radius: 10px;
        }
 
        .btn-custom {
            border-radius: 10px;
        }
    </style>
</head>
 
<body>
 
<form runat="server">
 
    <div class="d-flex justify-content-center align-items-center vh-100">
 
        <div class="card login-card p-4" style="width: 380px;">
 
            <!-- Title -->
            <div class="text-center mb-3">
                <h3 class="fw-bold text-primary">Insurance Login</h3>
                <p class="text-muted small">Access your policies securely</p>
            </div>
 
            <!-- Email -->
            <div class="mb-3">
                <label class="form-label">Email</label>
                <div class="input-group">
                    <span class="input-group-text">
                        <i class="fa fa-envelope"></i>
                    </span>
                    <asp:TextBox ID="txtEmail" runat="server"
                        CssClass="form-control"
                        placeholder="Enter email"></asp:TextBox>
                </div>
            </div>
 
            <!-- Password -->
            <div class="mb-3">
                <label class="form-label">Password</label>
                <div class="input-group">
                    <span class="input-group-text">
                        <i class="fa fa-lock"></i>
                    </span>
                    <asp:TextBox ID="txtPassword" runat="server"
                        CssClass="form-control"
                        TextMode="Password"
                        placeholder="Enter password"></asp:TextBox>
                </div>
            </div>
 
            <!-- Login Button -->
            <div class="d-grid mb-3">
                <asp:Button ID="btnLogin" runat="server"
                    Text="Login"
                    CssClass="btn btn-primary btn-custom" />
            </div>
 
            <!-- Links -->
            <div class="text-center">
                <a href="ForgotPassword.aspx" class="d-block small">Forgot Password?</a>
                <a href="ResetPassword.aspx" class="d-block small">Reset Password</a>
                <span class="small">New User?</span>
                <a href="Register.aspx" class="fw-bold small"> Register</a>
            </div>
 
        </div>
 
    </div>
 
</form>
 
</body>
</html>