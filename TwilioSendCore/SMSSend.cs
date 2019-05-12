using System;
using Custom;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

public class SMSSend
{
    public static void SMSSendMsg()
    {
        var accountSid = Environment.GetEnvironmentVariable("accountSid");
        var authToken = Environment.GetEnvironmentVariable("authToken");
        var from = ConfigurationManager.AppSetting["TwilioNumber"];
        var JPsiPhone6 = ConfigurationManager.AppSetting["JPsiPhone6"];

        TwilioClient.Init(accountSid, authToken);

        var message = MessageResource.Create(
            body: "Hello .NET Oxford. In case you didn't know Dan Clarke is obsessed with Kubernetes",
            from: from,
            to: JPsiPhone6
        );

        Console.WriteLine(message.Sid);

    }
}
