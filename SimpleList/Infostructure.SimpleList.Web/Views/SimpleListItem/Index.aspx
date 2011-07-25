<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Infostructure.SimpleList.DataModel.Models.SimpleList>" %>
<%@ Import Namespace="Infostructure.SimpleList.Web.Controllers"%>
<%@ Import Namespace="Microsoft.Web.Mvc"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ListItems</h2>

    <table>
        <tr>
            <th></th>
            <th>
                ID
            </th>
            <th>
                SimpleListID
            </th>
            <th>
                Description
            </th>
            <th>
                Done
            </th>
        </tr>

    <% foreach (var item in Model.SimpleListItems) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink<SimpleListItemController>(c => c.Edit(item.ID), "Edit") %> |
                <%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%> |
                <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>
            </td>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.SimpleListID %>
            </td>
            <td>
                <%: item.Description %>
            </td>
            <td>
                <%: item.Done %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink<SimpleListItemController>(c => c.Create(Model.ID), "Create New") %>
    </p>

</asp:Content>
