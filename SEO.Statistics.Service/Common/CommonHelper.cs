using Newtonsoft.Json;

namespace SEO.Statistics.Service.Common
{
    public static class CommonHelper
    {
        public static T DeserializeContent<T>(string ContentStr)
        {
            T content;
            var settings = new JsonSerializerSettings();
            settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;

            content = JsonConvert.DeserializeObject<T>(ContentStr, settings);
            return content;
        }
    }
}
