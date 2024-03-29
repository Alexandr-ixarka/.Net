﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;



namespace Project_text
{
    public class TextReader : IFileReader
    {
        private string _fileName;
        private string _bufLine = string.Empty;

        public TextReader(string fName)
        {
            this._fileName = fName;
        }

        public List<string> Read()
        {
            FileStream stream = new FileStream(_fileName, FileMode.Open);
            StreamReader reader = new StreamReader(stream, Encoding.Default);
            List<string> result = new List<string>();

            string str = string.Empty;
            while (!reader.EndOfStream)
            {
                str = reader.ReadLine();
                result.AddRange(SplitText(str, reader.EndOfStream));
            }
            reader.Close();
            return result;
        }

        private List<string> SplitText(string line, bool isLastLine)
        {
            line = string.Join(" ", _bufLine, line);
            int endOfSentence = 1;
            List<string> sentences = new List<string>();
            string remained = line;

            while (remained.Length > 0)
            {
                int pointIndex = remained.IndexOf('.');
                int exlamationIndex = remained.IndexOf('!');
                int questionIndex = remained.IndexOf('?');
                int questionIndex1 = remained.IndexOf('\r');
                int questionIndex2 = remained.IndexOf('\n');

                if (pointIndex < 0 && exlamationIndex < 0 && questionIndex < 0 && questionIndex1 < 0 && questionIndex2 < 0)
                {
                    if (isLastLine)
                    {
                        sentences.Add(remained);
                    }
                    break;
                }

                endOfSentence = (pointIndex < 0 ? remained.Length : pointIndex);

                if (exlamationIndex > -1 && exlamationIndex < endOfSentence)
                    endOfSentence = exlamationIndex;

                if (questionIndex > -1 && questionIndex < endOfSentence)
                    endOfSentence = questionIndex;

                sentences.Add(remained.Substring(0, endOfSentence + 1));
                remained = remained.Substring(endOfSentence + 1);
                _bufLine = remained;
            }

            return sentences;
        }

    }
}
