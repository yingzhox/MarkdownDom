using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Yingzxu.MarkdownDom.Base;

namespace Net.Yingzxu.MarkdownDom.Elements
{
    class GeneralElement : MarkdownElementBase
    {
        public GeneralElement(ElementType type)
            : base(type)
        {

        }

        public GeneralElement()
            : base(ElementType.Blank)
        {
        }
    }
}
