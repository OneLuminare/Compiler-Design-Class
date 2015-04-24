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
    public class SymbolTableEntry : ISerializable,IComparable<SymbolTableEntry>
    {
        #region Data Members

        private int entryID;
        private char id;
        private DataType type;
        private int memoryLocation;
        private byte byteValue;
        private String stringValue;
        private bool initialized;

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

        public bool BoolValue
        {
            get
            {
                if ((int)byteValue == 0)
                    return false;
                else
                    return true;
            }

            set
            {
                if (value)
                    byteValue = (byte)1;
                else
                    byteValue = (byte)0;
            }
        }

        // Prop for var init flag
        public bool Initialized
        {
            get { return initialized; }
            set { initialized = value; }
        }

        // Prop for entry ID
        public int EntryID
        {
            get { return entryID; }
            set { entryID = value; }
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
            initialized = false;
            entryID = 0;
        }

        //Set char value constructor
        public SymbolTableEntry(char id, DataType type, int memoryLocation, char value)
            : this( id,type,memoryLocation,(byte)value,String.Empty,false,0)
        {
        }

        //Set int value constructor
        public SymbolTableEntry(char id, DataType type, int memoryLocation, int value)
            : this(id, type, memoryLocation, (byte)value, String.Empty,false,0)
        {
        }

        //Set string value constructor
        public SymbolTableEntry(char id, DataType type, int memoryLocation, String value)
            : this(id, type, memoryLocation, (byte)0, value, false,0)
        {
        }

        //Master set constructor
        public SymbolTableEntry(char id, DataType type, int memoryLocation, byte byteValue, String stringValue,bool init,int entryID)
        {
            this.id = id;
            this.type = type;
            this.byteValue = byteValue;
            this.stringValue = stringValue;
            this.memoryLocation = memoryLocation;
            this.initialized = init;
            this.entryID = entryID;
        }

        //Deserialiaation constructor
        public SymbolTableEntry(SerializationInfo info, StreamingContext context)
        {
            id = (char)info.GetValue("ID", typeof(char));
            type = (DataType)info.GetValue("Type", typeof(DataType));
            memoryLocation = (int)info.GetValue("Memory Location", typeof(int));
            byteValue = (byte)info.GetValue("Byte Value", typeof(byte));
            stringValue = (String)info.GetValue("String Value", typeof(String));
            initialized = (bool)info.GetValue("Initialized", typeof(bool));
            entryID = (int)info.GetValue("EntryID", typeof(int));
        }

        #endregion

        #region Methods

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return String.Format("ID: {0} Entry ID: {1} Type: {2} Byte Value: {3} String Value: \"{4}\" Memory Location: {5} Initialized: {6}",id,entryID,type,byteValue,stringValue,memoryLocation,initialized);
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
            info.AddValue("Initialized", initialized, typeof(bool));
            info.AddValue("EntryID", entryID, typeof(int));
        }

        #endregion

        #region IComparable<SymbolTableEntry> Members

        public int CompareTo(SymbolTableEntry other)
        {
            return this.ID.CompareTo(other.ID);
        }

        #endregion
    }
}
