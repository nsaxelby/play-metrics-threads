// See https://aka.ms/new-console-template for more information
using Tools;
using Services;

Console.WriteLine("Hello, World!");

var singleHttpClient = new MyCustomHttpClient();

var bankService = new BankService(singleHttpClient);
var payPalService = new PayPalService(singleHttpClient);

Thread thread1 = new Thread(async () =>
{
    while (true)
    {
        var result = bankService.DoSomeRequest().Result;
        Console.WriteLine(result);
    }
});

Thread thread2 = new Thread(() =>
{
    while (true)
    {
        var result = payPalService.DoSomeRequest().Result;
        Console.WriteLine(result);
    }
});

thread1.Start();
thread2.Start();

thread1.Join();
