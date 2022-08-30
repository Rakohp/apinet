namespace TestApi.Localizer.Interface
{
    public interface ILocalizerExtension
    {
        string GetWord<T>(T context, string wordToSearch) where T : HttpRequest;
    }
}
