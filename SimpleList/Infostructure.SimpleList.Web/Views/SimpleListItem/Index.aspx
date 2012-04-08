<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Infostructure.SimpleList.Web.Models.SimpleListViewModel>" %>
<%@ Import Namespace="Infostructure.SimpleList.Web.Controllers"%>
<%@ Import Namespace="Microsoft.Web.Mvc"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Simple List Items for "<%: Model.Name %>"
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List Items for "<%= Html.Encode(Model.Name) %>" </h2>

    <p>
        <%= Html.ActionLink<SimpleListItemController>(c => c.Create(Model.ID), "Create New Item") %>
    </p>

    <table>
        <tr>
            <th>            
            </th>
            <th>
                Description
            </th>
        </tr>

    <% foreach (var item in Model.SimpleListItems) { %>
    
        <tr>
            <td>
                <% if(item.Done) { %>
                    <a href='<%: Url.Action("ToggleDone", "SimpleListItem", new {simpleListId = item.SimpleListID, simpleListItemId = item.ID}) %>' style="text-decoration: none; outline: none;">
                        <img src='<%: Url.Content("../../Content/Images/Status/Tick.png") %>'/> 
                    </a>
                <% } else { %>
                    <a href='<%: Url.Action("ToggleDone", "SimpleListItem", new {simpleListId = item.SimpleListID, simpleListItemId = item.ID}) %>' style="text-decoration: none; outline: none;">
                        <img src='<%: Url.Content("../../Content/Images/Status/NotDone.png") %>'/> 
                    </a>
                <% } %>
                <a href='<%: Url.Action("Delete", "SimpleListItem", new {simpleListId = item.SimpleListID, simpleListItemId = item.ID}) %>' style="text-decoration: none; outline: none;">
                    <img src='<%: Url.Content("../../Content/Images/Status/Cross.png") %>'/> 
                </a>       
            </td>
            <td> 
                <%: item.Description %>
            </td>
        </tr>
    
    <% } %>

    </table>    

</asp:Content>
