
using Microsoft.EntityFrameworkCore;

namespace restApiTemplateDBEntities
{
    public abstract class EntityTemplateDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<ParentEntity> ParentEntity { get; set; }
        public virtual DbSet<ChildEntity> ChildEntity { get; set; }  
      

    }
}
