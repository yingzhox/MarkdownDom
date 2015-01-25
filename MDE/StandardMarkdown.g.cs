//
// IronMeta StandardMarkdown Parser; Generated 2015-01-22 06:18:03Z UTC
//

using System;
using System.Collections.Generic;
using System.Linq;
using IronMeta.Matcher;
using Net.Yingzxu.MarkdownEverywhere;
using Net.Yingzxu.MarkdownEverywhere.Base;
using Net.Yingzxu.MarkdownEverywhere.Elements;

#pragma warning disable 0219
#pragma warning disable 1591

namespace MDE
{

    using _StandardMarkdown_Inputs = IEnumerable<char>;
    using _StandardMarkdown_Results = IEnumerable<MarkdownElementBase>;
    using _StandardMarkdown_Item = IronMeta.Matcher.MatchItem<char, MarkdownElementBase>;
    using _StandardMarkdown_Args = IEnumerable<IronMeta.Matcher.MatchItem<char, MarkdownElementBase>>;
    using _StandardMarkdown_Memo = Memo<char, MarkdownElementBase>;
    using _StandardMarkdown_Rule = System.Action<Memo<char, MarkdownElementBase>, int, IEnumerable<IronMeta.Matcher.MatchItem<char, MarkdownElementBase>>>;
    using _StandardMarkdown_Base = IronMeta.Matcher.Matcher<char, MarkdownElementBase>;

    public partial class StandardMarkdown : IronMeta.Matcher.CharMatcher<MarkdownElementBase>
    {
        public StandardMarkdown()
            : base()
        {
            _setTerminals();
        }

        public StandardMarkdown(bool handle_left_recursion)
            : base(handle_left_recursion)
        {
            _setTerminals();
        }

        void _setTerminals()
        {
            this.Terminals = new HashSet<string>()
            {
                "Block",
                "Document",
                "WS",
            };
        }


        public void Document(_StandardMarkdown_Memo _memo, int _index, _StandardMarkdown_Args _args)
        {

            _StandardMarkdown_Item block = null;

            // STAR 2
            int _start_i2 = _index;
            var _res2 = Enumerable.Empty<MarkdownElementBase>();
        label2:

            // CALLORVAR Block
            _StandardMarkdown_Item _r3;

            _r3 = _MemoCall(_memo, "Block", _index, Block, null);

            if (_r3 != null) _index = _r3.NextIndex;

            // STAR 2
            var _r2 = _memo.Results.Pop();
            if (_r2 != null)
            {
                _res2 = _res2.Concat(_r2.Results);
                goto label2;
            }
            else
            {
                _memo.Results.Push(new _StandardMarkdown_Item(_start_i2, _index, _memo.InputEnumerable, _res2.Where(_NON_NULL), true));
            }

            // BIND block
            block = _memo.Results.Peek();

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _StandardMarkdown_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { MarkdownDocument doc = new MarkdownDocument(); doc.AddChildElement(block); return doc; }, _r0), true) );
            }

        }


        public void Block(_StandardMarkdown_Memo _memo, int _index, _StandardMarkdown_Args _args)
        {

            // LITERAL 'a'
            _ParseLiteralChar(_memo, ref _index, 'a');

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _StandardMarkdown_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { BlockElement block = new BlockElement(); return block; }, _r0), true) );
            }

        }


        public void KW(_StandardMarkdown_Memo _memo, int _index, _StandardMarkdown_Args _args)
        {

            int _arg_index = 0;
            int _arg_input_index = 0;

            _StandardMarkdown_Item str = null;

            // ARGS 0
            _arg_index = 0;
            _arg_input_index = 0;

            // ANY
            _ParseAnyArgs(_memo, ref _arg_index, ref _arg_input_index, _args);

            // BIND str
            str = _memo.ArgResults.Peek();

            if (_memo.ArgResults.Pop() == null)
            {
                _memo.Results.Push(null);
                goto label0;
            }

            // AND 3
            int _start_i3 = _index;

            // CALLORVAR str
            _StandardMarkdown_Item _r4;

            if (str.Production != null)
            {
                var _p4 = (System.Action<_StandardMarkdown_Memo, int, IEnumerable<_StandardMarkdown_Item>>)(object)str.Production; // what type safety?
                _r4 = _MemoCall(_memo, str.Production.Method.Name, _index, _p4, null);
            }
            else
            {
                _r4 = _ParseLiteralObj(_memo, ref _index, str.Inputs);
            }

            if (_r4 != null) _index = _r4.NextIndex;

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label3; }

            // STAR 5
            int _start_i5 = _index;
            var _res5 = Enumerable.Empty<MarkdownElementBase>();
        label5:

            // CALLORVAR WS
            _StandardMarkdown_Item _r6;

            _r6 = _MemoCall(_memo, "WS", _index, WS, null);

            if (_r6 != null) _index = _r6.NextIndex;

            // STAR 5
            var _r5 = _memo.Results.Pop();
            if (_r5 != null)
            {
                _res5 = _res5.Concat(_r5.Results);
                goto label5;
            }
            else
            {
                _memo.Results.Push(new _StandardMarkdown_Item(_start_i5, _index, _memo.InputEnumerable, _res5.Where(_NON_NULL), true));
            }

        label3: // AND
            var _r3_2 = _memo.Results.Pop();
            var _r3_1 = _memo.Results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _memo.Results.Push( new _StandardMarkdown_Item(_start_i3, _index, _memo.InputEnumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i3;
            }

        label0: // ARGS 0
            _arg_input_index = _arg_index; // no-op for label

        }


        public void WS(_StandardMarkdown_Memo _memo, int _index, _StandardMarkdown_Args _args)
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

    } // class StandardMarkdown

} // namespace MDE

