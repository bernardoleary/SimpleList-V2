﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Infostructure.SimpleList.Web.Models.SimpleListViewModel>" %>
<%@ Import Namespace="Infostructure.SimpleList.Web.Controllers"%>
<%@ Import Namespace="Microsoft.Web.Mvc"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Simple List Items for "<%: Model.Name %>"
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
                <%: Html.ActionLink<SimpleListItemController>(c => c.ToggleDone(Model.ID, item.ID), "Toggle Done")%> |       
                <!-- <%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%> | -->
                <%: Html.ActionLink<SimpleListItemController>(c => c.Delete(Model.ID, item.ID), "Delete")%>
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
        <%= Html.ActionLink<SimpleListItemController>(c => c.Create(Model.ID), "Create New Item") %>
    </p>

</asp:Content>
