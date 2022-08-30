using System.Text.Json;
using TestApi.Localization.Interface;

namespace TestApi.Localization.Service
{
    public class ReadProcessExt : IReadProcessExt
    {
        private Dictionary<string, string> SourceData;
        private string PathFile;
        private readonly string RouteFile;
        private readonly string ExtensionFile;
        public ReadProcessExt()
        {
            this.SourceData = new Dictionary<string, string>();
            this.PathFile = string.Empty;
            this.RouteFile = "./Localization/Lenguaje";
            this.ExtensionFile = ".json";
        }
        public Dictionary<string, string> ReadJson(string lang = "es")
        {
            GetPath(lang);
            ReadContent();
            return this.SourceData;
        }
        protected void ReadContent()
        {
            using StreamReader r = new(this.PathFile);       
            string json = r.ReadToEnd();
            if (json != null)
                this.SourceData = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            r.Dispose();
        }
        protected void GetPath(string lang)
        {
            this.PathFile = string.Concat(this.RouteFile, lang.ToLower() == "es" ? string.Empty : "EN", this.ExtensionFile);
        }
    }
}
