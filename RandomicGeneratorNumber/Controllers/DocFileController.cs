using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;

namespace RandomicGeneratorNumber.Controllers
{
    public class DocFileController : ApiController
    {
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    //var postedFile = httpRequest.Files[file];
                    //var fileDir = HttpContext.Current.Server.MapPath("~/img/" + DateTime.Now.ToString("yyyyMMdd"));
                    //DirectoryInfo dir = new DirectoryInfo(fileDir);
                    //if (!dir.Exists)
                    //{
                    //    dir.Create();
                    //}
                    //string fileName = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), postedFile.FileName);
                    //var filePath = fileDir + "/" + fileName;
                    //postedFile.SaveAs(filePath);
                    var postedFile = httpRequest.Files[file];
                    DirectoryInfo dir = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/img/"));
                    var filePath = HttpContext.Current.Server.MapPath("~/img/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    docfiles.Add(filePath);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

    }
}