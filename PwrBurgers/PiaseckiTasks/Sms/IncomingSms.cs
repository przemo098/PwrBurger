using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Provider;
using Android.Telephony;
using Android.Util;
using Environment = System.Environment;

namespace PwrBurgers.PiaseckiTasks.Sms
{
    [BroadcastReceiver(Enabled = true, Label = "SMS Receiver")]
    [IntentFilter(new[] { "android.provider.Telephony.SMS_RECEIVED" })]
    public class SMSBroadcastReceiver : BroadcastReceiver
    {

        private const string Tag = "SMSBroadcastReceiver";
        private const string IntentAction = "android.provider.Telephony.SMS_RECEIVED";

        public override void OnReceive(Context context, Intent intent)
        {
            Log.Info(Tag, "Intent received: " + intent.Action);

            if (intent.Action != IntentAction) return;

            SmsMessage[] messages = Telephony.Sms.Intents.GetMessagesFromIntent(intent);

            var sb = new StringBuilder();

            for (var i = 0; i < messages.Length; i++)
            {

                sb.Append(string.Format("SMS From: {0}{1}Body: {2}{1}", messages[i].OriginatingAddress,
                    Environment.NewLine, messages[i].MessageBody));
            }

            SmsManager sm = SmsManager.Default;
            sm.SendTextMessage("07071993", null, "Sms response", null, null);

        }
    }
}