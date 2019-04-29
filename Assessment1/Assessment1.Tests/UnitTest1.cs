using Assessment1.Library;
using System;
using Xunit;

namespace Assessment1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void DoesItRecognizePalindromes()
        {
            PossiblePalindrome p = new PossiblePalindrome("nursesrun");
            bool palindrome = p.PaliTest();
            Assert.True(palindrome);
        }
        [Fact]
        public void DoesItRecognizeNonPalindromes()
        {
            PossiblePalindrome p = new PossiblePalindrome("bearzoon");
            bool palindrome = p.PaliTest();
            Assert.False(palindrome);
        }
        [Fact]
        public void DoesItStripOutSpaces()
        {
            PossiblePalindrome p = new PossiblePalindrome("nurses run");
            bool palindrome = p.PaliTest();
            Assert.True(palindrome);
        }

        [Fact]
        public void DoesItStripOutPunctuation()
        {
            PossiblePalindrome p = new PossiblePalindrome("nurses.run");
            bool palindrome = p.PaliTest();
            Assert.True(palindrome);
        }

        [Fact]
        public void DoesItHandleCaseDifferences()
        {
            PossiblePalindrome p = new PossiblePalindrome("nuRsesruN");
            bool palindrome = p.PaliTest();
            Assert.True(palindrome);
        }
    }
}
