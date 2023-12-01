using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul14PR
{
    class Text
    {
        public void DisplayWordStatistics(Dictionary<string, int> wordFrequency)
        {
            Console.WriteLine("Слово\t\tКоличество");
            Console.WriteLine("------------------------");
            foreach (var pair in wordFrequency)
            {
                Console.WriteLine($"{pair.Key}\t{pair.Value}");
            }

        }
        public Dictionary<string, int> GetWordFrequency(string text)
        {
            var wordFrequency = new Dictionary<string, int>();
            var separators = new char[] { ' ', ',', '.', '!', '?', '\n', '\r' };

            foreach (var word in text.Split(separators, StringSplitOptions.RemoveEmptyEntries))
            {
                var cleanedWord = word.Trim().ToLower();

                if (wordFrequency.ContainsKey(cleanedWord))
                {
                    wordFrequency[cleanedWord]++;
                }
                else
                {
                    wordFrequency[cleanedWord] = 1;
                }
            }

            return wordFrequency;

        }

        class Program
        {
            static void Main()
            {
                string sampleText = @"
           Вот дом, Который построил Джек. А это пшеница, Кото­рая в темном чулане хранится 
                   В доме, Который построил Джек. А это веселая птица­ синица,
               Которая часто вору­ет пшеницу, Которая в темном чулане хранится
                  В доме, Который построил Джек.
            ";

                var wordStats = new Text();
                var statistics = wordStats.GetWordFrequency(sampleText);

                wordStats.DisplayWordStatistics(statistics);
            }
        }
    }

}
