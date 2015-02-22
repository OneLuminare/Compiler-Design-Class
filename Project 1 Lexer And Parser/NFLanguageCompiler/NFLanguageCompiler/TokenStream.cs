using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace NFLanguageCompiler
{
    // Represents the entire token stream. This is the output object of the lexer.
    // Basicly a wrapper for an ArrayList of Tokens, but type safe.
    [Serializable]
    public class TokenStream : IEnumerable, ISerializable
    {
        #region Data Members

        //Contains all tokens, of Token class type
        ArrayList tokenList;

        #endregion

        #region Properties

        //Indexer property. Treats token stream as an array, returning Token objects by index.
        public Token this[int index]
        {
            get
            {
                return GetToken(index);
            }

            set
            {
                SetToken(index, value);
            }
        }

        // Returns count. Read only.
        public int Count
        {
            get
            {
                return tokenList.Count;
            }
        }

        #endregion

        #region Constructors

        // Default constructor
        public TokenStream()
        {
            //Init array list
            tokenList = new ArrayList(250);
            
        }

        // Deserialization constructor.
        public TokenStream(SerializationInfo info, StreamingContext sc)
        {
            tokenList = (ArrayList)info.GetValue("TokenList", typeof(ArrayList));
        }

        #endregion

        #region Token Acces Members

        // Get Token by index. 
        // Throws: IndexOutOfRangeException
        public Token GetToken(int index)
        {
            if (index < tokenList.Count)
                return (Token)tokenList[index];
            else
                throw new IndexOutOfRangeException("Token stream index out of range.");
        }

        // Set token by index.
        // Throws: IndexOutOfRangeException
        public void SetToken(int index, Token token)
        {
            if (index < tokenList.Count)
                tokenList[index] = token;
            else
                throw new IndexOutOfRangeException("Token stream index out of range.");
        }

        // Remove token by index
        // Throws: IndexOutOfRangeException
        public void RemoveToken(int index)
        {
            if (index < tokenList.Count)
            {
                tokenList.RemoveAt(index);
            }
            else
                throw new IndexOutOfRangeException("Token stream index out of range.");
        }

        // Remove token by Token Object
        public void RemoveToken(Token token)
        {
            tokenList.Remove(token);
        }
        
        // Add token
        public int AddToken(Token token)
        {
            return tokenList.Add(token);
        }

        // Clear token list
        public void ClearTokens()
        {
            tokenList.Clear();
        }

        // Copy token stream from another
        public void Copy(TokenStream copy)
        {
            tokenList = (ArrayList)copy.tokenList.Clone();
        }
     
        #endregion

        #region IEnumerable Members

        // Gets enumerator from ArrayList
        IEnumerator IEnumerable.GetEnumerator()
        {
           return tokenList.GetEnumerator();
        }

        #endregion

        #region ISerializable Members

        // Serializable method. Describes how data is serialized.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TokenList", tokenList, typeof(ArrayList));
        }

        #endregion
    }
}
