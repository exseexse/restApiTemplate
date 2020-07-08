using System;
using System.Collections.Generic;
using System.Text;

namespace restApiTemplateDBEntities
{
    public class AppSettings
    {
        //for JWT Token sinature
        public string Site { get; set; }
        public string Secret { get; set; }
        public string ExpireTime { get; set; }
        public string Audience { get; set; }
    }
}
