<%@ Page MasterPageFile="~/Site.Master" Language="C#" %>
 
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
 
    <h2 class="text-center">Vehicle Insurance</h2>
 
    <div class="row mt-4">
 
        <!-- Left -->
<div class="col-md-6">
<div class="card p-4 text-center">
<h4>Why Insurance?</h4>
<p>Secure your vehicle and travel with reliable insurance plans.</p>
</div>
</div>
 
        <!-- Right -->
<div class="col-md-6">
<div class="card p-4 text-center">
 
                <a href="BuyInsurance.aspx" class="btn btn-primary m-2">Buy Insurance</a>
<a href="RenewInsurance.aspx" class="btn btn-warning m-2">Renew Insurance</a>
<a href="ClaimInsurance.aspx" class="btn btn-danger m-2">Claim Insurance</a>
<a href="Estimate.aspx" class="btn btn-success m-2">Estimate Insurance</a>
 
            </div>
</div>
 
    </div>
 
</asp:Content>
 