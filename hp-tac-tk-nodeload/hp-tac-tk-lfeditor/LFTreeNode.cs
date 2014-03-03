using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hp_tac_tk_lfeditor
{
    class LFTreeNode : TreeNode
    {
        private LFNode m_logicFlow;
        public LFNode LogicFlow { get { return m_logicFlow; } set { m_logicFlow = value; } }
        public LFTreeNode(LFNode lf)
        {
            this.Text = lf.Text;
            m_logicFlow = lf;
            this.Tag = lf;
        }

        public LFTreeNode()
        {
        }
    }
}
