using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace restApiTemplateDBEntities
{
    public partial class ParentEntity
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

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
            this.SecondBranch = new HashSet<BranchEntity>();
            this.FirstBranch = new HashSet<BranchEntity>();
        }

        public int Id { get; set; }
        public string name { get; set; }
        public DateTime createdDate { get; set; }
        public int sequenceNo { get; set; }


        public virtual ICollection<ChildEntity> ChildEntity { get; set; }
        public virtual SubClassEntity SubClassEntity { get; set; }
        public virtual ICollection<BranchEntity> SecondBranch { get; set; }
        public virtual ICollection<BranchEntity> FirstBranch { get; set; }
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


    public partial class BranchEntity
    {
        public int Id { get; set; }
        public string name { get; set; }
        public DateTime createdDate { get; set; }
        public int sequenceNo { get; set; }

        public virtual ParentEntity SecondBranchParent { get; set; }
        public virtual ParentEntity FirstBranchParent { get; set; }
    }
}
