﻿namespace App_Code
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Web;
    using System.Web.Services;
    using System.Web.Script.Services;

    using BlogEngine.Core;
    using BlogEngine.Core.Json;

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class postShout : WebService
    {
        string xmlfile = @"C:\Users\Odie20XX\Carnaval-Radio\BlogEngine\BlogEngine\BlogEngine.NET\widgets\Shoutbox\shouts.xml";
        //string xmlfile = Blog.CurrentInstance.RelativeWebRoot + @"widgets\Shoutbox\shouts.xml";

        [WebMethod]
        public JsonResponse submitMessage(string name, string message)
        {
            try
            {
                XDocument xDoc = XDocument.Load(xmlfile);
                int count = xDoc.Root.Elements().Count() + 1;
                xDoc.Element("shouts").Add(new XElement("shout",
                                                new XAttribute("id", count),

                                                new XElement("name", name),
                                                new XElement("message", message)));
                xDoc.Save(xmlfile);
                return new JsonResponse() { Success = true };
            }
            catch (Exception e)
            {
                return new JsonResponse() { Success = false };
            }
            
        }

    }
}