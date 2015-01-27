using Net.Yingzxu.MarkdownDom.Base;
using Net.Yingzxu.MarkdownDom.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Yingzxu.MarkdownDom.PostProcess
{
    class PostProcessor
    {
        public static void PostProcess(MarkdownElementBase[] innerBlocks, MarkdownDocument root)
        {
            PostMergeBlockquotes(innerBlocks, root);
        }
        private static void PostMergeBlockquotes(MarkdownElementBase[] innerBlocks, MarkdownDocument root){
            BlockquoteElement currentPreceBlockquote = null;
            for (int i = 0; i < innerBlocks.Length; i++)
            {
                MarkdownElementBase innerBlock = innerBlocks[i];
                if (innerBlock.Type == ElementType.Blockquote)
                {
                    BlockquoteElement currentBlockquote = innerBlock as BlockquoteElement;
                    if (currentPreceBlockquote == null || currentPreceBlockquote.QuoteLevel < currentBlockquote.QuoteLevel)
                    {
                        currentPreceBlockquote = currentBlockquote;
                        root.AddChildElement(currentPreceBlockquote);
                    }
                    else
                    {
                        currentPreceBlockquote.AddChildrenElements(currentBlockquote.Children);
                    }

                }
                else
                {
                    if (innerBlock.Type != ElementType.BlankLine)
                        root.AddChildElement(innerBlock);
                    else
                    {
                        currentPreceBlockquote = null;
                    }
                }
            }
        }
    }
}
