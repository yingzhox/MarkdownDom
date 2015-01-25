﻿//////////////////////////////////////////////////////////////////////
//
// Copyright © 2014 Gordon Tisher
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
//     * Redistributions of source code must retain the above 
//       copyright notice, this list of conditions and the following 
//       disclaimer.
//     * Redistributions in binary form must reproduce the above 
//       copyright notice, this list of conditions and the following 
//       disclaimer in the documentation and/or other materials 
//       provided with the distribution.
//     * Neither the name of the IronMeta Project nor the names of its 
//       contributors may be used to endorse or promote products 
//       derived from this software without specific prior written 
//       permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND  ANY EXPRESS OR  IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE  IMPLIED WARRANTIES OF  MERCHANTABILITY AND FITNESS 
// FOR  A  PARTICULAR  PURPOSE  ARE DISCLAIMED. IN  NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT  LIMITED TO, PROCUREMENT  OF SUBSTITUTE  GOODS  OR SERVICES; 
// LOSS OF USE, DATA, OR  PROFITS; OR  BUSINESS  INTERRUPTION) HOWEVER 
// CAUSED AND ON ANY THEORY OF  LIABILITY, WHETHER IN CONTRACT, STRICT 
// LIABILITY, OR  TORT (INCLUDING NEGLIGENCE  OR OTHERWISE) ARISING IN 
// ANY WAY OUT  OF THE  USE OF THIS SOFTWARE, EVEN  IF ADVISED  OF THE 
// POSSIBILITY OF SUCH DAMAGE.
//
//////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IronMeta.Matcher;

namespace IronMeta.Generator
{
    
    /// <summary>
    /// Wrapper for the C# generator that handles file IO.
    /// </summary>
    public static class CSharpShell
    {

        /// <summary>
        /// Generate a parser from an IronMeta grammar.
        /// </summary>
        /// <param name="input">Input stream.</param>
        /// <param name="output">Output writer.</param>
        /// <param name="name_space">Namespace to use in the generated parser.</param>
        public static MatchResult<char, AST.Node> Process(IEnumerable<char> input, TextWriter output, string name_space)
        {
            var parser = new BootstrapParser();
            var match = parser.GetMatch(input, parser.IronMetaFile);

            if (match.Success)
            {
                CSharpGen csgen = new CSharpGen(match.Result, name_space);
                csgen.Generate(output);
            }

            return match;
        }

        /// <summary>
        /// Generate a parser from an IronMeta grammar.
        /// </summary>
        /// <param name="input_fname">Input filename.</param>
        /// <param name="output_fname">Output filename.</param>
        /// <param name="name_space">Namespace for the generated parser.</param>
        /// <param name="force">Force generation even if the existing parser is newer than the source.</param>
        /// <returns>The results of the attempt to generate the parser.</returns>
        public static MatchResult<char, AST.Node> Process(string input_fname, string output_fname, string name_space, bool force)
        {
            if (string.IsNullOrEmpty(name_space))
            {
                FileInfo info = new FileInfo(input_fname);
                name_space = info.Directory.Name;
            }

            FileInfo srcInfo = new FileInfo(input_fname);
            if (!srcInfo.Exists)
                throw new Exception("File not found: " + input_fname);

            FileInfo destInfo = new FileInfo(output_fname);
            if (destInfo.Exists && !force)
            {
                if (srcInfo.LastWriteTimeUtc <= destInfo.LastWriteTimeUtc)
                {
                    Console.WriteLine("{0} unchanged; not generating.", input_fname);
                    return null;
                }
            }

            string contents;
            using (StreamReader sr = new StreamReader(input_fname))
            {
                contents = sr.ReadToEnd();
            }

            MatchResult<char, AST.Node> match = null;
            using (StringWriter sw = new StringWriter())
            {
                match = Process(contents, sw, name_space);

                if (match.Success)
                {
                    using (StreamWriter fw = new StreamWriter(output_fname))
                    {
                        fw.Write(sw.ToString());
                    }
                }
            }

            return match;
        }

    }

}
