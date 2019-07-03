using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_text
{
    public class Sentence : ISentence
    {

        private readonly List<ISentenceElement> _sententenceElements;
        
        public Sentence()
        {
            _sententenceElements = new List<ISentenceElement>();
            
        }

        public void AddElementToEnd(ISentenceElement element)
        {
            _sententenceElements.Add(element);
        }

        public int GetWordsCount()
        {
            int count = 0;
            foreach (var sentenceElement in _sententenceElements)
            {
                if (sentenceElement.SentenceElementType == SentenceElementType.Word)
                {
                    count++;
                }
            }
            return count;
        }
       

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(_sententenceElements[0].Value);
            for (int i = 1; i < _sententenceElements.Count; i++)
            {
                if (_sententenceElements[i].SentenceElementType == SentenceElementType.Word)
                {
                    builder.Append(" ");
                }
                builder.Append(_sententenceElements[i].Value);
            }
            return builder.ToString();
        }
      
    }
}