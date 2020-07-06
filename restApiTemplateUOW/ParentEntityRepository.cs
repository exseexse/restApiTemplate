using restApiTemplateDBEntities;
using restApiTemplateUOW.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace restApiTemplateUOW
{   
    public interface IParentEntityRepository : IGenericRepository<ParentEntity>
    {
        Expression<Func<ParentEntity, bool>> searchExpression(string searchText);
        IEnumerable<ParentEntity> getOrdered(SearchModel searchModel, Expression<Func<ParentEntity, bool>> filter = null);
    }

    public class ParentEntityRepository : GenericRepository<ParentEntity>, IParentEntityRepository
    {
        public ParentEntityRepository(EntityTemplateDbContext context)
         : base(context)
        {
            _customerDbEntities = context;
        }

        private readonly EntityTemplateDbContext _customerDbEntities;

        public IEnumerable<ParentEntity> getOrdered(SearchModel searchModel, Expression<Func<ParentEntity, bool>> filter = null)
        {
            return _customerDbEntities.ParentEntity.Where(filter)
                                        .GroupBy(x => new { x.department, x.gender, x.name })
                                        .OrderBy(g => g.Key.department).ThenBy(g => g.Key.gender.ToString()).ThenBy(g => g.Key.name)
                                        .Select(g => new
                                        {
                                            Dept = g.Key.department,
                                            Date = g.Key.gender,
                                            Persons = g.OrderBy(x=>x.name).Select(sc=>new ParentEntity{
                                                name=sc.name,
                                                sequenceNo=sc.sequenceNo,
                                                SubClassEntity=sc.SubClassEntity != null ?
                                                              new SubClassEntity
                                                              {
                                                                  name = sc.SubClassEntity.name,
                                                                  Id = sc.SubClassEntity.Id,
                                                              }
                                                              :
                                                              new SubClassEntity(),
                                            }),
                                        }).SelectMany(s => s.Persons).Skip(searchModel.skip).Take(searchModel.take);
        }

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
