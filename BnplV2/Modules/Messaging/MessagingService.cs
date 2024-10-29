using BnplV2.Modules.Database;
using BnplV2.Utils;
using Flurl.Http;
using Hangfire;

namespace BnplV2.Modules.Messaging;

public interface IMessagingService
{
    void SendSingleMessage(MessageRequest request);
}

public class MessagingService: IMessagingService
{
    public void SendSingleMessage(MessageRequest request)
    {
        BackgroundJob.Enqueue(() => SendMessageAsync(new MessageRequest()
        {
            Text = request.Text,
            Msisdn = request.Msisdn,
        }));
    }
    
    
    public async Task SendMessageAsync(MessageRequest request)
    {
        string number;
        bool result = IdentityValidator.AddCountryCode(request.Msisdn, out number);
        
        var response = await "http://41.175.8.68:8181/bulksms/sms/gariSms.php"
            .PostJsonAsync(new
            {
                originatorId = "Lipila",
                msisdn = number,
                text = request.Text
            })
            .ReceiveString();
        
        Console.WriteLine(response);
    }
}