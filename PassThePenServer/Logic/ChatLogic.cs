using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ChatLogic
    {
        public string BuildMessage(string senderUsername, string message)
        {
            string hour = DateTime.Now.ToShortTimeString();
            string completeMessage = hour + " - " + senderUsername + ": " + message;

            return completeMessage;
        }
    }
}
