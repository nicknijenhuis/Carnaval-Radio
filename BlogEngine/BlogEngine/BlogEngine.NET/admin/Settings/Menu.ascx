﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="admin.Settings.Menu" %>
<ul>
    <li <%=Current("Main.aspx")%>><a href="Main.aspx"><%=Resources.labels.basic %></a></li>
    <li <%=Current("Advanced.aspx")%>><a href="Advanced.aspx"><%=Resources.labels.advanced %></a></li>
    <li <%=Current("Feed.aspx")%>><a href="Feed.aspx"><%=Resources.labels.feed %></a></li>
    <li <%=Current("Picasa.aspx")%>><a href="Picasa.aspx"><%=Resources.labels.PhotoAlbums %></a></li>
    <li <%=Current("AudioStream.aspx")%>><a href="AudioStream.aspx"><%=Resources.labels.AudioStream %></a></li>

    <li <%=Current("Email.aspx")%>><a href="Email.aspx"><%=Resources.labels.email %></a></li>
    <li <%=Current("Themes.cshtml")%>><a href="Themes.cshtml"><%=Resources.labels.themes %></a></li>
    <li <%=Current("Comments.aspx")%>><a href="Comments.aspx"><%=Resources.labels.comments %></a></li>
    <li <%=Current("SocialMedia.aspx")%>><a href="SocialMedia.aspx">
        <%=Resources.labels.SocialMedia %></a></li>
    <li <%=Current("Shoutbox.aspx")%>><a href="Shoutbox.aspx">Shoutbox</a></li>
    <li <%=Current("Bovenhoek.aspx")%>><a href="Bovenhoek.aspx">Bovenhoek</a></li>
    <!--
    <li <%=Current("HeadTrack.aspx")%>><a href="HeadTrack.aspx"><%=Resources.labels.customCode %></a></li>

    <li <%=Current("Rules.aspx")%>><a href="Rules.aspx"><%=Resources.labels.rules %> & <%=Resources.labels.filters %></a></li>
    <li <%=Current("PingServices.aspx")%>><a href="PingServices.aspx"><%=Resources.labels.pingService %></a></li>
    <li <%=Current("Import.aspx")%>><a href="Import.aspx"><%=Resources.labels.import %> & <%=Resources.labels.export %></a></li>-->
</ul>
