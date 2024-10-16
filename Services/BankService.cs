using Tools;

namespace Services
{
    public class BankService
    {
        private readonly MyCustomHttpClient _myCustomHttpClient;

        public BankService(MyCustomHttpClient myCustomHttpClient)
        {
            _myCustomHttpClient = myCustomHttpClient;
        }

        public async Task<string> DoSomeRequest()
        {
            return await _myCustomHttpClient.GetAsync("Bannk done request");
        }
    }
}