<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" %>
 
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
 
<div class="container mt-4">
 
    <!-- Header -->
    <div class="mb-4">
        <h2 class="fw-bold text-primary">Claim History</h2>
        <p class="text-muted">View all your insurance claims</p>
    </div>
 
    <!-- Card -->
    <div class="card shadow rounded-4">
 
        <!-- Card Header -->
        <div class="card-header bg-white d-flex justify-content-between align-items-center">
            <h5 class="mb-0">Claims List</h5>
 
            <!-- Optional Search -->
            <asp:TextBox ID="txtSearch" runat="server"
                CssClass="form-control w-25"
                placeholder="Search claims"></asp:TextBox>
        </div>
 
        <!-- Table -->
        <div class="card-body">
 
            <asp:GridView ID="GridView1" runat="server"
                CssClass="table table-hover table-striped text-center"
                AutoGenerateColumns="False"
                HeaderStyle-CssClass="table-dark">
 
                <Columns>
 
                    <asp:BoundField HeaderText="Claim No" DataField="ClaimNo" />
                    <asp:BoundField HeaderText="Date" DataField="Date" />
                    <asp:BoundField HeaderText="Status" DataField="Status" />
                    <asp:BoundField HeaderText="Amount (₹)" DataField="Amount" />
 
                    <%-- Action Column --%>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnView" runat="server"
                                Text="View"
                                CssClass="btn btn-sm btn-info me-1" />
 
                            <asp:Button ID="btnDelete" runat="server"
                                Text="Delete"
                                CssClass="btn btn-sm btn-danger"
                                OnClientClick="return confirm('Are you sure?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
 
                </Columns>
 
            </asp:GridView>
 
        </div>
 
    </div>
 
</div>
 
</asp:Content>
 