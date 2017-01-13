using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace TransSightData {
    public class Routes : IRouteProvider {
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes() {
            return new[] {
                new RouteDescriptor {
                    Priority = 5,
                    Route = new Route(
                        "TransSightData", // this is the name of the page url
                        new RouteValueDictionary {
                            { "area", "TransSightData" }, // this is the name of your module
                            { "controller", "Home" },
                            { "action", "Index" }
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            { "area", "TransSightData" } // this is the name of your module
                        },
                        new MvcRouteHandler())
                }
            };
        }
    }
}