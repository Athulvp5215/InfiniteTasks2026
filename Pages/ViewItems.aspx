<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" %>
 
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="container mt-4">
 
        <!-- Page Header -->
<div class="mb-4">
<h2 class="fw-bold text-primary">View Policies</h2>
<p class="text-muted">Manage and view all insurance records</p>
</div>
 
        <!-- Card Layout -->
<div class="card shadow rounded-4">
 
            <!-- Card Header -->
<div class="card-header bg-white d-flex justify-content-between align-items-center">
<h5 class="mb-0">Policy List</h5>
 
                <!-- Search Box -->
<asp:TextBox ID="txtSearch" runat="server" CssClass="form-control w-25"

                    placeholder="Search..." />
</div>
 
            <!-- Card Body -->
<div class="card-body">
 
                <asp:GridView ID="GridView1" runat="server"

                    CssClass="table table-hover table-striped text-center"

                    AutoGenerateColumns="False"

                    HeaderStyle-CssClass="table-dark">
 
                    <Columns>
 
                        <asp:BoundField HeaderText="Policy ID" DataField="ID" />
<asp:BoundField HeaderText="Customer Name" DataField="Name" />
<asp:BoundField HeaderText="Category" DataField="Category" />
 
                        <%-- Action Buttons --%>
<asp:TemplateField HeaderText="Actions">
<ItemTemplate>
<asp:Button ID="btnView" runat="server"

                                    Text="View"

                                    CssClass="btn btn-sm btn-info me-1" />
 
                                <asp:Button ID="btnEdit" runat="server"

                                    Text="Edit"

                                    CssClass="btn btn-sm btn-warning me-1" />
 
                                <asp:Button ID="btnDelete" runat="server"

                                    Text="Delete"

                                    CssClass="btn btn-sm btn-danger"

                                    OnClientClick="return confirm('Are you sure you want to delete?');" />
</ItemTemplate>
</asp:TemplateField>
 
                    </Columns>
 
                </asp:GridView>
 
            </div>
</div>
 
    </div>
 
</asp:Content>
 