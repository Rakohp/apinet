using TestApi.Base;
using TestApi.Localization.Interface;
using TestApi.Localizer.Interface;

namespace TestApi.Localizer
{
    public class LocalizerExtension : IBaseService, ILocalizerExtension
    {
        private readonly IReadProcessExt _localizer;
        public LocalizerExtension(IReadProcessExt localizer)
        {
            this._localizer = localizer;
        }
        public string GetWord<T>(T request, string wordToSearch) where T : HttpRequest
        {
            string header = request.Headers["Lang"].ToString();
            return !string.IsNullOrEmpty(header) ? GetWordInList(wordToSearch, header) ?? string.Empty : string.Empty;
        }
        private string? GetWordInList(string wordToSearch, string lang)
        {
            string word = this._localizer.ReadJson(lang).FirstOrDefault(m => m.Key == wordToSearch).Value.ToString();
            return word;
        }
    }
}
