using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Yingzxu.MarkdownDom.Base;

namespace Net.Yingzxu.MarkdownDom.Elements
{
    class BlockquoteElement : MarkdownElementBase
    {
        public int QuoteLevel { set; get; }
        public BlockquoteElement()
            : base(ElementType.Blockquote)
        {
        }
    }
}
