using Xunit;
using Word_Sequence_Finder;
using System.Collections.Generic;

namespace Tests
{
    public class ChallengeTests
    {
        [Theory]
        [InlineData("“I love\nsandwiches.”", "i love sandwiches")]
        [InlineData("\"(I LOVE SANDWICHES!!)\"", "i love sandwiches")]
        [InlineData("i love sandwiches", "i love sandwiches")]
        public void TransformTextTest(string val, string expected)
        {   
            Assert.Equal(StringSequences.TransformText(val), expected);
        }

        [Fact]
        public void TestPrintDescending()
        {
            var dict = new Dictionary<string, int>();
            dict.Add("TestA", 45);
            dict.Add("TestB", 33);
            dict.Add("TestC", 100);
            var s = StringSequences.PrintByDescendingValue(dict);
            var expected = "TestC - 100\r\nTestA - 45\r\nTestB - 33\r\n";
            Assert.Equal(s, expected);
        }
        
        [Fact]
        public void TestFindCommonSequences() {
            var data = new string[] { "a", "b", "a", "b", "a" };
            var commonSequences = StringSequences.FindCommonSequences(data);
            
            Assert.Equal(2, commonSequences.Count);
            Assert.Equal(2, commonSequences["a b a"]);
            Assert.Equal(1, commonSequences["b a b"]);   
        }
    }
}
