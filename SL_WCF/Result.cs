using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SL_WCF
{
    public class Result
    {
        [DataMember]
        public Exception Ex { get; set; }
        [DataMember]
        public bool Correct { get; set; }
        [DataMember]
        public object Object { get; set; }
        [DataMember]
        public List<object> Objects { get; set; }
        [DataMember]
        public string Message { get; set; }


    }
}