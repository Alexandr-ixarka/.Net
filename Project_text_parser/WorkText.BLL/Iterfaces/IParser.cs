using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Project_text
{
    public interface IParser<T>
    {
        T Parse(List<string> str);
    }
}