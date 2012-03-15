<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Infostructure.SimpleList.Web.Controllers"%>
<%@ Import Namespace="Microsoft.Web.Mvc"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Simple List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <% if (Request.IsAuthenticated) { %> 

        <p>
            <%= Html.ActionLink<SimpleListController>(c => c.Index(), "Your lists...")%>
        </p>
    
    <% } %>
    <% else { %> 

        <p>
            Please log in to see your lists.
        </p>

    <% } %>

</asp:Content>
