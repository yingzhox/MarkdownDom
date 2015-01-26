//
// IronMeta GithubMarkdown Parser; Generated 2015-01-26 05:49:03Z UTC
//

using System;
using System.Collections.Generic;
using System.Linq;
using IronMeta.Matcher;
using Net.Yingzxu.MarkdownDom;
using Net.Yingzxu.MarkdownDom.Base;
using Net.Yingzxu.MarkdownDom.Elements;

#pragma warning disable 0219
#pragma warning disable 1591

namespace Net.Yingzxu.MarkdownDom.Parser
{

    using _GithubMarkdown_Inputs = IEnumerable<char>;
    using _GithubMarkdown_Results = IEnumerable<MarkdownElementBase>;
    using _GithubMarkdown_Item = IronMeta.Matcher.MatchItem<char, MarkdownElementBase>;
    using _GithubMarkdown_Args = IEnumerable<IronMeta.Matcher.MatchItem<char, MarkdownElementBase>>;
    using _GithubMarkdown_Memo = Memo<char, MarkdownElementBase>;
    using _GithubMarkdown_Rule = System.Action<Memo<char, MarkdownElementBase>, int, IEnumerable<IronMeta.Matcher.MatchItem<char, MarkdownElementBase>>>;
    using _GithubMarkdown_Base = IronMeta.Matcher.Matcher<char, MarkdownElementBase>;

    public partial class GithubMarkdown : IronMeta.Matcher.CharMatcher<MarkdownElementBase>
    {
        public GithubMarkdown()
            : base()
        {
            _setTerminals();
        }

        public GithubMarkdown(bool handle_left_recursion)
            : base(handle_left_recursion)
        {
            _setTerminals();
        }

        void _setTerminals()
        {
            this.Terminals = new HashSet<string>()
            {
                "BlockquoteSymbol",
                "DG",
                "EN",
                "EOF",
                "Head",
                "HeadSymbol",
                "HeadText",
                "InlineText",
                "LineBreak",
                "Paragraph",
                "WS",
            };
        }


        public void Document(_GithubMarkdown_Memo _memo, int _index, _GithubMarkdown_Args _args)
        {
        

            _GithubMarkdown_Item block = null;

            // AND 1
            int _start_i1 = _index;

            // STAR 3
            int _start_i3 = _index;
            var _res3 = Enumerable.Empty<MarkdownElementBase>();
        label3:

            // CALLORVAR Block
            _GithubMarkdown_Item _r4;

            _r4 = _MemoCall(_memo, "Block", _index, Block, null);

            if (_r4 != null) _index = _r4.NextIndex;

            // STAR 3
            var _r3 = _memo.Results.Pop();
            if (_r3 != null)
            {
                _res3 = _res3.Concat(_r3.Results);
                goto label3;
            }
            else
            {
                _memo.Results.Push(new _GithubMarkdown_Item(_start_i3, _index, _memo.InputEnumerable, _res3.Where(_NON_NULL), true));
            }

            // BIND block
            block = _memo.Results.Peek();

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // CALLORVAR EOF
            _GithubMarkdown_Item _r5;

            _r5 = _MemoCall(_memo, "EOF", _index, EOF, null);

            if (_r5 != null) _index = _r5.NextIndex;

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _GithubMarkdown_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _GithubMarkdown_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { MarkdownDocument root = new MarkdownDocument(); 
        root.AddChildrenElements(block.Results.AsEnumerable<MarkdownElementBase>());
        return root; }, _r0), true) );
            }

        }


        public void Block(_GithubMarkdown_Memo _memo, int _index, _GithubMarkdown_Args _args)
        {
        

            _GithubMarkdown_Item head = null;
            _GithubMarkdown_Item quote = null;
            _GithubMarkdown_Item para = null;

            // OR 0
            int _start_i0 = _index;

            // OR 1
            int _start_i1 = _index;

            // OR 2
            int _start_i2 = _index;

            // CALLORVAR LineBreak
            _GithubMarkdown_Item _r3;

            _r3 = _MemoCall(_memo, "LineBreak", _index, LineBreak, null);

            if (_r3 != null) _index = _r3.NextIndex;

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i2; } else goto label2;

            // CALLORVAR Head
            _GithubMarkdown_Item _r6;

            _r6 = _MemoCall(_memo, "Head", _index, Head, null);

            if (_r6 != null) _index = _r6.NextIndex;

            // BIND head
            head = _memo.Results.Peek();

            // ACT
            var _r4 = _memo.Results.Peek();
            if (_r4 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _GithubMarkdown_Item(_r4.StartIndex, _r4.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return head; }, _r4), true) );
            }

        label2: // OR
            int _dummy_i2 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i1; } else goto label1;

            // CALLORVAR Blockquote
            _GithubMarkdown_Item _r9;

            _r9 = _MemoCall(_memo, "Blockquote", _index, Blockquote, null);

            if (_r9 != null) _index = _r9.NextIndex;

            // BIND quote
            quote = _memo.Results.Peek();

            // ACT
            var _r7 = _memo.Results.Peek();
            if (_r7 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _GithubMarkdown_Item(_r7.StartIndex, _r7.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return quote; }, _r7), true) );
            }

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR Paragraph
            _GithubMarkdown_Item _r12;

            _r12 = _MemoCall(_memo, "Paragraph", _index, Paragraph, null);

            if (_r12 != null) _index = _r12.NextIndex;

            // BIND para
            para = _memo.Results.Peek();

            // ACT
            var _r10 = _memo.Results.Peek();
            if (_r10 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _GithubMarkdown_Item(_r10.StartIndex, _r10.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return para; }, _r10), true) );
            }

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void Head(_GithubMarkdown_Memo _memo, int _index, _GithubMarkdown_Args _args)
        {
        

            _GithubMarkdown_Item symbol = null;
            _GithubMarkdown_Item text = null;

            // AND 1
            int _start_i1 = _index;

            // CALLORVAR HeadSymbol
            _GithubMarkdown_Item _r3;

            _r3 = _MemoCall(_memo, "HeadSymbol", _index, HeadSymbol, null);

            if (_r3 != null) _index = _r3.NextIndex;

            // BIND symbol
            symbol = _memo.Results.Peek();

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // CALLORVAR HeadText
            _GithubMarkdown_Item _r5;

            _r5 = _MemoCall(_memo, "HeadText", _index, HeadText, null);

            if (_r5 != null) _index = _r5.NextIndex;

            // BIND text
            text = _memo.Results.Peek();

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _GithubMarkdown_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _GithubMarkdown_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { HeaderElement head = new HeaderElement(); 
            head.Size=symbol.Results.First().TextContent.Length;
            head.TextContent=text.Results.First().TextContent;
            //remove the tailing #
            head.TextContent=head.TextContent.TrimEnd('#');
            return head; }, _r0), true) );
            }

        }


        public void Paragraph(_GithubMarkdown_Memo _memo, int _index, _GithubMarkdown_Args _args)
        {
        

            _GithubMarkdown_Item text = null;

            // CALLORVAR InlineText
            _GithubMarkdown_Item _r2;

            _r2 = _MemoCall(_memo, "InlineText", _index, InlineText, null);

            if (_r2 != null) _index = _r2.NextIndex;

            // BIND text
            text = _memo.Results.Peek();

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _GithubMarkdown_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { GeneralElement para = new GeneralElement(ElementType.Paragraph); 
            para.TextContent=text.Results.First().TextContent;
            return para; }, _r0), true) );
            }

        }


        public void Blockquote(_GithubMarkdown_Memo _memo, int _index, _GithubMarkdown_Args _args)
        {
        

            _GithubMarkdown_Item symbol = null;
            _GithubMarkdown_Item inner = null;
            _GithubMarkdown_Item children = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // AND 3
            int _start_i3 = _index;

            // CALLORVAR BlockquoteSymbol
            _GithubMarkdown_Item _r5;

            _r5 = _MemoCall(_memo, "BlockquoteSymbol", _index, BlockquoteSymbol, null);

            if (_r5 != null) _index = _r5.NextIndex;

            // BIND symbol
            symbol = _memo.Results.Peek();

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label3; }

            // STAR 7
            int _start_i7 = _index;
            var _res7 = Enumerable.Empty<MarkdownElementBase>();
        label7:

            // OR 8
            int _start_i8 = _index;

            // CALLORVAR Head
            _GithubMarkdown_Item _r9;

            _r9 = _MemoCall(_memo, "Head", _index, Head, null);

            if (_r9 != null) _index = _r9.NextIndex;

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i8; } else goto label8;

            // CALLORVAR Paragraph
            _GithubMarkdown_Item _r10;

            _r10 = _MemoCall(_memo, "Paragraph", _index, Paragraph, null);

            if (_r10 != null) _index = _r10.NextIndex;

        label8: // OR
            int _dummy_i8 = _index; // no-op for label

            // STAR 7
            var _r7 = _memo.Results.Pop();
            if (_r7 != null)
            {
                _res7 = _res7.Concat(_r7.Results);
                goto label7;
            }
            else
            {
                _memo.Results.Push(new _GithubMarkdown_Item(_start_i7, _index, _memo.InputEnumerable, _res7.Where(_NON_NULL), true));
            }

            // BIND inner
            inner = _memo.Results.Peek();

        label3: // AND
            var _r3_2 = _memo.Results.Pop();
            var _r3_1 = _memo.Results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _memo.Results.Push( new _GithubMarkdown_Item(_start_i3, _index, _memo.InputEnumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i3;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // CALLORVAR LineBreak
            _GithubMarkdown_Item _r12;

            _r12 = _MemoCall(_memo, "LineBreak", _index, LineBreak, null);

            if (_r12 != null) _index = _r12.NextIndex;

            // QUES
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _memo.Results.Push(new _GithubMarkdown_Item(_index, _memo.InputEnumerable)); }

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _GithubMarkdown_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // STAR 14
            int _start_i14 = _index;
            var _res14 = Enumerable.Empty<MarkdownElementBase>();
        label14:

            // AND 15
            int _start_i15 = _index;

            // OR 16
            int _start_i16 = _index;

            // AND 17
            int _start_i17 = _index;

            // STAR 18
            int _start_i18 = _index;
            var _res18 = Enumerable.Empty<MarkdownElementBase>();
        label18:

            // CALLORVAR LineBreak
            _GithubMarkdown_Item _r19;

            _r19 = _MemoCall(_memo, "LineBreak", _index, LineBreak, null);

            if (_r19 != null) _index = _r19.NextIndex;

            // STAR 18
            var _r18 = _memo.Results.Pop();
            if (_r18 != null)
            {
                _res18 = _res18.Concat(_r18.Results);
                goto label18;
            }
            else
            {
                _memo.Results.Push(new _GithubMarkdown_Item(_start_i18, _index, _memo.InputEnumerable, _res18.Where(_NON_NULL), true));
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label17; }

            // CALLORVAR Blockquote
            _GithubMarkdown_Item _r20;

            _r20 = _MemoCall(_memo, "Blockquote", _index, Blockquote, null);

            if (_r20 != null) _index = _r20.NextIndex;

        label17: // AND
            var _r17_2 = _memo.Results.Pop();
            var _r17_1 = _memo.Results.Pop();

            if (_r17_1 != null && _r17_2 != null)
            {
                _memo.Results.Push( new _GithubMarkdown_Item(_start_i17, _index, _memo.InputEnumerable, _r17_1.Results.Concat(_r17_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i17;
            }

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i16; } else goto label16;

            // CALLORVAR Paragraph
            _GithubMarkdown_Item _r21;

            _r21 = _MemoCall(_memo, "Paragraph", _index, Paragraph, null);

            if (_r21 != null) _index = _r21.NextIndex;

        label16: // OR
            int _dummy_i16 = _index; // no-op for label

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label15; }

            // CALLORVAR LineBreak
            _GithubMarkdown_Item _r23;

            _r23 = _MemoCall(_memo, "LineBreak", _index, LineBreak, null);

            if (_r23 != null) _index = _r23.NextIndex;

            // QUES
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _memo.Results.Push(new _GithubMarkdown_Item(_index, _memo.InputEnumerable)); }

        label15: // AND
            var _r15_2 = _memo.Results.Pop();
            var _r15_1 = _memo.Results.Pop();

            if (_r15_1 != null && _r15_2 != null)
            {
                _memo.Results.Push( new _GithubMarkdown_Item(_start_i15, _index, _memo.InputEnumerable, _r15_1.Results.Concat(_r15_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i15;
            }

            // STAR 14
            var _r14 = _memo.Results.Pop();
            if (_r14 != null)
            {
                _res14 = _res14.Concat(_r14.Results);
                goto label14;
            }
            else
            {
                _memo.Results.Push(new _GithubMarkdown_Item(_start_i14, _index, _memo.InputEnumerable, _res14.Where(_NON_NULL), true));
            }

            // BIND children
            children = _memo.Results.Peek();

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _GithubMarkdown_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _GithubMarkdown_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { BlockquoteElement block = new BlockquoteElement(); 
            block.QuoteLevel=symbol.Results.First().TextContent.Length;
            block.AddChildrenElements(inner.Results.AsEnumerable<MarkdownElementBase>());
            IEnumerable<MarkdownElementBase> innerBlocks =  children.Results.AsEnumerable<MarkdownElementBase>();
            foreach (MarkdownElementBase innerBlock in innerBlocks)
            {
                if (innerBlock.Type == ElementType.Blockquote && (innerBlock as BlockquoteElement).QuoteLevel <= block.QuoteLevel)
                {
                    block.AddChildrenElements(innerBlock.Children);
                }
                else
                {
                    block.AddChildElement(innerBlock);
                }
            }
            return block; }, _r0), true) );
            }

        }


        public void LineBreak(_GithubMarkdown_Memo _memo, int _index, _GithubMarkdown_Args _args)
        {
        

            // OR 0
            int _start_i0 = _index;

            // AND 1
            int _start_i1 = _index;

            // LITERAL '\r'
            _ParseLiteralChar(_memo, ref _index, '\r');

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // LITERAL '\n'
            _ParseLiteralChar(_memo, ref _index, '\n');

            // QUES
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _memo.Results.Push(new _GithubMarkdown_Item(_index, _memo.InputEnumerable)); }

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _GithubMarkdown_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i0; } else goto label0;

            // LITERAL '\n'
            _ParseLiteralChar(_memo, ref _index, '\n');

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void HeadText(_GithubMarkdown_Memo _memo, int _index, _GithubMarkdown_Args _args)
        {
        

            // STAR 1
            int _start_i1 = _index;
            var _res1 = Enumerable.Empty<MarkdownElementBase>();
        label1:

            // AND 2
            int _start_i2 = _index;

            // NOT 3
            int _start_i3 = _index;

            // CALLORVAR LineBreak
            _GithubMarkdown_Item _r4;

            _r4 = _MemoCall(_memo, "LineBreak", _index, LineBreak, null);

            if (_r4 != null) _index = _r4.NextIndex;

            // NOT 3
            var _r3 = _memo.Results.Pop();
            _memo.Results.Push( _r3 == null ? new _GithubMarkdown_Item(_start_i3, _memo.InputEnumerable) : null);
            _index = _start_i3;

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // ANY
            _ParseAny(_memo, ref _index);

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _GithubMarkdown_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // STAR 1
            var _r1 = _memo.Results.Pop();
            if (_r1 != null)
            {
                _res1 = _res1.Concat(_r1.Results);
                goto label1;
            }
            else
            {
                _memo.Results.Push(new _GithubMarkdown_Item(_start_i1, _index, _memo.InputEnumerable, _res1.Where(_NON_NULL), true));
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _GithubMarkdown_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { string match=Input(_IM_Result) ;
        GeneralElement text = new GeneralElement(ElementType.Text); 
        text.TextContent=match;
        return text; }, _r0), true) );
            }

        }


        public void InlineText(_GithubMarkdown_Memo _memo, int _index, _GithubMarkdown_Args _args)
        {
        

            // PLUS 1
            int _start_i1 = _index;
            var _res1 = Enumerable.Empty<MarkdownElementBase>();
        label1:

            // AND 2
            int _start_i2 = _index;

            // NOT 3
            int _start_i3 = _index;

            // OR 4
            int _start_i4 = _index;

            // LITERAL '\n'
            _ParseLiteralChar(_memo, ref _index, '\n');

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i4; } else goto label4;

            // LITERAL '\r'
            _ParseLiteralChar(_memo, ref _index, '\r');

        label4: // OR
            int _dummy_i4 = _index; // no-op for label

            // NOT 3
            var _r3 = _memo.Results.Pop();
            _memo.Results.Push( _r3 == null ? new _GithubMarkdown_Item(_start_i3, _memo.InputEnumerable) : null);
            _index = _start_i3;

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // ANY
            _ParseAny(_memo, ref _index);

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _GithubMarkdown_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // PLUS 1
            var _r1 = _memo.Results.Pop();
            if (_r1 != null)
            {
                _res1 = _res1.Concat(_r1.Results);
                goto label1;
            }
            else
            {
                if (_index > _start_i1)
                    _memo.Results.Push(new _GithubMarkdown_Item(_start_i1, _index, _memo.InputEnumerable, _res1.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _GithubMarkdown_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { string match=Input(_IM_Result) ;
        GeneralElement text = new GeneralElement(ElementType.Text); 
        text.TextContent=match;
        return text; }, _r0), true) );
            }

        }


        public void HeadSymbol(_GithubMarkdown_Memo _memo, int _index, _GithubMarkdown_Args _args)
        {
        

            // PLUS 1
            int _start_i1 = _index;
            var _res1 = Enumerable.Empty<MarkdownElementBase>();
        label1:

            // LITERAL '#'
            _ParseLiteralChar(_memo, ref _index, '#');

            // PLUS 1
            var _r1 = _memo.Results.Pop();
            if (_r1 != null)
            {
                _res1 = _res1.Concat(_r1.Results);
                goto label1;
            }
            else
            {
                if (_index > _start_i1)
                    _memo.Results.Push(new _GithubMarkdown_Item(_start_i1, _index, _memo.InputEnumerable, _res1.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _GithubMarkdown_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { string match=Input(_IM_Result) ;
        GeneralElement text = new GeneralElement(ElementType.Text); 
        text.TextContent=match;
        return text; }, _r0), true) );
            }

        }


        public void BlockquoteSymbol(_GithubMarkdown_Memo _memo, int _index, _GithubMarkdown_Args _args)
        {
        

            // PLUS 1
            int _start_i1 = _index;
            var _res1 = Enumerable.Empty<MarkdownElementBase>();
        label1:

            // LITERAL '>'
            _ParseLiteralChar(_memo, ref _index, '>');

            // PLUS 1
            var _r1 = _memo.Results.Pop();
            if (_r1 != null)
            {
                _res1 = _res1.Concat(_r1.Results);
                goto label1;
            }
            else
            {
                if (_index > _start_i1)
                    _memo.Results.Push(new _GithubMarkdown_Item(_start_i1, _index, _memo.InputEnumerable, _res1.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _GithubMarkdown_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { string match=Input(_IM_Result) ;
        GeneralElement text = new GeneralElement(ElementType.Text); 
        text.TextContent=match;
        return text; }, _r0), true) );
            }

        }


        public void DG(_GithubMarkdown_Memo _memo, int _index, _GithubMarkdown_Args _args)
        {
        

            // INPUT CLASS
            _ParseInputClass(_memo, ref _index, '\u0030', '\u0031', '\u0032', '\u0033', '\u0034', '\u0035', '\u0036', '\u0037', '\u0038', '\u0039');

        }


        public void EN(_GithubMarkdown_Memo _memo, int _index, _GithubMarkdown_Args _args)
        {
        

            // OR 0
            int _start_i0 = _index;

            // INPUT CLASS
            _ParseInputClass(_memo, ref _index, '\u0061', '\u0062', '\u0063', '\u0064', '\u0065', '\u0066', '\u0067', '\u0068', '\u0069', '\u006a', '\u006b', '\u006c', '\u006d', '\u006e', '\u006f', '\u0070', '\u0071', '\u0072', '\u0073', '\u0074', '\u0075', '\u0076', '\u0077', '\u0078', '\u0079', '\u007a');

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i0; } else goto label0;

            // INPUT CLASS
            _ParseInputClass(_memo, ref _index, '\u0041', '\u0042', '\u0043', '\u0044', '\u0045', '\u0046', '\u0047', '\u0048', '\u0049', '\u004a', '\u004b', '\u004c', '\u004d', '\u004e', '\u004f', '\u0050', '\u0051', '\u0052', '\u0053', '\u0054', '\u0055', '\u0056', '\u0057', '\u0058', '\u0059', '\u005a');

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void WS(_GithubMarkdown_Memo _memo, int _index, _GithubMarkdown_Args _args)
        {
        

            // OR 0
            int _start_i0 = _index;

            // OR 1
            int _start_i1 = _index;

            // OR 2
            int _start_i2 = _index;

            // LITERAL ' '
            _ParseLiteralChar(_memo, ref _index, ' ');

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i2; } else goto label2;

            // LITERAL '\n'
            _ParseLiteralChar(_memo, ref _index, '\n');

        label2: // OR
            int _dummy_i2 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i1; } else goto label1;

            // LITERAL '\r'
            _ParseLiteralChar(_memo, ref _index, '\r');

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i0; } else goto label0;

            // LITERAL '\t'
            _ParseLiteralChar(_memo, ref _index, '\t');

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void EOF(_GithubMarkdown_Memo _memo, int _index, _GithubMarkdown_Args _args)
        {
        

            // NOT 0
            int _start_i0 = _index;

            // ANY
            _ParseAny(_memo, ref _index);

            // NOT 0
            var _r0 = _memo.Results.Pop();
            _memo.Results.Push( _r0 == null ? new _GithubMarkdown_Item(_start_i0, _memo.InputEnumerable) : null);
            _index = _start_i0;

        }

    } // class GithubMarkdown

} // namespace Net.Yingzxu.MarkdownDom.Parser

