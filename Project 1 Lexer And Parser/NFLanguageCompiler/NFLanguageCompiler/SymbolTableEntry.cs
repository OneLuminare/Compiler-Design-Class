using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace NFLanguageCompiler
{
    //Encapsulates Symbol Table Entry.
    //
    //Implements: ISerializeable
    public class SymbolTableEntry : ISerializable
    {
        #region Data Members

        private char id;
        private DataType type;
        private int memoryLocation;
        private byte byteValue;
        private String stringValue;

        #endregion

        #region Properties

        //Gets id as char
        public char ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        //Gets data type as enum
        public DataType DataType
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        //Gets memory location
        public int MemoryLocation
        {
            get
            {
                return memoryLocation;
            }

            set
            {
                memoryLocation = value;
            }
        }

        //Gets raw value as byte
        public byte ByteValue
        {
            get
            {
                return byteValue;
            }

            set
            {
                byteValue = value;
            }
        }

        //Gets value as int
        public int IntValue
        {
            get
            {
                return (int)byteValue;
            }

            set
            {
                byteValue = (byte)value;
            }
        }

        //Gets string value
        public String StringValue
        {
            get
            {
                return stringValue;
            }

            set
            {
                stringValue = value;
            }
        }

        #endregion

        #region Constructors

        //Default constructor
        public SymbolTableEntry()
        {
            id = (char)0;
            type = DataType.DT_NONE;
            byteValue = (byte)0;
            stringValue = String.Empty;
            memoryLocation = 0;
        }

        //Set char value constructor
        public SymbolTableEntry(char id, DataType type, int memoryLocation, char value)
            : this( id,type,memoryLocation,(byte)value,String.Empty)
        {
        }

        //Set int value constructor
        public SymbolTableEntry(char id, DataType type, int memoryLocation, int value)
            : this(id, type, memoryLocation, (byte)value, String.Empty)
        {
        }

        //Set string value constructor
        public SymbolTableEntry(char id, DataType type, int memoryLocation, String value)
            : this(id, type, memoryLocation, (byte)0, value)
        {
        }

        //Master set constructor
        public SymbolTableEntry(char id, DataType type, int memoryLocation, byte byteValue, String stringValue)
        {
            this.id = id;
            this.type = type;
            this.byteValue = byteValue;
            this.stringValue = stringValue;
            this.memoryLocation = memoryLocation;
        }

        //Deserialiaation constructor
        public SymbolTableEntry(SerializationInfo info, StreamingContext context)
        {
            id = (char)info.GetValue("ID", typeof(char));
            type = (DataType)info.GetValue("Type", typeof(DataType));
            memoryLocation = (int)info.GetValue("Memory Location", typeof(int));
            byteValue = (byte)info.GetValue("Byte Value", typeof(byte));
            stringValue = (String)info.GetValue("String Value", typeof(String));
            
        }

        #endregion

        #region Methods

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return String.Format("ID: {0} Type: {1} Byte Value: {2} String Value: \"{3}\" Memory Location: {4}",id,type,byteValue,stringValue,memoryLocation);
        }

        #endregion

        #region ISerializable Members

        // Serialization method

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", id, typeof(char));
            info.AddValue("Type", type, typeof(DataType));
            info.AddValue("Memory Location", memoryLocation, typeof(int));
            info.AddValue("Byte Value", byteValue, typeof(byte));
            info.AddValue("String Value", stringValue, typeof(String));
        }

        #endregion
    }
}
