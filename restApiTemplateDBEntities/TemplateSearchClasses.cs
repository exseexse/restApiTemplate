using System;
using System.Collections.Generic;
using System.Text;

namespace restApiTemplateDBEntities
{
    public class SearchModel
    {
        public int id { get; set; }
        public string searchText { get; set; }
        public int take { get; set; }
        public int skip { get; set; }
        public string orderName { get; set; }
        public bool orderIsDescending { get; set; }
        public int newSequenceNo { get; set; }
        public object updateData { get; set; }
    }
}
