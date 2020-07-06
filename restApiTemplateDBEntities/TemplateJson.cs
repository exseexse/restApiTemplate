


using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
namespace restApiTemplateDBEntities
{
    public class SendJson
    {
        public OkObjectResult returnOK(object _object)
        {
            var jsonObject = JsonConvert.SerializeObject(_object, Formatting.Indented,
                  new JsonSerializerSettings()
                  {
                      ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                      DateTimeZoneHandling = DateTimeZoneHandling.Unspecified

                  }
              );

            return new OkObjectResult(jsonObject);
        }

        public BadRequestObjectResult returnBadRequest(object _object)
        {
            var jsonObject = JsonConvert.SerializeObject(_object, Formatting.Indented,
                  new JsonSerializerSettings()
                  {
                      ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                      DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
                  }
              );

            return new BadRequestObjectResult(jsonObject);

        }


    }
}
