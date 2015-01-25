using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Yingzxu.MarkdownDom.Base;

namespace Net.Yingzxu.MarkdownDom
{
    public class MarkdownDocument : MarkdownElementBase
    {
        public MarkdownDocument()
            : base(ElementType.Document)
        {
        }
    }
}
