using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Models
{
    public interface IRequest
    {
        Uri Origin { get; set; }

        bool EnableCookies { get; set; }

        string Domain { get; set; }

    }

}
