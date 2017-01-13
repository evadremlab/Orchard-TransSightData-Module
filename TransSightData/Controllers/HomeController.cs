using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;

using Orchard.Themes;

using TransSightData.Models;

namespace TransSightData.Controllers {
    [Themed]
    public class HomeController : Controller {
        public ActionResult Index() {
            var model = new List<Operator>();
            var url = "http://api.511.org/transit/operators?api_key=f1c96ea1-ec0e-4e96-8a55-95683dd74ade&format=json";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            request.ContentType = "application/json";

            var response = (HttpWebResponse)request.GetResponse();
            string text;

            using (var sr = new StreamReader(response.GetResponseStream())) {
                text = sr.ReadToEnd();
            }

            try {
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Operator>>(text);
            }
            catch (Exception ex) {
                model.Add(new Operator { Name = ex.Message });
            }

            //model.Add(new Operator { Name = "Hiking" });
            //model.Add(new Operator { Name = "Camping" });
            //model.Add(new Operator { Name = "Kayaking" });

            return View("Index", model);
        }
    }
}