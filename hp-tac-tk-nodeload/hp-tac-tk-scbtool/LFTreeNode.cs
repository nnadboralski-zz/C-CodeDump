using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hp_tac_tk_scbtool
{
    class LFTreeNode : TreeNode
    {
        public LFNode LogicFlow;
        public LFTreeNode(LFNode lf)
        {
            this.Text = lf.Text;
        }
    }
}
