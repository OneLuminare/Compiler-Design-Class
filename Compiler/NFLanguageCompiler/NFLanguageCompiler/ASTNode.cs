using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    #region Types

    // Describes type of ASTNode
    public enum ASTNodeType
    {
        ASTTYPE_INTOP,
        ASTTYPE_BOOLVAL,
        ASTTYPE_BOOLOP,
        ASTTYPE_INTVAL,
        ASTTYPE_CHAR,
        ASTTYPE_TYPE,
        ASTTYPE_CHARLIST,
        ASTTYPE_ID,
        ASTTYPE_EXPR,
        ASTTYPE_INTEXPR,
        ASTTYPE_STRINGEXPR,
        ASTTYPE_BOOLEANEXPR,
        ASTTYPE_STATEMENT,
        ASTTYPE_PRINTSTATEMENT,
        ASTTYPE_ASSIGNSTATEMENT,
        ASTTYPE_VARDEC,
        ASTTYPE_WHILESTATEMENT,
        ASTTYPE_IFSTATEMENT,
        ASTTYPE_BLOCK,
        ASTTYPE_STATEMENTLIST,
        ASTTYPE_PROGRAM,
        ASTTYPE_NONE
    };

    #endregion

    // Base class for all ASTNode types. Creates a pointer chain to syblings
    // with a left most sybling (head), right sybling (next), left most child (child head),
    // and parent. Hase methods to add sybling, and add child. These set all sybling or 
    // child node's pointers appropraitly.
    public class ASTNode
    {
        #region Data Members

        protected ASTNodeType nodeType;
        protected ASTNode leftMostSibling;
        protected ASTNode leftMostChild;
        protected ASTNode rightSibling;
        protected ASTNode parent;

        #endregion

        #region Properties

        public ASTNodeType NodeType
        {
            get { return nodeType; }
            set { nodeType = value; }
        }

        public ASTNode LeftMostSibling
        {
            get { return leftMostSibling; }
            set { leftMostSibling = value; }
        }

        public ASTNode LeftMostChild
        {
            get { return leftMostChild; }
            set { leftMostChild = value; }
        }

        public ASTNode RightSibling
        {
            get { return rightSibling; }
            set { rightSibling = value; }
        }

        public ASTNode Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        #endregion

        #region Constructors

        // Default constructor. Initializes data members.
        public ASTNode()
        {
            nodeType = ASTNodeType.ASTTYPE_NONE;
            leftMostSibling = this;
            leftMostChild = null;
            rightSibling = null;
            parent = null;
        }

        // Set type constructor.
        public ASTNode(ASTNodeType type)
            : this()
        {
            this.nodeType = type;
        }

        #endregion

        #region Methods

        // Determines total number of children. 
        // This is usefull for block statments 
        // and determining when to leave scope on 
        // parent symbol table node
        //
        // Returns: Number of children
        public int TotalChildren()
        {
            // Inits
            int children = 0;
            ASTNode curASTnode = null;

            // Cycle through children while counting
            curASTnode = this.leftMostChild;
            while (curASTnode != null)
            {
                children++;
                curASTnode = curASTnode.rightSibling;
            }

            // Return child count
            return children;
        }

        // Makes node a sybling of this node,
        // and sets approprate pointers to 
        // left most sybling, right sybling,
        // and parent. Links entire sybling 
        // chain.
        //
        // Returns: Right most sybling in chain.
        public ASTNode MakeSybling( ASTNode node )
        {
            // Inits
            ASTNode curLeftSybling = node.leftMostSibling;
            ASTNode curRightSybling = this;

            // Get right most sybling of this node
            while (curRightSybling.rightSibling != null)
            {
                curRightSybling = curRightSybling.rightSibling;
            }

            // Link symbling chain
            curRightSybling.rightSibling = curLeftSybling;

            // Set lefmost sybling and parent for new sybling
            curLeftSybling.leftMostSibling = curRightSybling.leftMostSibling;
            curLeftSybling.parent = parent;
            while (curLeftSybling.rightSibling != null)
            {
                curLeftSybling = curLeftSybling.rightSibling;
                curLeftSybling.leftMostSibling = curRightSybling.leftMostSibling;
                curLeftSybling.parent = parent;
            }

            // Return right most sybling
            return curLeftSybling;
        }

        // Adopts child node, and sets approprate
        // pointers to leftmost child. Links child 
        // nodes togther via their pointers.
        //
        // Returns: Parent of this node.
        public ASTNode AdoptChild(ASTNode node)
        {
            // Inits
            ASTNode curLeftSybling = null;

            //Check if this node has a child
            if (this.leftMostChild != null)
            {
                // Make node a sybling to child
                this.leftMostChild.MakeSybling(node);
            }
            // Else set as left most child, and set all child syblings parent to this
            else
            {
                // Get nodes left most sybling
                curLeftSybling = node.leftMostSibling;

                // Set node as left most child
                this.leftMostChild = curLeftSybling;
                
                // Set node and all symbling's parent to this
                while (curLeftSybling != null)
                {
                    curLeftSybling.parent = this;
                    curLeftSybling = curLeftSybling.rightSibling;
                }
            }

            // Return parent
            return parent;
        }

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            ret = "Base AST Node";

            return ret;
        }

        #endregion

        #endregion
    }
}
