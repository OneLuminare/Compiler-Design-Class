using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace DynamicBranchTree
{
    // Reperesents a DyanmicBranchTree node. Can have 
    // as many child nodes as needed. Stores all child
    // pointers in an array, and keeps track of how many
    // their are. Takes an generic type.
    public class DynamicBranchTreeNode<T>
    {
        #region Data Members

        //Stores all nodes
        private ArrayList Nodes;

        //Stores data for node, in generic type T
        private T DataObject;

        #endregion

        #region Properties
        
        //Access data object, in generic type T
        public T Data
        {
            get
            {
                return DataObject;
            }

            set
            {
                DataObject = value;
            }
        }

        //Returns node count
        public int NodeCount
        {
            get
            {
                return Nodes.Count;
            }
        }

        //Returns data type
        public Type DataType
        {
            get
            {
                DataObject.GetType();
            }
        }

        #endregion

        #region Constructors

        //Default constructor. Inits objects.
        public DynamicBranchTreeNode()
        {
            Nodes = new ArrayList(3);
        }

        //Sets data object, 
        public DynamicBranchTreeNode(T dataObject)
            : this()
        {
            DataObject = dataObject;
        }

        #endregion

        #region Methods

        #endregion


    }
}
