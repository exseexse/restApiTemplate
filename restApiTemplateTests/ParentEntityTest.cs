using NUnit.Framework;
using restApiTemplateDBEntities;
using restApiTemplateSqliteTestDB;
using restApiTemplateUOW.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tests
{
    public class ParentEntityTests
    {
        [SetUp]
        public void Setup()
        {
        }
     

        [Test, Order(1)]
        public void addParentWithChildEntity()
        {
            using (UnitOfWork worker = new UnitOfWork(new SqliteTestDbContext()))
            {      

                ChildEntity newChild = new ChildEntity();
                var createDateChild = new DateTime(2022, 4, 8, 4, 35, 11);
                newChild.createdDate = createDateChild;
                newChild.name = "NewChild";
                newChild.sequenceNo = 32;

                ParentEntity newParent = new ParentEntity();
                var createDateParent = new DateTime(2020, 1, 10, 11, 25, 20);
                newParent.createdDate = createDateParent;
                newParent.name = "NewParent";
                newParent.sequenceNo = 32;
                newParent.ChildEntity.Add(newChild);

                worker.ParentEntityRepository.Add(newParent);


                Assert.AreEqual(1, worker.ParentEntityRepository.Count());
                var newParentDb = worker.ParentEntityRepository.GetAll().ToList();
                Assert.AreEqual(1, newParentDb.Count);
                Assert.AreEqual("NewParent", newParentDb.FirstOrDefault().name);
                Assert.AreEqual(32, newParentDb.FirstOrDefault().sequenceNo);
                Assert.AreEqual(createDateParent.ToString(), newParentDb.FirstOrDefault().createdDate.ToString());
                Assert.Greater(newParentDb.FirstOrDefault().Id, 0);


                Assert.AreEqual(1, worker.ChildEntityRepository.Count());
                var newChildDb = worker.ChildEntityRepository.GetAll().ToList();
                Assert.AreEqual(1, newChildDb.Count);
                Assert.AreEqual("NewChild", newChildDb.FirstOrDefault().name);
                Assert.AreEqual(32, newChildDb.FirstOrDefault().sequenceNo);
                Assert.AreEqual(createDateChild.ToString(), newChildDb.FirstOrDefault().createdDate.ToString());
                Assert.Greater(newChildDb.FirstOrDefault().Id, 0);
            }

        }


        [Test, Order(2)]
        public void deleteChildEntity()
        {
            using (UnitOfWork worker = new UnitOfWork(new SqliteTestDbContext()))
            {
                var newChildDb = worker.ChildEntityRepository.GetAll().ToList();
                worker.ChildEntityRepository.Remove(newChildDb.FirstOrDefault());
                newChildDb = worker.ChildEntityRepository.GetAll().ToList();
                Assert.AreEqual(0, newChildDb.Count);
            }
        }



        [Test, Order(3)]
        public void deleteParentEntity()
        {
            using (UnitOfWork worker = new UnitOfWork(new SqliteTestDbContext()))
            {
                var newParentDb = worker.ParentEntityRepository.GetAll().ToList();
                worker.ParentEntityRepository.Remove(newParentDb.FirstOrDefault());
                newParentDb = worker.ParentEntityRepository.GetAll().ToList();
                Assert.AreEqual(0, newParentDb.Count);
            }
        }

        [Test, Order(4)]
        public void deleteCascadeParentEntity()
        {
            using (UnitOfWork worker = new UnitOfWork(new SqliteTestDbContext()))
            {

                ChildEntity newChild = new ChildEntity();
                var createDateChild = new DateTime(2022, 4, 8, 4, 35, 11);
                newChild.createdDate = createDateChild;
                newChild.name = "NewChild";
                newChild.sequenceNo = 32;

                ParentEntity newParent = new ParentEntity();
                var createDateParent = new DateTime(2020, 1, 10, 11, 25, 20);
                newParent.createdDate = createDateParent;
                newParent.name = "NewParent";
                newParent.sequenceNo = 32;
                newParent.ChildEntity.Add(newChild);

                worker.ParentEntityRepository.Add(newParent);

                var newParentDb = worker.ParentEntityRepository.GetAll().ToList();
                worker.ParentEntityRepository.Remove(newParentDb.FirstOrDefault());
                newParentDb = worker.ParentEntityRepository.GetAll().ToList();
                Assert.AreEqual(0, newParentDb.Count);


                var newChildDb = worker.ChildEntityRepository.GetAll().ToList();
                Assert.AreEqual(0, newChildDb.Count);
            }

        }


    }
}