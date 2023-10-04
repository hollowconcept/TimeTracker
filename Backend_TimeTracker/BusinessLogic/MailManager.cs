using PP2000.SendQueue._40;
using PP2000.SendQueue.Definitions._40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_TimeTracker.BusinessLogic
{
    internal class MailManager
    {
        public static event OnErrorEventHandler OnError;
        public delegate void OnErrorEventHandler(string message);

        public static string _sendClient = Properties.Settings.Default.SendClient;
        private static string _smtpHost = Properties.Settings.Default.SMTPHost;
        private static string _serviceMail = Properties.Settings.Default.ServiceEMailAddress;
        private static int _smptPort = Properties.Settings.Default.SMTPPort;

        public static bool SendMail(string htmlBody)
        {
            SendQueueManager sendQueueManager = new SendQueueManager();
            QueueResult sendResult = new QueueResult();

            bool result = false;

            string htmlString = string.Empty;

            try
            {
                htmlString = htmlBody;

                sendResult = sendQueueManager.SendQueue(_sendClient, _serviceMail,
                                                "", string.Empty, string.Empty,
                                                "",
                                                htmlString, string.Empty, true, 2);

                if (sendResult.QueueStatus == QueueResult.Status.OK)
                {
                    result = true;
                }
                else
                {
                    OnError($"MailManager.SendMail Fehler");
                }
            }
            catch (Exception ex)
            {
                OnError($"MailManager.SendMail {ex.Message}");
            }

            return result;
        }
    }
}
