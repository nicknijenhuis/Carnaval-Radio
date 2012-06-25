<%@ Page Language="C#" AutoEventWireup="true" CodeFile="recentenummers.aspx.cs" Inherits="recenttracks" ValidateRequest="false" %>
<%@ Import Namespace="BlogEngine.Core" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            function loadRecentTenSongs() {
                $.ajax({
                    type: 'POST',
                    contentType: 'application/json',
                    dataType: 'json',
                    url: $('a#CRwebroot').attr('href') + 'RecentSongsService.asmx/RecentSongs',
                    success: function (data) {

                        var songlist = '<ul>';
                        jQuery.each(data.d, function (index, itemData) {
                            songlist += '<li>' + itemData.song;
                            if (index == 0) {

                                songlist += ' <span onclick="OpenStreamPopup();" class="current">[Nu op de radio]</span>';
                            }
                            songlist += '</li>';
                        });
                        songlist += '</ul>';
                        $('#RecentSongs').html(songlist);
                    }
                });
            }
            loadRecentTenSongs();
        });    
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" Runat="Server">
  <div id="page">
        <div id="RecentSongs"></div>
  </div>
</asp:Content>