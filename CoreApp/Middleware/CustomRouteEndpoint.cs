using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Middleware
{
    public class RouteEndpoint //: Endpoint
    {


        //
        // Résumé :
        //     Gets the informational display name of this endpoint.
        public string DisplayName { get; set; }

        public string Pattern { get; set; }

        //
        // Résumé :
        //     Gets the collection of metadata associated with this endpoint.
        public EndpointMetadataCollection Metadata { get; }

        //
        // Résumé :
        //     Gets the delegate used to process requests for the endpoint.
        public RequestDelegate RequestDelegate { get; }



    }
}
