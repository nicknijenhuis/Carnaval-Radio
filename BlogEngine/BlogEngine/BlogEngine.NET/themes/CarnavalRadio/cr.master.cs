using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using App_Code.Extensions;
using BlogEngine.Core;
using ExtensionMethods;
using BlogEngine.Core.Web.Extensions;

public partial class CrSite : System.Web.UI.MasterPage
{
    public bool HideSliderAndButtons { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Security.IsAuthenticated)
        {
            aUser.InnerText = "Welcome " + Page.User.Identity.Name + "!";
            aLogin.InnerText = Resources.labels.logoff;
            aLogin.HRef = Utils.RelativeWebRoot + "Account/login.aspx?logoff";
        }
        else
        {
            aLogin.HRef = Utils.RelativeWebRoot + "Account/login.aspx";
            aLogin.InnerText = Resources.labels.login;
        }
        RegisterStyleSheetInclude(string.Format("{0}{1}", Utils.AbsoluteWebRoot, "themes/CarnavalRadio/styles/superfish.css"));
        RegisterClientScriptInclude(string.Format("{0}{1}", Utils.AbsoluteWebRoot, "themes/CarnavalRadio/js/superfish.js"));
        RegisterClientScriptInclude(string.Format("{0}{1}", Utils.AbsoluteWebRoot, "themes/CarnavalRadio/js/jquerymarquee.js"));
        RegisterClientScriptInclude(string.Format("{0}{1}", Utils.AbsoluteWebRoot, "themes/CarnavalRadio/js/jquery.peelback.js"));
        RegisterClientScriptInclude("http://malsup.github.com/jquery.cycle.all.js");


        var customScript = new StringBuilder();
        var settings = ExtensionManager.GetSettings("Bovenhoek");
        customScript.Append("<script type=\"text/javascript\">");
        customScript.Append("$(function () {");
            customScript.Append("    $('#PeelBack').peelback({");
            customScript.AppendFormat("    adImage: $('a#CRwebroot').attr('href') + '{0}',", settings.GetSingleValue("PeelImage"));
            customScript.Append("    peelImage: $('a#CRwebroot').attr('href') + 'themes/CarnavalRadio/img/peel-image.png',");
            customScript.AppendFormat("    clickURL: '{0}',", settings.GetSingleValue("PeelUrl"));
            customScript.Append("    smallSize: 75,");
            customScript.Append("    bigSize: 300,");
            customScript.Append("    gaTrack: true,");
            customScript.Append("    gaLabel: 'Help',");
            customScript.Append("    autoAnimate: true");
            //customScript.AppendFormat("    target: {0}", settings.GetSingleValue("PeelTarget"));
            customScript.Append("});");
        customScript.Append("}); ");
        customScript.Append("</script>");

        litJSPeel.Text = customScript.ToString();

        litMenu.Text = buildMenu("");
        litMenuOverig.Text = buildMenuOverig("");
        litSponsorImages.Text = getSponsorImages();
        litHeaderImages.Text = getHeaderImages();
        icon32.Href = Utils.AbsoluteWebRoot + "themes/CarnavalRadio/img/fav32.png";
        icon64.Href = Utils.AbsoluteWebRoot + "themes/CarnavalRadio/img/fav64.png";

        SliderAndButtons.Visible = JScriptSliderAndButtons.Visible = !HideSliderAndButtons;
    }

    private string getHeaderImages()
    {
        //       <img src="<%=Utils.AbsoluteWebRoot %>Upload/Headers/1.jpg" />
        //<img src="<%=Utils.AbsoluteWebRoot %>Upload/Headers/2.jpg" />

        var picasaAlbum = Picasa2.GetAlbums().SingleOrDefault(i => i.Accessor.AlbumTitle.ToLower() == "headers");

        var sb = new StringBuilder();
        foreach (var photo in picasaAlbum.AlbumContent)
        {
            sb.AppendFormat(
                "<img src=\"{0}\" alt=\"slide {1}\" width=\"940\" height=\"289\" />", photo.ImageSrc, photo.Title);
        }

        return sb.ToString();
    }

    private string getSponsorImages()
    {
        var sb = new StringBuilder();
        foreach (CRSponsor crs in CRSponsor.GetListOnlyActive().Where(i => i.WidgetSwitch))
        {
            sb.AppendFormat("<a href=\"{0}\" title=\"{1}\"><img src=\"{2}\" alt=\"{1}\" title=\"{1}\" width=\"168\" height=\"96\" /></a>", crs.Url.ToUrlString(), crs.Name, Utils.AbsoluteWebRoot + crs.LogoURL);
        }
        return sb.ToString();
    }

    private string buildMenu(string currentPage)
    {
        StringBuilder menu = new StringBuilder();

        foreach (var parentPage in BlogEngine.Core.Page.Pages.Where(p => !p.HasParentPage))
        {
            if (parentPage.Title.Contains("Luisteren"))
            {
                menu.AppendFormat("<li class=\"page_item\"><a href=\"{0}\" title=\"{1}\">{1}</a>",
                                  parentPage.RelativeLink, parentPage.Title);
                if (parentPage.HasChildPages)
                {
                    menu.Append(getChildPages(parentPage));
                }
                menu.Append("</li>");
            }
        }

        return menu.ToString();
    }

    private string buildMenuOverig(string currentPage)
    {
        StringBuilder menu = new StringBuilder();

        foreach (var parentPage in BlogEngine.Core.Page.Pages.Where(p => !p.HasParentPage))
        {
            if (parentPage.Title.Contains("Overig"))
            {
                menu.AppendFormat("<li><a>{0}</a>", parentPage.Title);
                if (parentPage.HasChildPages)
                {
                    menu.Append(getChildPages(parentPage));
                }
                menu.Append("</li>");
            }
        }

        return menu.ToString();
    }

    private string getChildPages(BlogEngine.Core.Page parent)
    {
        var sb = new StringBuilder();
        sb.Append("<ul class=\"sub-menu\">");
        foreach (
            var childPage in
                BlogEngine.Core.Page.Pages.Where(p => p.Parent == parent.Id))
        {
            if(childPage.Title.ToLower() == "nu luisteren")
            {sb.AppendFormat("<li class=\"page_item\"><a href=\"#\" onclick=\"OpenStreamPopup();\" title=\"{0}\">{0}</a>", childPage.Title);}
            else
            {sb.AppendFormat("<li class=\"page_item\"><a href=\"{0}\" title=\"{1}\">{1}</a>", getReplacement(childPage.Title) ?? childPage.RelativeLink, childPage.Title);}
            
            if (childPage.HasChildPages)
            {
                sb.Append(getChildPages(childPage));
            }
            sb.Append("</li>");
        }
        sb.AppendFormat("</ul>");
        return sb.ToString();
    }

    private string getReplacement(string title)
    {
        switch (title.ToLower())
        {
            case "recente nummers":
                return Utils.AbsoluteWebRoot + "recentenummers.aspx";
        }
        return null;
    }


    /// <summary>
    /// Registers the client script include.
    /// </summary>
    /// <param name="src">The file name.</param>
    private void RegisterClientScriptInclude(string src)
    {
        var si = new System.Web.UI.HtmlControls.HtmlGenericControl();
        si.TagName = "script";
        si.Attributes.Add("type", "text/javascript");
        si.Attributes.Add("src", src);
        this.Page.Header.Controls.Add(si);
        this.Page.Header.Controls.Add(new LiteralControl("\n"));
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
