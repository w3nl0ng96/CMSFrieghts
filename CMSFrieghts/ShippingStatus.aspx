<%@ Page Title="Shipping Status" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShippingStatus.aspx.cs" Inherits="CMSFrieghts.WebForm1" %>

    <%--<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
          var appInsights=window.appInsights||function(a){
            function b(a){c[a]=function(){var b=arguments;c.queue.push(function(){c[a].apply(c,b)})}}var c={config:a},d=document,e=window;setTimeout(function(){var b=d.createElement("script");b.src=a.url||"https://az416426.vo.msecnd.net/scripts/a/ai.0.js",d.getElementsByTagName("script")[0].parentNode.appendChild(b)});try{c.cookie=d.cookie}catch(a){}c.queue=[];for(var f=["Event","Exception","Metric","PageView","Trace","Dependency"];f.length;)b("track"+f.pop());if(b("setAuthenticatedUserContext"),b("clearAuthenticatedUserContext"),b("startTrackEvent"),b("stopTrackEvent"),b("startTrackPage"),b("stopTrackPage"),b("flush"),!a.disableExceptionTracking){f="onerror",b("_"+f);var g=e[f];e[f]=function(a,b,d,e,h){var i=g&&g(a,b,d,e,h);return!0!==i&&c["_"+f](a,b,d,e,h),i}}return c
            }({
                instrumentationKey:"0f5ac089-a103-4931-a00c-270ce6036ac1"
            });
    
          window.appInsights=appInsights,appInsights.queue&&0===appInsights.queue.length&&appInsights.trackPageView();
    </script>
    </asp:Content>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top:20px;">
    <asp:GridView ID="GridView1" runat="server" DataSourceID="CMSFreights" CssClass="table table-striped table-bordered table-condensed"
        AutoGenerateColumns="False" DataKeyNames="shipping_id" Height="119px" Width="1170px" OnRowCommand="GridView1_RowCommand1">
        <Columns>
            <asp:BoundField DataField="shipping_id" HeaderText="shipping_id" InsertVisible="False" ReadOnly="True" SortExpression="shipping_id" />
            <asp:BoundField DataField="shipping_description" HeaderText="shipping_description" SortExpression="shipping_description" />
            <asp:BoundField DataField="ship_type" HeaderText="ship_type" SortExpression="ship_type" />
            <asp:BoundField DataField="container_type" HeaderText="container_type" SortExpression="container_type" />
            <asp:BoundField DataField="request_date" HeaderText="request_date" SortExpression="request_date" />
            <asp:BoundField DataField="departure_port" HeaderText="departure_port" SortExpression="departure_port" />
            <asp:BoundField DataField="arrival_port" HeaderText="arrival_port" SortExpression="arrival_port" />
            <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
            <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
        </Columns>
</asp:GridView>
        </div>
<asp:SqlDataSource ID="CMSFreights" runat="server" ConnectionString="<%$ ConnectionStrings:CMSFrieghts2018DDAC_dbConnectionString %>" SelectCommand="SELECT * FROM [CustomerShipping] where status = 'Pending Approval' OR status = 'Rejected'"></asp:SqlDataSource>
</asp:Content>
