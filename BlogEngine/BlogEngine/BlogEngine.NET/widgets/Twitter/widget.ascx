<%@ Control Language="C#" AutoEventWireup="true" CodeFile="widget.ascx.cs" Inherits="Widgets.Twitter.Widget" %>
<div style="max-height:300px; overflow-y: scroll; overflow-x: hidden;">
<asp:Repeater runat="server" ID="repItems" OnItemDataBound="RepItemsItemDataBound">
  <ItemTemplate>
    <div class="Tweet">
        <div class="TweetImage"><asp:image runat="server" ID="twtImg" /></div>
        <div class="TweetDate"><asp:Label runat="server" ID="lblDate" style="color:gray" /></div>
        <div class="TweetText"><asp:Label runat="server" ID="lblItem" /></div>
    </div>
  </ItemTemplate>
</asp:Repeater>
</div>
<asp:HyperLink runat="server" ID="hlTwitterAccount" Text="Follow me on Twitter" />
