using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace LetterService
{
    public class LetterService : ILetterService
    {
        public int GetOccurences(string firstLetter, string secondLetter)
        {
            int count = Regex.Matches(firstLetter.ToLower(), secondLetter.ToLower()).Count;

            return count;
        }
    }
}
