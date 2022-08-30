using TestApi.Base;
using TestApi.Interfaces.Repository;

namespace TestApi.Repository
{
    public class TestRepository : IBaseService, ITestRepository 
    {
        public string GetHelloWord()
        {
            return "Hola mundo";
        }
    }
}
