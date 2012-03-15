<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About Us
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>About</h2>
    <p>
    	Hello there -
    </p>
    <p>
        Welcome to SimpleList - a very simple, "to-do list" application. Please feel free to sign-up and use it as you see fit.
    </p>
    <p>
	Use it to keep track of things that you need to do, as a distributed shopping list, or whatever you like.
    </p>
    <p>
    	The Android (2.2) client can be downloaded by going to <a href="http://www.infostructure.co.nz/SimpleList/Client/SimpleList.apk" target="_blank">this link...</a>
    </p>
    <p>
	I welcome your feedback. Email it to me on "bernard dot oleary at gmail dot com".
    </p>
    <p>
    	The app will continue to be developed and updated, for the foreseeable future. It is free for anyone to use.
    </p>
    <p>
    	Enjoy!
    </p>
</asp:Content>
