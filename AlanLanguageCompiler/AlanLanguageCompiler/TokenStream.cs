using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlanLanguageCompiler
{
    public class TokenStream : IEnumerable
    {
        ArrayList tokenList;

        public TokenStream()
        {
            tokenList = new ArrayList(250);
            
        }

        public Token this[int index]
        {
            get
            {
                return GetToken(index);
            }

            set
            {
                SetToken(index,value);
            }
        }

        public Token GetToken(int index)
        {
            if (index < tokenList.Count)
                return (Token)tokenList[index];
            else
                return null;
        }

        public void SetToken(int index, Token token)
        {
            if (index < tokenList.Count)
                tokenList[index] = token;
        }

        public bool RemoveToken(int index)
        {
            if (index < tokenList.Count)
            {
                tokenList.RemoveAt(index);
                return true;
            }
            else
                return false;
        }

        public void RemoveToken(Token token)
        {
            tokenList.Remove(token);
        }

        public void AddToken(Token token)
        {
            tokenList.Add(token);
        }

        public void ClearTokens()
        {
            tokenList.Clear();
        }

        public void Copy(TokenStream copy)
        {
            tokenList = (ArrayList)copy.tokenList.Clone();
        }
        
        public int Count
        {
            get
            {
                return tokenList.Count;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return tokenList.GetEnumerator();
        }
    }
}
