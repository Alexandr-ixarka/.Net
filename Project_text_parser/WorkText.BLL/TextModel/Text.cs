using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_text
{
    public class Text
    {
        private List<ISentence> _sentences;
       
        public Text()
        {
            _sentences = new List<ISentence>();
          
        }

        public void AddSentence(ISentence sentence)
        {
            _sentences.Add(sentence);
        }

        public IEnumerable<ISentence> SortSentences()
        {
            return _sentences.OrderBy(x => x.GetWordsCount());
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _sentences);
        }

     

    }
}
