using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcessing
{

    public enum MessageType_en
    {
        eError,
        eSuccess,
        eStandart
    }

    public class HistoryMessage
    {
        private static Color errorColor = Color.Red, 
                             successColor = Color.Green, 
                             standartColor = Color.Black;

        public Color getColor()
        {
            switch(this.messageType)
            {
                case MessageType_en.eError:
                    return errorColor;
                case MessageType_en.eSuccess:
                    return successColor;
                case MessageType_en.eStandart:
                    return standartColor;
                default:
                    return Color.Gray;
            }
        }

        public string messageValue { get; private set; }
        public MessageType_en messageType { get; private set; }

        public HistoryMessage(string val, MessageType_en type)
        {
            messageValue = val;
            messageType = type;
        }
    }
}
