using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Yingzxu.MarkdownDom.Base
{
    public enum ElementType
    {
        Document,
        Blockquote,
        Paragraph,
        Text,
        Header,
        Blank
    };

    public abstract class MarkdownElementBase
    {
       

        protected List<MarkdownElementBase> children;
        public string TextContent { set; get; }
        public ElementType Type { set; get; }
        
        public void AddChildElement(MarkdownElementBase el)
        {
            this.children.Add(el);
        }

        public void AddChildrenElements(IEnumerable<MarkdownElementBase> els)
        {
            this.children.AddRange(els);
        }

        public MarkdownElementBase(ElementType type)
        {
            children = new List<MarkdownElementBase>();
            Type = type;
        }

        public List<MarkdownElementBase> Children
        {
            get { return children; }
        }

        protected MarkdownElementBase()
        {

        }

        protected virtual string ToStringInternal()
        {
            return "";

        }
        private string ToString(int no, int level)
        {
            StringBuilder res = new StringBuilder();
            string number = ("[" + no + "]").PadLeft(level + 1);
            string indent = "".PadLeft(number.Length);
            res.Append(number).Append("NodeType:").Append(this.GetType().Name).Append(" - ").Append(Type.ToString()).Append('\n');
            if (!string.IsNullOrEmpty(this.TextContent))
                res.Append(indent).Append("NodeText:").Append(this.TextContent).Append('\n');
            string internalStr = this.ToStringInternal();
            if (!string.IsNullOrEmpty(internalStr))
                res.Append(indent).Append(internalStr).Append('\n');
            if (children.Count > 0)
            {
                res.Append(indent).Append("Children:\n");
                for (int i = 0; i < children.Count; i++)
                {
                    MarkdownElementBase el = children[i];
                    res.Append(el.ToString(i + 1, number.Length + 2));
                }

                res.Append('\n');
            }

            return res.ToString();
        }

        public override string ToString()
        {
            return ToString(0,0);
        }
    }
}
