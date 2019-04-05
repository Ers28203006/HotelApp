using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace HotelApp.Services
{
    public class SmsVerification
    {
        public string VerificationAccount()
        {
            Random rnd = new Random();

            string smscode = Convert.ToString(rnd.Next(100, 1000));

            const string accountSid = "AC25397f14003e0dd11031eb4961816bf1";
            const string authToken = "a5afaa107ff9af195d4383907819d50b";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
            from: new Twilio.Types.PhoneNumber("+12055765975"),
            body: smscode,
            to: new Twilio.Types.PhoneNumber("+77479732167")
            );
            return smscode;
        }
    }
}