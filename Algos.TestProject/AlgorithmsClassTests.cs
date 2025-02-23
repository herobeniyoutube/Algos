using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Algorithms.TestProject
{
    [TestFixture]
    public class AlgorithmsClassTests
    {
        [Test]
        [TestCase("ababa", 'a', 3)]
        public void MostFrequentCharTest(string input, char ch, int count)
        {
            var dict = new Dictionary<char, int>();
            var mostCount = 0;
            var charMostFreq = ' ';

            foreach (char c in input)
            {
                if (dict.ContainsKey(c)) continue;
                dict.Add(c, 0);
            }

            foreach (var c in dict)
            {
                foreach (var a in input)
                {
                    if (c.Key == a)
                    {
                        dict[a]++;
                        if (dict[a] > mostCount)
                        {
                            mostCount = dict[a];
                            charMostFreq = a;
                        }

                    }
                }
            }

            Assert.That(mostCount == 3);
            Assert.That(charMostFreq == 'a');
        }


        /// <summary>
        /// Troom / Tcond, mode, result temp
        /// </summary>
        /// <param name="firstInput"></param>
        /// <param name="secondInput"></param>
        /// <param name="resultTemp"></param>
        [Test]
        [TestCase("10 20", "heat", 20)]
        [TestCase("10 20", "freeze", 10)]
        [TestCase("50 20", "fan", 50)]
        [TestCase("40 20", "auto", 20)]
        [TestCase("40 50", "auto", 50)]

        public void TempAfterHourTest(string firstInput, string secondInput, int resultTemp)
        {
            var temps = Array.ConvertAll(firstInput.Split(' '), s => int.Parse(s));
            var mode = secondInput;
            var result = 0;

            switch (mode)
            {
                case "fan":
                    result = temps[0];
                    break;
                case "auto":
                    result = temps[1];
                    break;
                case "heat":
                    if (temps[0] > temps[1]) result = temps[0];
                    else result = temps[1];
                    break;
                case "freeze":
                    if (temps[0] < temps[1]) result = temps[0];
                    else result = temps[1];
                    break;

            }
            Console.WriteLine(result);
            Assert.That(resultTemp == result);
        }

        [Test]
        [TestCase("1", "2", "3", "NO")]
        [TestCase("3", "4", "5", "YES")]
        [TestCase("4", "3", "5", "YES")]
        [TestCase("5", "3", "4", "YES")]
        public void TrueTriangle(string one, string two, string three, string resultWord)
        {
            var arr = new[] { int.Parse(one), int.Parse(two), int.Parse(three) };
            var result = "YES";
            if ((arr[0] + arr[1]+ arr[2]) / 3 == arr[0]) { }
            else if (arr[0] + arr[1] <= arr[2]) result = "NO";
                else if (arr[0] + arr[2] <= arr[1]) result = "NO";
                else if (arr[1] + arr[2] <= arr[0]) result = "NO";

            Console.WriteLine(result);
            Assert.That(resultWord == result);
        }
        [Test]
        [TestCase("8(495)430-23-97", "+7-4-9-5-43-023-97", "4-3-0-2-3-9-7", "8-495-430", "YESYESNO")]
        [TestCase("86406361642", "83341994118", "86406361642", "83341994118", "NOYESNO")]
        [TestCase("+78047952807", "+78047952807", "+76147514928", "88047952807", "YESNOYES")]
        public void NumberComparison(string newNumber, string one, string two, string three, string resultComparison)
        {
            var regex = new Regex(@"\D", RegexOptions.IgnoreCase);

            var arr = new[]
            {
                regex.Replace(newNumber, ""),
                regex.Replace(one, ""),
                regex.Replace(two, ""),
                regex.Replace(three, "")
            };

            var result = new string[3];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length == 7) arr[i] = "495" + arr[i];
                if (i == 0) continue;

                if ((arr[i].Length == 11 ? arr[i].Substring(1) : arr[i]) == (arr[0].Length == 11 ? arr[0].Substring(1) : arr[0])) result[i - 1] = "YES";
                else result[i - 1] = "NO";
            }

            foreach (var i in result)
            {
                Console.WriteLine(i);
            }

            Assert.That(resultComparison == $"{result[0]}{result[1]}{result[2]}");
        }
    }
}
