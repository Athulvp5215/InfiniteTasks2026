<%@ Page MasterPageFile="~/Site.Master" Language="C#" %>
 
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="container mt-4">
 
        <!-- Page Title -->
<div class="mb-4">
<h2 class="fw-bold text-primary">Dashboard</h2>
<p class="text-muted">Welcome back! Here's your insurance overview.</p>
</div>
 
        <!-- Cards Row -->
<div class="row g-4">
 
            <!-- Total Policies -->
<div class="col-md-3">
<div class="card text-white bg-primary shadow rounded-4 p-3">
<div class="d-flex justify-content-between align-items-center">
<div>
<h6>Total Policies</h6>
<h2 class="fw-bold">100</h2>
</div>
<i class="fa fa-file fa-2x"></i>
</div>
</div>
</div>
 
            <!-- Active Policies -->
<div class="col-md-3">
<div class="card text-white bg-success shadow rounded-4 p-3">
<div class="d-flex justify-content-between align-items-center">
<div>
<h6>Active Policies</h6>
<h2 class="fw-bold">85</h2>
</div>
<i class="fa fa-check-circle fa-2x"></i>
</div>
</div>
</div>
 
            <!-- Claims -->
<div class="col-md-3">
<div class="card text-white bg-warning shadow rounded-4 p-3">
<div class="d-flex justify-content-between align-items-center">
<div>
<h6>Claims</h6>
<h2 class="fw-bold">12</h2>
</div>
<i class="fa fa-exclamation-triangle fa-2x"></i>
</div>
</div>
</div>
 
            <!-- Expired Policies -->
<div class="col-md-3">
<div class="card text-white bg-danger shadow rounded-4 p-3">
<div class="d-flex justify-content-between align-items-center">
<div>
<h6>Expired</h6>
<h2 class="fw-bold">3</h2>
</div>
<i class="fa fa-times-circle fa-2x"></i>
</div>
</div>
</div>
 
        </div>
 
        <!-- Recent Activity Section -->
<div class="card mt-5 shadow-sm rounded-4">
<div class="card-header bg-white">
<h5 class="mb-0">Recent Activities</h5>
</div>
<div class="card-body">
<ul class="list-group">
<li class="list-group-item">Policy #123 renewed successfully</li>
<li class="list-group-item">New policy purchased (Car Insurance)</li>
<li class="list-group-item">Claim request submitted</li>
</ul>
</div>
</div>
 
    </div>
 
</asp:Content>
 