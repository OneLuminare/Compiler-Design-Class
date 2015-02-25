using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DynamicBranchTree
{
    // Reperesents a DyanmicBranchTree node. Can have 
    // as many child nodes as needed. Stores all child
    // pointers in an array, and keeps track of how many
    // their are. Takes an generic type.
    [Serializable]
    public class DynamicBranchTreeNode<T>  where T : class 
    { 
        #region Data Members

        //Stores all nodes
        private ArrayList childNodes;
        public DynamicBranchTreeNode<T> Parent;
        public T Data;

        #endregion

        #region Properties


        public ArrayList Children
        {
            get
            {
                return childNodes;
            }
        }
        
        public int NodeCount
        {
            get
            {
                return Children.Count;
            }
        }


        #endregion

        #region Constructors

        //Default constructor. Inits objects.
        public DynamicBranchTreeNode()
        {
            childNodes = new ArrayList(3);
            Parent = null;
            Data = null;
        }

        //Sets data object, and calls default constructor
        public DynamicBranchTreeNode(T dataObject)
            : this()
        {
            Data = dataObject;
        }

        /*
        //Deserialization constructor.
        public DynamicBranchTreeNode(SerializationInfo info, StreamingContext context)
        {
            //Describe deserialization
            Data = (T)info.GetValue("Data", typeof(T));
            Children = (ArrayList)info.GetValue("Nodes", typeof(ArrayList));
            Parent = (DynamicBranchTreeNode<T>)info.GetValue("Parent", typeof(DynamicBranchTreeNode<T>));
        }
         * */

        #endregion

        #region Methods

        //Adds node
        public void AddChild(DynamicBranchTreeNode<T> node)
        {
            //Set parent node
            node.Parent = this;

            //Add to list
            childNodes.Add(node);
        }

        //Returns node at index.
        //
        //Throws: IndexOutOfRangeException
        public DynamicBranchTreeNode<T> GetChild(int index)
        {
            //Throw index out of range exception if bad index
            if (index >= NodeCount)
                throw new IndexOutOfRangeException("Node index out of range.");

            //Return node
            return (DynamicBranchTreeNode<T>)Children[index];
        }

        //Removes node at index.
        //
        //Throws: IndexOutOfRangeException
        public void RemoveChild(int index)
        {
            //Throw index out of range exception if bad index
            if (index >= NodeCount)
                throw new IndexOutOfRangeException("Node index out of range.");

            //Clear child
            GetChild(index).Clear();

            //Remove node and decrement count
            Children.RemoveAt(index);
        }

        //Removes child nodes, and their children
        public void Clear()
        {
            Clear(this);
            childNodes = new ArrayList(3);
        }

        //Recursive clear function
        private void Clear(DynamicBranchTreeNode<T> node)
        {
            //Cycle through children cand call clear
            for (int i = 0; i < node.NodeCount; i++)
            {
                node.GetChild(i).Parent = null;
                Clear(node.GetChild(i));
            }

            //Clear children array
            node.Children.Clear();

            //Return state
            return;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return Data.ToString();
        }

        #endregion

        #region ISerializable Members

        /*
        //Serialize method for ISerializable. Describes serialization.
        //
        //Throws: SerializationException if data type does not implement ISerializeable
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //Check if type T implements ISerializable
            if (Data is ISerializable)
            {
                //Describe serialization
                info.AddValue("Data", Data, typeof(T));
                info.AddValue("Nodes", Children , typeof(ArrayList));
                info.AddValue("Parent", Parent, typeof(DynamicBranchTreeNode<T>));
            }
            //If not throw exception
            else
                throw new SerializationException(String.Format("Data object of type '{0}' does not implememnt ISerializeable. Cannot serialize."
                        , Data.GetType().ToString()));
        }
         * */

        #endregion
    }
}
