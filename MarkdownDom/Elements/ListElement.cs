using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Yingzxu.MarkdownDom.Base;

namespace Net.Yingzxu.MarkdownDom.Elements
{
    class ListElement : MarkdownElementBase
    {
        public bool IsOrderedList { set; get; }
        public ListElement()
            : base(ElementType.List)
        {

        }
    }
}
