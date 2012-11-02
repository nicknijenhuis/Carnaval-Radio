using System;
using System.Text.RegularExpressions;
using BlogEngine.Core.Web.Controls;
using BlogEngine.Core;

public partial class themes_CarnavalRadio_PostView : BlogEngine.Core.Web.Controls.PostViewBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Location == ServingLocation.PostList)
        {
            frontpage.Controls.Add(this.Index < 3
                                       ? LoadPostView("PostViewForList.ascx", true, ServingLocation.PostList)
                                       : LoadPostView("PostViewForListLast.ascx", true, ServingLocation.PostList));
        }
        else
            frontpage.Controls.Add(LoadPostView("PostViewFull.ascx", false, ServingLocation.SinglePost));

    }

    private PostViewBase LoadPostView(string useControlNamed, bool showExcerpt, ServingLocation serving)
    {

        string query = Request.QueryString["theme"];
        string theme = !string.IsNullOrEmpty(query) ? query : BlogSettings.Instance.Theme;
        string path = string.Concat(Utils.RelativeWebRoot, "themes/", theme, "/", useControlNamed);
        //Control.MapPath() 

        PostViewBase postView = (BlogEngine.Core.Web.Controls.PostViewBase)LoadControl(path);
        postView.ShowExcerpt = showExcerpt;// true;// BlogSettings.Instance.ShowDescriptionInPostList;
        postView.Post = Post;
        postView.ID = Post.Id.ToString().Replace("-", string.Empty);
        postView.Location = serving;
        postView.Index = this.Index;

        return postView;
    }

    public string getImage(bool ShowExcerpt, string input)
    {
        if (!ShowExcerpt || input == null)
            return "";

        string pain = input;
        string pattern = @"<img(.|\n)+?>";

        Match m = Regex.Match(input, pattern,
                              RegexOptions.IgnoreCase | RegexOptions.Multiline);

        if (m.Success)
        {
            string src = getSrc(m.Value);
            return string.Format("<img class=\"left\" width=\"275\" height=\"155\" {0}  />", src);
        }
        string path = string.Format("{0}themes/{1}/img/nieuwsbericht.jpg", Utils.AbsoluteWebRoot, BlogSettings.Instance.GetThemeWithAdjustments(null));
        return string.Format("<img class=\"left\" width=\"275\" height=\"155\" src=\"{0}\"  />", path);
    }

    private string getSrc(string input)
    {
        string pattern = "src=[\'|\"](.+?)[\'|\"]";

        var reImg = new Regex(pattern,
                              RegexOptions.IgnoreCase | RegexOptions.Multiline);

        Match mImg = reImg.Match(input);

        if (mImg.Success)
        {
            return mImg.Value;
        }

        return "";
    }

    /// <summary>
    /// Retrieves the current page index based on the QueryString.
    /// </summary>
    private int GetPageIndex()
    {
        int index = 0;
        if (int.TryParse(Request.QueryString["page"], out index))
            index--;

        return index;
    }

    private int getCurrentPostPos()
    {
        //if (!isPostList)
        //    return -1; 

        int localCounter = 0;
        for (int i = 0; i < BlogEngine.Core.Post.Posts.Count; i++)
        {
            if (Post.Id == BlogEngine.Core.Post.Posts[i].Id)
            {
                localCounter++;
                return localCounter;
            }
            else
            {
                //if (Post.Comments[i].IsApproved || !BlogEngine.Core.BlogSettings.Instance.EnableCommentsModeration)
                //er den visible eller er bruger logget ind skal den tælles med
                if (BlogEngine.Core.Post.Posts[i].IsPublished || Page.User.Identity.IsAuthenticated)
                    localCounter++;
            }
        }
        return -1;
    }
}