using Newtonsoft.Json;
using restApiTemplateDBEntities;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestServices
{
    public interface IRemoteParentRestService
    {
        Task<ParentEntity> getAsyncParents(SearchModel formdata);
    }

    public class RemoteParentRestService : IRemoteParentRestService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        public RemoteParentRestService()
        {
        }

        public async Task<ParentEntity> getAsyncParents(SearchModel formdata)
        {
            HttpClient client = new HttpClient();
            
            HttpResponseMessage response = await client.PostAsync(
                        "http://192.168.1.34:81/api/batch/getRecipeList", 
                        new StringContent(JsonConvert.SerializeObject(formdata), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ParentEntity>(responseBody);        
            }

            return null;
        }
    }
    public class RemoteMockParentRestService : IRemoteParentRestService
    {
        public RemoteMockParentRestService()
        {
        }

        public async Task<ParentEntity> getAsyncParents(SearchModel formdata)
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

            SubClassEntity newSubClass = new SubClassEntity();
            var createSubClassDate = new DateTime(2026, 6, 13, 10, 11, 12);
            newSubClass.createdDate = createSubClassDate;
            newSubClass.name = "NewSubClass";
            newSubClass.sequenceNo = 102;

            newParent.SubClassEntity = newSubClass;

            BranchEntity newFirstBranch = new BranchEntity();
            var newFirstBranchDate = new DateTime(2023, 2, 14, 14, 22, 15);
            newFirstBranch.createdDate = newFirstBranchDate;
            newFirstBranch.name = "NewSubClass";
            newFirstBranch.sequenceNo = 102;
            newParent.FirstBranch.Add(newFirstBranch);


            BranchEntity newSecondBranch = new BranchEntity();
            var newSecondBranchDate = new DateTime(2024, 6, 24, 10, 35, 7);
            newSecondBranch.createdDate = newSecondBranchDate;
            newSecondBranch.name = "NewSubClass";
            newSecondBranch.sequenceNo = 102;
            newParent.SecondBranch.Add(newSecondBranch);

            return newParent;
        }
    }
}
