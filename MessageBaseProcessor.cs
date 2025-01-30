using System;
using System.Reflection;

namespace EscapeLifeCommon.Messages
{
    public static class MessageBaseProcessor
    {
        /// <summary>
        /// By calling the process method of a messagebase object, it will call the concrete class implementation of Process
        /// </summary>
        /// <param name="message"></param>
        public static void Process(this MessageBase message)
        {
            // Get the full type (namespace.class) of the concrete class
            string fullMessageType = typeof(MessageBase).Namespace + "." + message.MessageType;
            
            // Remove the last "Message" by "Processor"
            int lastIndex = fullMessageType.LastIndexOf("Message");
            string fullProcessorType = fullMessageType.Substring(0, lastIndex) + "Processor";

            // Get the processor as type
            Type processorType = Type.GetType(fullProcessorType);

            if (processorType == null)
                return;

            // Get the process method of that class
            MethodInfo processMethod = processorType.GetMethod("Process");

            if (processMethod == null)
                return;

            // Calls the Process()
            processMethod.Invoke(null, new object[] { message });
        }
    }
}