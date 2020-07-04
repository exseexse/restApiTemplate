
using Microsoft.EntityFrameworkCore;

namespace restApiTemplateDBEntities
{
    public abstract class EntityTemplateDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<ParentEntity> Equipments { get; set; }
        public virtual DbSet<ChildEntity> DataBaseModels { get; set; }  
      

    }
}
