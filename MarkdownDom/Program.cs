﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Yingzxu.MarkdownDom.Parser;
using Net.Yingzxu.MarkdownDom.Base;
using System.IO;
using Net.Yingzxu.MarkdownDom;

namespace MDETest
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //RebuildOMetaSharpParser();
            Parse();
            //Convert();
            //OMetaConsoleProgram.Run<Program>(OMetaConsoleOptions.CompileGrammars);
            Console.Read();
        }

        static void Parse()
        {
            GithubMarkdown parser = new GithubMarkdown();
            var match = parser.GetMatch("\n#hahaha\n##\nsdfsdfsdf\n132213\n12312", parser.Document);
            MarkdownElementBase res= match.Results.First();
            if (match.Success)
                Console.WriteLine("result: \n{0}", res); // should print "14"
            else
                Console.WriteLine("error: {0}", match.Error); // shouldn't happen
        }

        static void Convert()
        {
            string[] args = { "-f", "-n", "Net.Yingzxu.MarkdownDom.Parser", "E:\\Projects\\MarkdownEverywhere\\MDE\\MarkdownDom\\Parser\\GithubMarkdownParser.ironmeta" };
            IronMeta.Program.Main(args);
        }

    }
}
