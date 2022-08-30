using TestApi.Base;
using TestApi.Interfaces.Repository;
using TestApi.Interfaces.Services;

namespace TestApi.Services
{
    public class TestService : IBaseService, ITestService
    {
        private readonly ITestRepository _testRepository;
        public TestService(ITestRepository testRepository)
        {
            this._testRepository = testRepository;
        }
        public string GetHelloWord()
        {
            return _testRepository.GetHelloWord();
        }
    }
}
