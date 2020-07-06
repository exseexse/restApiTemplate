using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using restApiTemplateDBEntities;
using restApiTemplateSqliteDB;
using restApiTemplateSqliteTestDB;
using restApiTemplateUOW.UnitOfWork;

namespace restApiTemplate.Controllers
{
    [Route("api/[controller]")]
    public class ParentController : Controller
    {
        [HttpPost("[action]")]
        //[Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult get([FromBody] SearchModel formdata)
        {
            using (UnitOfWork worker = new UnitOfWork(new sqliteDbContext()))
            {
                var expression = PredicateBuilder.True<ParentEntity>();
                expression = expression.And(s => s.name == formdata.searchText);
                return new OkObjectResult(new SendJson().returnJson(worker.ParentEntityRepository.getOrdered(formdata, expression)));
            }     
    
        }
    }
}