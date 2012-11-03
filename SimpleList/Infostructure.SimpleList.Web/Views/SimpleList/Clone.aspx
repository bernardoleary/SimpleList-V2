<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Infostructure.SimpleList.Web.Models.SimpleListViewModel>" %>
<%@ Import Namespace="Infostructure.SimpleList.Web.Controllers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Clone
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <%: Html.HiddenFor(model => model.ID)%> 
            <legend>Clone List "<%: Model.Name %>"</legend>

            <div class="editor-label">
                <%: Html.Label("New Name") %>
            </div>
            <div class="editor-field">
                <%: Html.TextBox("NewName")%>
                <%: Html.ValidationMessageFor(model => model.Name)%>                
            </div>
            <div class="editor-label">
                <%: Html.Label("Clone Everything (not just what's not 'Done')?") %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownList("CloneAll", new List<SelectListItem>
                                                          {
                                                              new SelectListItem
                                                                  {
                                                                      Selected = true,
                                                                      Text = "No",
                                                                      Value = "false"
                                                                  },                                                                  
                                                                new SelectListItem
                                                                  {
                                                                      Selected = false,
                                                                      Text = "Yes",
                                                                      Value = "true"
                                                                  }
                                                          })%>             
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

