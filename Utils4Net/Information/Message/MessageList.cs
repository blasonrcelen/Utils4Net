using System.Text;

namespace Utils4Net.Information.Message
{
    public class MessageList : List<string>
    {
        public MessageList()
        {
        }

        public MessageList(params string[] messages)
        {
            Add(messages);
        }

        public MessageList(List<string> messages)
        {
            Add(messages);
        }

        /*
         * Add
         */
        public MessageList Add(params string[] messages)
        {
            return Add(new List<string>(messages));
        }

        public MessageList Add(List<string> messages)
        {
            if (messages != null)
            {
                foreach (string message in messages)
                {
                    if (message != null)
                    {
                        base.Add(message);
                    }
                }
            }
            return this;
        }

        /*
         * Is
         */
        public bool IsEmpty()
        {
            return Count == 0;
        }

        public bool IsNotEmpty()
        {
            return !IsEmpty();
        }

        /*
         * To
         */
        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (string message in this)
            {
                sb.AppendLine(message);
            }
            return sb.ToString();
        }
    }
}
