using Tools;

namespace Services
{
    public class PayPalService
    {
        private readonly MyCustomHttpClient _myCustomHttpClient;

        public PayPalService(MyCustomHttpClient myCustomHttpClient)
        {
            _myCustomHttpClient = myCustomHttpClient;
        }

        public async Task<string> DoSomeRequest()
        {
            return await _myCustomHttpClient.GetAsync("PayPal done request");
        }
    }
}