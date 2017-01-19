using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace GamesStudios.Helpers
{
    public static class LinkHelper
    {
        public static string CreateLinkButtton(string downloadLink, string buttonText)
        { 
           // return String.Format("< p >< a href =" + downloadLink + "class=\"btn btn-primary btn-lg\"> " + buttonText + "&raquo;</a></p>");
         //   return String.Format("< p >< a href =" +"\""+ downloadLink + "\""+ " class=\"btn btn-primary btn-lg\"> " + buttonText + "&raquo;</a></p>");
            return "<p><a href =" + "\"" + downloadLink + "\"" + " class=\"btn btn-primary btn-lg\"> " + buttonText + " &raquo;</a></p>";
        }


        public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }
    }
}