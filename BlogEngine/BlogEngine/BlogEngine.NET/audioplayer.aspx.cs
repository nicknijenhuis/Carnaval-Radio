using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlogEngine.Core;
using BlogEngine.Core.Web.Extensions;

public partial class widgets_AudioPlayer_audioplayer : System.Web.UI.Page
{
    public string stream;
    public string[] streamFiles;

    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterStyleSheetInclude(string.Format("{0}{1}", Utils.AbsoluteWebRoot, "themes/CarnavalRadio/styles/player.css"));

        streamFiles = new string[2];
        bool s = ExtensionManager.Extensions.ContainsKey("AudioStream");
        if (s)
        {

            stream = ExtensionManager.Extensions["AudioStream"].Settings[0].GetSingleValue("HighStream");
            
            if(!stream.ToLower().Trim().StartsWith(@"http://"))
            {
                stream = @"http://" + stream;
            }

            if (!stream.ToLower().Trim().EndsWith(@"/;"))
            {
                stream += @"/;";
            }


            streamFiles[0] = ExtensionManager.Extensions["AudioStream"].Settings[0].GetSingleValue("PlsFile");
            streamFiles[1] = ExtensionManager.Extensions["AudioStream"].Settings[0].GetSingleValue("AsmxFile");
        }
        else
            stream = "http://50.7.241.10:8021/;";

        var sbSwitchingSponsors = new StringBuilder();

        var listOfSponsors = CRSponsor.GetListOnlyActive();

        bool sponsorLeft = false;
        bool sponsorRight = false;
                string path = string.Format("{0}themes/{1}/img/logo.png", Utils.AbsoluteWebRoot, BlogSettings.Instance.GetThemeWithAdjustments(null));
        sponsorTopLeft.ImageUrl = sponsorTopRight.ImageUrl = path;
        foreach (var sponsor in listOfSponsors.Where(i => i.PlayerSwitch))
        {
            sbSwitchingSponsors.AppendFormat("<img src=\"{0}\" alt=\"{1}\"></img>", sponsor.LogoURL, sponsor.Name);
        }
        foreach (var sponsor in listOfSponsors.Where(i => i.PlayerSolid).Take(2))
        {
            if(!sponsorLeft)
            {
                sponsorTopLeft.ImageUrl = sponsor.LogoURL;
                sponsorTopLeft.AlternateText = sponsor.Name;
                sponsorLeft = sponsor.HasLogo;
            }else if (!sponsorRight)
            {
                sponsorTopRight.ImageUrl = sponsor.LogoURL;
                sponsorTopRight.AlternateText = sponsor.Name;
                sponsorRight = sponsor.HasLogo;
            }
            
        }

        litSwitchingSponsors.Text = sbSwitchingSponsors.ToString();
    }

    /// <summary>
    /// Registers the client script include.
    /// </summary>
    /// <param name="src">The file name.</param>
    private void RegisterStyleSheetInclude(string src)
    {
        var si = new System.Web.UI.HtmlControls.HtmlGenericControl();
        si.TagName = "link";
        si.Attributes.Add("type", "text/css");
        si.Attributes.Add("rel", "stylesheet");
        si.Attributes.Add("media", "screen");
        si.Attributes.Add("href", src);
        this.Page.Header.Controls.Add(si);
        this.Page.Header.Controls.Add(new LiteralControl("\n"));
    }
}