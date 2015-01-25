using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Yingzxu.MarkdownDom.Base;

namespace Net.Yingzxu.MarkdownDom.Elements
{
    class BlockElement : MarkdownElementBase
    {
        public BlockElement()
            : base(ElementType.Block)
        {
        }
    }
}
