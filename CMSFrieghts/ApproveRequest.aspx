<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveRequest.aspx.cs" Inherits="CMSFrieghts.ApproveRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top:20px;">
    <asp:GridView ID="ApproveView" runat="server" DataSourceID="CMSFreights" CssClass="table table-striped table-bordered table-condensed"
        AutoGenerateColumns="False" DataKeyNames="shipping_id" Height="119px" Width="1170px" OnRowCommand="ApproveView_RowCommand1">
        <Columns>
            <asp:BoundField DataField="shipping_id" HeaderText="Shipping ID" InsertVisible="False" ReadOnly="True" SortExpression="shipping_id" />
            <asp:BoundField DataField="shipping_description" HeaderText="Description" SortExpression="shipping_description" />
            <asp:BoundField DataField="ship_type" HeaderText="Ship Type" SortExpression="ship_type" />
            <asp:BoundField DataField="container_type" HeaderText="Container Type" SortExpression="container_type" />
            <asp:BoundField DataField="request_date" HeaderText="Request Date" SortExpression="request_date" />
            <asp:BoundField DataField="departure_port" HeaderText="Departure Port" SortExpression="departure_port" />
            <asp:BoundField DataField="arrival_port" HeaderText="Arrival Port" SortExpression="arrival_port" />
            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
            <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price" />
            <asp:ButtonField CommandName="ApproveShipping" Text="Approve" />
            <asp:ButtonField CommandName="RejectShipping" Text="Reject" />
        </Columns>
</asp:GridView>
        </div>
<asp:SqlDataSource ID="CMSFreights" runat="server" ConnectionString="<%$ ConnectionStrings:CMSFrieghts2018DDAC_dbConnectionString %>" SelectCommand="SELECT shipping_id, shipping_description, ship_type, container_type, request_date, departure_port, arrival_port, status, price FROM CustomerShipping WHERE (status = 'Approved') OR (status = 'Pending Approval') OR (status = 'Rejected')"></asp:SqlDataSource>
</asp:Content>
