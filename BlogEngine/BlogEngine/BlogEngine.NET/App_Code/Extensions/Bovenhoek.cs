using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using BlogEngine.Core;
using BlogEngine.Core.Web.Controls;
using BlogEngine.Core.Web.Extensions;

/// <summary>
/// Summary description for AudioStream
/// </summary>
[Extension("Extension used to set merchandise in upper corner", "1.1", "Nick")]
public class Bovenhoek
{
    public Bovenhoek()
    {
        //Comment.Serving += new EventHandler<ServingEventArgs>(Post_CommentServing);
        ExtensionSettings settings = new ExtensionSettings("Bovenhoek");

        /*                TxtUrl.Text = Settings.GetSingleValue("PeelUrl");
                TxtImageUrl.Text = Settings.GetSingleValue("PeelImage");
                TxtTarget.Text = Settings.GetSingleValue("PeelTarget");*/

        settings.AddParameter("PeelUrl", "PeelUrl.", 500, true, false, ParameterType.String);
        settings.AddParameter("PeelImage", "PeelImage.", 500, true, false, ParameterType.String);
        settings.AddParameter("PeelTarget", "PeelTarget.", 500, true, false, ParameterType.String);

        // settings.AddValue("HighStream", "Http://HighStreamVoorbeeld.nl");
        //settings.AddValue("LowStream", "Http://lowstreamVoorbeeld.nl");

        settings.IsScalar = true;
        ExtensionManager.ImportSettings(settings);


    }
   }





