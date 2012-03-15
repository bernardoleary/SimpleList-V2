<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Infostructure.SimpleList.Web.Models.SimpleListViewModel>" %>
<%@ Import Namespace="Infostructure.SimpleList.Web.Controllers"%>
<%@ Import Namespace="Microsoft.Web.Mvc"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Simple List Items for "<%: Model.Name %>"
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h4>List Items</h4>

    <h4><%= Html.ActionLink<SimpleListItemController>(c => c.Create(Model.ID), "Create New Item") %></h4>

    <div class="lines"></div>

    <ul class="list">

    <% foreach (var item in Model.SimpleListItems) { %>
    
        <li>
        <%: Html.ActionLink<SimpleListItemController>(c => c.ToggleDone(Model.ID, item.ID), "Toggle Done")%> -   
        <%: Html.ActionLink<SimpleListItemController>(c => c.Delete(Model.ID, item.ID), "Delete")%> - 
        <%: item.Description %> - 
        <%: item.Done %> - 
        </li>
    
    <% } %>

    </ul>

    

</asp:Content>
