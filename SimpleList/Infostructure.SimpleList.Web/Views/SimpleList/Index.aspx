<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Infostructure.SimpleList.Web.Models.SimpleListViewModel>>" %>
<%@ Import Namespace="Infostructure.SimpleList.Web.Controllers"%>
<%@ Import Namespace="Microsoft.Web.Mvc"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Your Simple Lists
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lists</h2>
    
    <p>
        <%: Html.ActionLink<SimpleListController>(c => c.Create(), "Create New")%>
    </p>

    <table>
        <tr>
            <th>            
            </th>
            <th>
                Name
            </th>
            <th>
                Date Added
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <a href='<%: Url.Action("Index", "SimpleListItem", new {simpleListId = item.ID}) %>' style="text-decoration: none; outline: none;">
                    <img src='<%: Url.Content("../../Content/Images/Status/Details.png") %>'/> 
                </a>  
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: String.Format("{0:d}", item.DateAdded) %>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

