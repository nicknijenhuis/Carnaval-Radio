<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true"
    CodeFile="SocialMedia.aspx.cs" Inherits="SocialMedia" %>

<%@ Register Src="Menu.ascx" TagName="TabMenu" TagPrefix="menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <div class="content-box-outer">
        <div class="content-box-right">
            <menu:TabMenu ID="TabMenu" runat="server" />
        </div>
        <div class="content-box-left">
           <iframe src="http://www.twitterfeed.com" width="100%" height="100%"></iframe>
        </div>
    </div>
    <div class="hulptekst" style="position: absolute; right: 30px; top: 600px; width: 250px;">
        <h3 style="margin-left: 30px;">Hulp</h3>
        <ol>
            <li>Klik op inloggen</li>
            <li>Gebruikersnaam: info@carnaval-radio.nl</li>
            <li>Wachtwoord: standaard (rad...)</li>
            <li>Beheer de feed</li>
        </ol>
    </div>
</asp:Content>
