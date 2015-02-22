using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace NFLanguageCompiler 
{
    // Describes warning and error information. 
    // Includes a message, line number, column, and system type.
    [Serializable]
    public class Message : ISerializable
    {
        #region Properties

        public String Text { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
        public SystemType System { get; set; }

        #endregion

        #region Constructors

        // Default constructor
        public Message()
            : this("",0,0,SystemType.ST_NONE)
        {
        }

        // Input constructor
        public Message(String message, int line, int column, SystemType system)
        {
            Text = message;
            Line = line;
            Column = column;
            System = system;
        }

        // Deserialization constructor
        public Message(SerializationInfo info, StreamingContext sc)
        {
            Text = (String)info.GetValue("Text", typeof(String));
            Line = (int)info.GetValue("Line", typeof(int));
            Column = (int)info.GetValue("Column", typeof(int));
            System = (SystemType)info.GetValue("System", typeof(SystemType));
        }

        #endregion
        
        #region ISerializable Members

        // Serialization interface method. Describes how data is serialized.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Text", Text, typeof(String));
            info.AddValue("Line", Line, typeof(int));
            info.AddValue("Column", Column, typeof(int));
            info.AddValue("System", System, typeof(SystemType));
        }

        #endregion
    }
}
