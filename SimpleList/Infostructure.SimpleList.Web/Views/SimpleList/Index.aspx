<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Infostructure.SimpleList.DataModel.SimpleList>>" %>
<%@ Import Namespace="Infostructure.SimpleList.Web.Controllers"%>
<%@ Import Namespace="Microsoft.Web.Mvc"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: ViewData["Message"] %></h2>    

    <h2>Lists</h2>

    <table>
        <tr>
            <th></th>
            <th>
                ID
            </th>
            <th>
                UserID
            </th>
            <th>
                Name
            </th>
            <th>
                DateAdded
            </th>
            <th>
                AllDone
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ })%> |
                <%: Html.ActionLink<SimpleListItemController>(c => c.Index(item.ID), "Details")%> |
                <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>
            </td>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.UserID %>
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.DateAdded) %>
            </td>
            <td>
                <%: item.AllDone %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink<SimpleListController>(c => c.Create(), "Create New")%>
    </p>

</asp:Content>

