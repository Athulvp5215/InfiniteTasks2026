<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" %>
 
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="container mt-4">
 
        <!-- Header -->
<div class="mb-4">
<h2 class="fw-bold text-primary">Add Policy</h2>
<p class="text-muted">Create a new insurance policy</p>
</div>
 
        <!-- Card -->
<div class="card shadow p-4 rounded">
 
            <!-- Name -->
<div class="mb-3">
<label class="form-label">Customer Name</label>
<asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
</div>
 
            <!-- Category -->
<div class="mb-3">
<label class="form-label">Policy Type</label>
<asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-select">
<asp:ListItem Text="Select Policy" Value="" />
<asp:ListItem Text="Car Insurance" Value="Car" />
<asp:ListItem Text="Bike Insurance" Value="Bike" />
<asp:ListItem Text="Travel Insurance" Value="Travel" />
</asp:DropDownList>
</div>
 
            <!-- Description -->
<div class="mb-3">
<label class="form-label">Description</label>
<asp:TextBox ID="txtDescription" runat="server"

                    TextMode="MultiLine"

                    CssClass="form-control"

                    Rows="3"></asp:TextBox>
</div>
 
            <!-- Amount -->
<div class="mb-3">
<label class="form-label">Premium Amount</label>
<asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>
</div>
 
            <!-- Buttons -->
<div class="mt-3">
<asp:Button ID="btnSave" runat="server"

                    Text="Save"

                    CssClass="btn btn-success" />
 
                <asp:Button ID="btnReset" runat="server"

                    Text="Reset"

                    CssClass="btn btn-secondary ms-2" />
</div>
 
        </div>
 
    </div>
 
</asp:Content> 
 