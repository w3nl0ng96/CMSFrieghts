<%@ Page Title="Add New Shipping Request" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewShipping.aspx.cs" Inherits="CMSFrieghts.AddNewShipping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal" style="margin-top:-270px;">
        <h3><%: Title %></h3>
        <hr />
    </div>
    <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="DeparturePort" CssClass="col-md-2 control-label">Departure Port</asp:Label>
            <div class="col-md-10" style="margin-bottom:10px;">
                <asp:DropDownList ID="DeparturePort" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DeparturePort_SelectedIndexChanged" runat="server" DataSourceID="PortsDS" DataTextField="port_name" DataValueField="port_price" >
                    <asp:ListItem Value="" Selected="True" Text="Please Select Departure Port..."></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="PortsDS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT port_name, price as port_price FROM Port"></asp:SqlDataSource>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DeparturePort"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Required Field!" />
            </div>
        </div>
    <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ArrivalPort" CssClass="col-md-2 control-label">Arrival Port</asp:Label>
            <div class="col-md-10" style="margin-bottom:10px;">
                <asp:DropDownList ID="ArrivalPort" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ArrivalPort_SelectedIndexChanged" runat="server" DataSourceID="PortsDS" DataTextField="port_name" DataValueField="port_price" >
                    <asp:ListItem Value="" Selected="True" Text="Please Select Arrival Port..."></asp:ListItem>
                </asp:DropDownList>
                 <asp:CompareValidator runat="server" ControlToCompare="DeparturePort" ControlToValidate="ArrivalPort" CssClass="text-danger" Display="Dynamic" Operator="NotEqual" ErrorMessage="Unable to select same port!" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ArrivalPort"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Required Field!" />
            </div>
        </div>
    <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ShipType" CssClass="col-md-2 control-label">Ship Type</asp:Label>
            <div class="col-md-10" style="margin-bottom:10px;">
                <asp:DropDownList ID="ShipType" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ShipType_SelectedIndexChanged" runat="server" DataSourceID="ShipsDS" DataTextField="ship_name" DataValueField="ship_price" >
                    <asp:ListItem Value="" Selected="True" Text="Please Select Ship Type..."></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="ShipsDS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT ship_name, price as ship_price FROM Ship"></asp:SqlDataSource>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ShipType"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Required Field!" />
            </div>
        </div>
    <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ContainerType" CssClass="col-md-2 control-label">Container Type</asp:Label>
            <div class="col-md-10" style="margin-bottom:10px;">
                <asp:DropDownList ID="ContainerType" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ContainerType_SelectedIndexChanged" runat="server" DataSourceID="ContainerDS" DataTextField="container_name" DataValueField="container_price" >
                    <asp:ListItem Value="" Selected="True" Text="Please Select Container Type..."></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="ContainerDS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT container_name, price as container_price FROM Container"></asp:SqlDataSource>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ContainerType"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Required Field!" />
            </div>
        </div>
     <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="estimatedPrice" CssClass="col-md-2 control-label">Price(RM)</asp:Label>
            <div class="col-md-10" style="margin-bottom:10px;">
                <asp:TextBox runat="server" ID="estimatedPrice" Text="0.00" CssClass="form-control" Enabled="False" />
            </div>
        </div>
    <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="description" CssClass="col-md-2 control-label">Description</asp:Label>
            <div class="col-md-10" style="margin-bottom:10px;">
                <asp:TextBox runat="server" ID="description" TextMode="MultiLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="description" 
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Required Field!" />
            </div>
        </div>
    <div class="form-group">
        <div>
            <asp:Button runat="server" Text="Add New Shipping" style="margin-left:210px;margin-top:10px;" CssClass="btn btn-default"  OnClick="Add_Click" />
        </div>
    </div>

</asp:Content>
