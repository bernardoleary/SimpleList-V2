<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.Mvc.HandleErrorInfo>" %>

<asp:Content ID="errorTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Error
</asp:Content>

<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        $^1#!
    </h2>
    <p>
    	<img src="../../Content/Images/Error/facepalm.jpg" />
    </p>
    <p>
        ...an error occurred while processing your request.
    </p>
</asp:Content>
