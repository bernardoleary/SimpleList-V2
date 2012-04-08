<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Infostructure.SimpleList.Web.Models.SimpleListViewModel>" %>
<%@ Import Namespace="Infostructure.SimpleList.Web.Controllers"%>
<%@ Import Namespace="Microsoft.Web.Mvc"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	NewList
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Create New List</legend>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <p>
                <input type="submit" value="Go!" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink<SimpleListController>(c => c.Index(), "Back to Lists") %>
    </div>

</asp:Content>

