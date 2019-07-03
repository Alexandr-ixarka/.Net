using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;



namespace Project_text
{
    public class TextParser : IParser<Text>
    {
        public Text Parse(List<string> sentences)
        {
            var text = new Text();
            string pattern = @"(\w+)|(\p{P})";
            foreach (var currentSentence in sentences)
            {
                var sentence = new Sentence();
                var matches = Regex.Matches(currentSentence, pattern);
                foreach (Match match in matches)
                {
                    if (Regex.IsMatch(match.Value, @"(\p{P})"))
                    {
                        sentence.AddElementToEnd(new SentenceElement(match.Value, SentenceElementType.PunctuationMark));
                    }
                    else
                    {

                        sentence.AddElementToEnd(new SentenceElement(match.Value, SentenceElementType.Word));
                    }
                }
                text.AddSentence(sentence);
            }
            return text;
        }
    }
}