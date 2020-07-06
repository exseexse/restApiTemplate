



using Newtonsoft.Json;

namespace restApiTemplateDBEntities
{
    public class SendJson
    {
        public string returnJson(object _object)
        {
            return JsonConvert.SerializeObject(_object, Formatting.Indented,
                  new JsonSerializerSettings()
                  {
                      ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                      DateTimeZoneHandling = DateTimeZoneHandling.Unspecified

                  }
              );

   
        } 


    }
}
