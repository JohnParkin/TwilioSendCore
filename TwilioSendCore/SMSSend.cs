using System;
using Custom;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

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

    public static void SMSSendMsgs()
    {
        var accountSid = Environment.GetEnvironmentVariable("accountSid");
        var authToken = Environment.GetEnvironmentVariable("authToken");
        var from = ConfigurationManager.AppSetting["TwilioNumber"];
        var JPsiPhone6 = ConfigurationManager.AppSetting["JPsiPhone6"];
        var spamto = ConfigurationManager.AppSetting["Contacts:John"]; ;
        string spammessage = "Hello .NET Oxford. Thank you for listening";

        string[] spamees = new string[5];
        spamees[0] = "John";
        spamees[1] = "Dan";
        spamees[2] = "Pym";
        spamees[3] = "Tim";
        spamees[4] = "Dushyant";

        TwilioClient.Init(accountSid, authToken);

        foreach (string spamee in spamees)
        {

            spamto = ConfigurationManager.AppSetting["Contacts:" + spamee];
            spammessage = ConfigurationManager.AppSetting["Messages:" + spamee];

            var message = MessageResource.Create(
                body: spammessage,
                from: from,
                to: spamto);

            Console.WriteLine(message.Sid);

        }

    }
}
