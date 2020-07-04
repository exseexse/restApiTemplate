using restApiTemplateDBEntities;
using restApiTemplateUOW.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace restApiTemplateUOW
{   
    public interface IParentEntityRepository : IGenericRepository<ParentEntity>
    {
        Expression<Func<ParentEntity, bool>> searchExpression(string searchText);
  
    }

    public class ParentEntityRepository : GenericRepository<ParentEntity>, IParentEntityRepository
    {
        public ParentEntityRepository(EntityTemplateDbContext context)
         : base(context)
        {
            _customerDbEntities = context;
        }

        private readonly EntityTemplateDbContext _customerDbEntities;

        public Expression<Func<ParentEntity, bool>> searchExpression(string searchText)
        {
            return s => s.name.Contains(searchText.ToString(), StringComparison.OrdinalIgnoreCase)
                      ||
                      s.createdDate.ToString().Contains(searchText.ToString(), StringComparison.OrdinalIgnoreCase)
                      ||
                      s.sequenceNo.ToString().Contains(searchText.ToString(), StringComparison.OrdinalIgnoreCase);
        }

    }
}
