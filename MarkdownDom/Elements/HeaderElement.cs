using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Yingzxu.MarkdownDom.Base;

namespace Net.Yingzxu.MarkdownDom.Elements
{
    class HeaderElement : MarkdownElementBase
    {

        public int Size { set; get; }
        public HeaderElement()
            : base(ElementType.Header)
        {
        }

        protected override string ToStringInternal()
        {
            return "HeaderSize:" + Size;
        }
    }
}
