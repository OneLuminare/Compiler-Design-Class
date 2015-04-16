using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace NFLanguageCompiler
{
    // A basic hash table that hashes on char id name. 
    // For use with symbol table nodes.
    public class SymbolHashTable
    {
        #region Data Members

        SymbolTableEntry[] array = new SymbolTableEntry[26];

        #endregion

        #region Methods

        // Adds item to hash set. Will not add if entry exists.
        // Hashes char id.
        //
        // Returns: True on successful add with no collision.
        // Throws: IndexOutOfRangeException - on invalid char id key
        public bool AddItem(SymbolTableEntry entry)
        {
            // Inits
            int index = (int)Char.ToLower(entry.ID) - 97;
            bool ret = false;

            // Verify index
            if (index < 26 && index > -1)
            {
                // Check if no collision
                if (array[index] == null)
                {
                    // Set new item
                    array[index] = entry;

                    // Set return value
                    ret = true;
                }
            }
            else
                throw new IndexOutOfRangeException("Symbol table entry ID out of range. Must be a char between a - z.");

            // Return true if no collision
            return ret;
        }

        // Gets item based on hashed char.
        //
        // Throws: IndexOutOfRangeException
        // Returns: Entry or null.
        public SymbolTableEntry GetItem(char key)
        {
            // Inits
            SymbolTableEntry retEntry = null;
            int index = (int)Char.ToLower(key) - 97;

            // Check if index is in range, and throw exception if out of bounds
            if (index < 26 && index > -1)
            {
                // Check if data at index, and seet ret
                retEntry = array[index];
            }
            else
                throw new IndexOutOfRangeException("Symbol table entry ID out of range. Must be a char between a - z.");

            // Return entry in hash table or null
            return retEntry;
        }

        // Gets all items as an array
        //
        // Returns: Array of SymbolTableEntry 's
        public SymbolTableEntry[] GetAllItems()
        {
            // Inits
            ArrayList items = new ArrayList();
            SymbolTableEntry curEntry = null;
            SymbolTableEntry[] retItems = null;

            // Cycle through entries
            for (int i = 0; i < array.Length; i++)
            {
                // Get entry
                curEntry = array[i];

                // Check if entry exists
                if (curEntry != null)
                {
                    // Add to temp array list
                    items.Add(curEntry);               
                }    
            }

            // Create a new array for return 
            retItems = new SymbolTableEntry[items.Count];

            // Copy found items into new array
            for (int i = 0; i < items.Count; i++)
                retItems[i] = (SymbolTableEntry)items[i];

            // Return arrray of items
            return retItems;
        }

        // Get item at index. 
        //
        // Returns: Item at index, or null.
        // Throws: IndexOutOfRangeException - on invalid char id key
        public SymbolTableEntry GetItemAt(int index)
        {
            // Inits
            SymbolTableEntry ret = null;

            // Check index and throw exception if out of bounds
            if (index < 26 && index > -1)
            {
                // Get value
                ret = array[index];
            }
            else
                throw new IndexOutOfRangeException("Symbol table index out of range.");


            // Return value
            return ret;
        }

        // Check if entry exists at hashed index.
        //
        // Returns: True if etry exists at hashed id index
        // Throws: IndexOutOfRangeException - on invalid char id key
        public bool CheckCollision(SymbolTableEntry entry)
        {
            return CheckCollision(entry.ID);
        }

        // Check if entry exists at hashed index.
        //
        // Returns: True if etry exists at hashed id index
        // Throws: IndexOutOfRangeException - on invalid char id key
        public bool CheckCollision(char key)
        {
            // Inits
            bool ret = false;
            int index = (int)Char.ToLower(key) - 97;

            // Check if index is in range, and throw exception if out of bounds
            if (index < 26 && index > -1)
            {
                // Check if data at index, and seet ret
                if (array[index] != null)
                    ret = true;
            }
            else
                throw new IndexOutOfRangeException("Symbol table entry ID out of range. Must be a char between a - z.");

            // Return true if entry at hashed index
            return ret;
        }

        // Removes item at index.
        //
        // Returns: True if removed item.
        // Throws: IndexOutOfRangeException - on invalid char id key
        public bool RemoveItem(int index)
        {
            // Inits
            bool ret = false;
            
            // Check index, and through exception if index out of range
            if (index < 26 && index > -1)
            {
                // Remove item and set ret
                array[index] = null;
                ret = true;
            }
            else
                throw new IndexOutOfRangeException("Symbol table index out of range.");

            // Return true if removed item
            return ret;

        }

        // Removes item at index.
        //
        // Returns: True if removed item.
        // Throws: IndexOutOfRangeException - on invalid char id key
        public bool RemoveItem(SymbolTableEntry entry)
        {
            // Inits
            bool ret = false;
            int index = (int)Char.ToLower(entry.ID) - 97;

            // Check index, and through exception if index out of range
            if (index < 26 && index > -1)
            {
                // Remove item and set ret
                array[index] = null;
                ret = true;
            }
            else
                throw new IndexOutOfRangeException("Symbol table entry ID out of range. Must be a char between a - z.");

            // Return true if removed item
            return ret;
        }

        // Remove all items
        public void RemoveAllItems()
        {
            // Cycle through items and remove
            for (int i = 0; i < 26; i++)
                array[i] = null;
        }

        // Counts valid items(non null).
        //
        // Returns: Count of entrys.
        public int Count()
        {
            // Inits
            int count = 0;

            // Cycle through array
            for (int i = 0; i < array.Length; i++)
            {
                // Check if entry exists
                if (array[i] != null)
                {
                    // Inc count
                    count++;
                }
            }

            // Return count of entrys
            return count;
        }

        #endregion
    }
}
