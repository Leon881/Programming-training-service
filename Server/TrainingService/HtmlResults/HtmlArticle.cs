using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace TrainingService.HtmlResults
{
    public class HtmlArticle : IActionResult
    {
        string htmlCode;
        public HtmlArticle(string html)
        {
            htmlCode = html;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            string fullHtmlCode = "<div>";
            fullHtmlCode += htmlCode;
            fullHtmlCode += "</div>";
            await context.HttpContext.Response.WriteAsync(fullHtmlCode);
        }
    }
}
