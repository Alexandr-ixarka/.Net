using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_text
{
    public interface ISentenceElement
    {
        string Value { get; set; }
        SentenceElementType SentenceElementType { get; }
    }
}
