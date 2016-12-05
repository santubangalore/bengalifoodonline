using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BengaliFoodOnline.Models
{
    public class PendingRequest
    {
        public DateTime Fromdate{get;set;}
        public DateTime Todate {get;set;}
        public int Orderno {get;set;}

    }
}