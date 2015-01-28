using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Yingzxu.MarkdownDom.Base;

namespace Net.Yingzxu.MarkdownDom.Elements
{
    class UListElement : MarkdownElementBase
    {
        public bool IsOrderedList { set; get; }
        public UListElement()
            : base(ElementType.List)
        {

        }
    }
}
