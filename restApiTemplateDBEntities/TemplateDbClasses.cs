using System;
using System.Collections.Generic;

namespace restApiTemplateDBEntities
{
    public partial class ChildEntity
    {
        public int Id { get; set; }
        public string name { get; set; }
        public DateTime createdDate { get; set; }
        public int sequenceNo { get; set; }

        public virtual ParentEntity ParentEntity { get; set; }
    }

    public partial class ParentEntity
    {
        public ParentEntity()
        {
            this.ChildEntity = new HashSet<ChildEntity>();
        }

        public int Id { get; set; }
        public string name { get; set; }
        public DateTime createdDate { get; set; }
        public int sequenceNo { get; set; }

  
        public virtual ICollection<ChildEntity> ChildEntity { get; set; }
        public virtual SubClassEntity SubClassEntity { get; set; }
    }

    public partial class SubClassEntity
    {
        public int Id { get; set; }
        public string name { get; set; }
        public DateTime createdDate { get; set; }
        public int sequenceNo { get; set; }
        public Nullable<int> parentFK { get; set; }

        public virtual ParentEntity ParentEntity { get; set; }
    }
}
