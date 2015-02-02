using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Yingzxu.MarkdownDom.Base;

namespace Net.Yingzxu.MarkdownDom.Elements
{
    /// <summary>
    /// This class is only used in parser for passing variables
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class InternalElement<T> : MarkdownElementBase
    {
        public T Value { set; get; }
        public InternalElement()
            : base(ElementType.InlineText)
        {

        }

        public InternalElement(T value){
            this.Value = value;
        }
    }
}
