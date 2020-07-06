﻿using System;
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
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            using (UnitOfWork worker = new UnitOfWork(new sqliteDbContext()))
            {
                ParentEntity newParent = new ParentEntity();
                newParent.createdDate = DateTime.Now;
                newParent.name = "NewParent";
                newParent.sequenceNo = 1;
                worker.ParentEntityRepository.Add(newParent);
       
            }
            using (UnitOfWork worker = new UnitOfWork(new SqliteTestDbContext()))
            {
                ParentEntity newParent = new ParentEntity();
                newParent.createdDate = DateTime.Now;
                newParent.name = "NewParent";
                newParent.sequenceNo = 1;
                worker.ParentEntityRepository.Add(newParent);

            }
            return new string[] { "value1", "value2" };

         
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
