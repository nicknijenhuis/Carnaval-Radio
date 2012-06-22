<%@ Page Language="C#" AutoEventWireup="true" CodeFile="audioplayer.aspx.cs" Inherits="widgets_AudioPlayer_audioplayer" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Carnaval Radio Audio Player</title>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" type="text/javascript"></script>    
    <script src="Scripts/AudioPlayer.js" type="text/javascript"></script>
    <link href="themes/CarnavalRadio/styles/smoothDivScroll.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        setInterval(loadRecentSongs, 60000);

        function loadRecentSongs() {
            $.ajax({
                type: 'POST',
                contentType: 'application/json',
                dataType: 'json',
                url: 'RecentSongsService.asmx/RecentSongs',
                success: function (data) {
                    $('#currentsong').html(data.d[0].song);
                }
            });
        }
        loadRecentSongs();
    
    </script>
</head>
<body>
<div id="player-content">
        <div id="sponsor-top-left"><asp:Image runat="server" ID="sponsorTopLeft" /></div>
        <div id="sponsor-top-right"><asp:Image runat="server" ID="sponsorTopRight" /></div>

        
        <div id="player-container">
            <p>Huidig nummer:</p>
            <p id="currentsong"></p>
            <div id="player"></div>
        </div>
        <script type="text/javascript">$('player').ready(loadStream('<%=stream %>'));</script>
        
        <div style="display:none;">
        <img src="pics/audioplayer/download.png" id="dlimg" alt="Download" onclick="toggleDownload();" />
        <div id="dltab" style="display:none;">
            <img src="pics/audioplayer/winamp.png" alt="Winamp" onclick="download('<%=streamFiles[0] %>');" />
            <img src="pics/audioplayer/wmp.png" alt="Windows Media Player" onclick="download('<%=streamFiles[1] %>');" />
        </div>
        </div>

    <div id="artist-left"></div>
    <div id="artist-right"></div>
    <div id="artist-above-player"></div>
    <div id="logo"></div>
</div>
<div id="player-footer">
    <div id="sponsors">
<asp:Literal runat="server" ID="litSwitchingSponsors" />
    </div>
</div>
    <script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.8.18/jquery-ui.min.js" type="text/javascript"></script>
    <script src="themes/CarnavalRadio/js/player/jquery.mousewheel.min.js" type="text/javascript"></script>
    <script src="themes/CarnavalRadio/js/player/jquery.smoothdivscroll-1.2-min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#sponsors").smoothDivScroll({
                autoScrollingMode: "always",
                autoScrollingDirection: "endlessloopright",
                autoScrollingStep: 1,
                autoScrollingInterval: 25
            });

            // Logo parade event handlers
            $("#sponsors").bind("mouseover", function () {
                $(this).smoothDivScroll("stopAutoScrolling");
            }).bind("mouseout", function () {
                $(this).smoothDivScroll("startAutoScrolling");
            });

        });
    </script>
</body>
</html>