using System;
using System.Text.RegularExpressions;

namespace Assessment1.Library
{
    public class PossiblePalindrome
    {

        readonly string text;

        public PossiblePalindrome(string s)
        {
            this.text = s;
        }

        public bool PaliTest()
        {
            string pali = this.text;
            pali = pali.Trim().ToUpper().Replace(" ", "");
            pali = Regex.Replace(pali, @"\p{P}", "");
            for (int i = 0; i < pali.Length;i++)
            {
                if (pali[i] != pali[pali.Length-i-1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
