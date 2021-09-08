using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace New_Relic_Code_Challenge
{
    public class StringSequences
    {
        static void Main(string[] args)
        {
            // Stopwatch sw = new Stopwatch(); for tracking time to run
            // sw.Start();

            Dictionary<string, int> stringSequences = new Dictionary<string, int>();

            if (args != null && args.Length > 0) {
                var text = "";
                foreach (var s in args) {
                    text += System.IO.File.ReadAllText(s) + " ";
                }
                PrintStringSequences(text);
            } else { // process from stdin
                if (Console.IsInputRedirected) {
                    string s;
                    StringBuilder sb = new StringBuilder();
                    Console.InputEncoding = System.Text.Encoding.UTF8;

                    while ((s = Console.ReadLine()) != null) {
                        sb.Append(s + " ");
                    }
                    
                    PrintStringSequences(sb.ToString());
                } else {
                    Console.WriteLine("Error, need data");
                    return;
                }
            }
            // sw.Stop();
            // Console.WriteLine($"program executed in {sw.ElapsedMilliseconds} ms");
        }

        private static void PrintStringSequences(string s) {         
            var output = TransformText(s);
            var textArray = output.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var stringSequences = FindCommonSequences(textArray);

            Console.Write(PrintByDescendingValue(stringSequences));
        }

        public static Dictionary<string, int> FindCommonSequences(string[] textArray) {
            Dictionary<string, int> stringSequences = new Dictionary<string, int>();
            for (int i = 0; i < textArray.Length - 2; i++) {
                var stringSequence = $"{textArray[i]} {textArray[i+1]} {textArray[i+2]}";
                if (stringSequences.ContainsKey(stringSequence)) {
                    stringSequences[stringSequence] += 1;
                } else {
                    stringSequences.Add(stringSequence, 1);
                }
            }
            return stringSequences;
        }

        public static string TransformText(string s) { //takes text as string, returns string all lower case, no punctuation, no new lines
            string output = new string(s.Where(c => !char.IsPunctuation(c)).ToArray());
            output = output.ToLower();
            output = output.Replace("\n", " ");
            return output;
        }

        public static string PrintByDescendingValue(Dictionary<string, int> dict) {
            StringBuilder sb = new StringBuilder();
            foreach (var stringSequence in dict.OrderByDescending(key => key.Value).Take(100)) {
                sb.AppendLine($"{stringSequence.Key} - {stringSequence.Value}");
            }
            return sb.ToString();
        }
    }
}
