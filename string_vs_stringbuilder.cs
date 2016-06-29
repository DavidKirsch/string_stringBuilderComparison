using System;
using System.Diagnostics;
using System.Text;

//Disclaimer: This code comes with no warranty, and is provided 'As-Is'. Use at your own discretion.
//This code was created for a blog post at www.TechPursuit.io
//Written by: David Kirsch

namespace StringStringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stringTime;
            Stopwatch stringBuilderTime;
            int iterations = 10000;
            string text1 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. ";
            string text2 = "Phasellus tempor suscipit libero vel aliquam. ";
            string text3 = "Proin quis pulvinar turpis. ";

            Console.WriteLine("Variables:");
            Console.WriteLine("    text1 is: " + text1);
            Console.WriteLine("    text2 is: " + text2);
            Console.WriteLine("    text3 is: " + text3);
            Console.WriteLine("    iterations is: " + iterations.ToString());

            Console.WriteLine("\nPress any key to start the first comparison.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nOur first test will compare concatenating variable text1  1000 times by adding to a string, then by using a StringBuilder\n");

            stringTime = Stopwatch.StartNew();
            runStr1(iterations, text1);
            stringTime.Stop();
            Console.WriteLine("****Time to complete: " + stringTime.ElapsedMilliseconds.ToString() + "****");

            stringBuilderTime = Stopwatch.StartNew();
            runStrBuild1(iterations, text1);
            stringBuilderTime.Stop();
            Console.WriteLine("****Time to complete: " + stringBuilderTime.ElapsedMilliseconds.ToString() + "****");

            Console.WriteLine("\nAs we can see, a respectable difference in time.");

            Console.WriteLine("\nPress any key to start the next comparison.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nNext we'll add variables text1, text2 and text3 to a string then StringBuilder in a single command.\n");

            stringTime = Stopwatch.StartNew();
            runStr2(iterations, text1, text2, text3);
            stringTime.Stop();
            Console.WriteLine("****Time to complete: " + stringTime.ElapsedMilliseconds.ToString() + "****");

            stringBuilderTime = Stopwatch.StartNew();
            runStrBuild2(iterations, text1, text2, text3);
            stringBuilderTime.Stop();
            Console.WriteLine("****Time to complete: " + stringBuilderTime.ElapsedMilliseconds.ToString() + "****");

            Console.WriteLine("\nThe time difference is becoming vast...");

            Console.WriteLine("\nPress any key to start the next comparison.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n\nLastly lets add each of the 3 variables together as separate commands, see if this has any effect.\n");

            stringTime = Stopwatch.StartNew();
            runStr3(iterations, text1, text2, text3);
            stringTime.Stop();
            Console.WriteLine("****Time to complete: " + stringTime.ElapsedMilliseconds.ToString() + "****");

            stringBuilderTime = Stopwatch.StartNew();
            runStrBuild3(iterations, text1, text2, text3);
            stringBuilderTime.Stop();
            Console.WriteLine("****Time to complete: " + stringBuilderTime.ElapsedMilliseconds.ToString() + "****");

            Console.WriteLine("\nThe time difference is simply enormous!");

            Console.WriteLine("\nPress any key to start the next comparison.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n\nLet's try something different, this should show that a string has better performance. Going to do 200 * the number of iterations as well.\n");

            stringTime = Stopwatch.StartNew();
            runStr4(iterations, text1, text2, text3);
            stringTime.Stop();
            Console.WriteLine("****Time to complete: " + stringTime.ElapsedMilliseconds.ToString() + "****");

            Console.WriteLine("");
            stringBuilderTime = Stopwatch.StartNew();
            runStrBuild4(iterations, text1, text2, text3);
            stringBuilderTime.Stop();
            Console.WriteLine("****Time to complete: " + stringBuilderTime.ElapsedMilliseconds.ToString() + "****");

            Console.WriteLine("\nPlease press any key to exit.");
            Console.ReadKey();
        }

        private static void runStr1(int iterations, string text)
        {
            Console.WriteLine("for (int index = 0; index < iterations; index++)");
            Console.WriteLine("\tstr += text1;");

            string str = "";
            for (int index = 0; index < iterations; index++)
                str += text;
        }

        private static void runStr2(int iterations, string text, string text2, string text3)
        {
            Console.WriteLine("for (int index = 0; index < iterations; index++)");
            Console.WriteLine("\tstr += text1 + text2 + text3;");

            string str = "";
            for (int index = 0; index < iterations; index++)
                str += text + text2 + text3;
        }

        private static void runStr3(int iterations, string text, string text2, string text3)
        {
            Console.WriteLine("for (int index = 0; index < iterations; index++)");
            Console.WriteLine("{\n\tstr += text1;\n\tstr += text2;\n\tstr += text3\n}");

            string str = "";
            for (int index = 0; index < iterations; index++)
            {
                str += text;
                str += text2;
                str += text3;
            }
        }

        private static void runStr4(int iterations, string text, string text2, string text3)
        {
            Console.WriteLine("iterations *= 200;");
            Console.WriteLine("for (int index = 0; index < iterations; index++)");
            Console.WriteLine("{\n\tstring str = text;\n\tstr += text2;\n}");

            iterations *= 200;
            for (int index = 0; index < iterations; index++)
            {
                string str = text;
                str += text2;
            }
        }

        private static void runStrBuild1(int iterations, string text)
        {
            Console.WriteLine("for (int index = 0; index < iterations; index++)");
            Console.WriteLine("\tsb.Append(text1);");

            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < iterations; index++)
                sb.Append(text);
        }

        private static void runStrBuild2(int iterations, string text, string text2, string text3)
        {
            Console.WriteLine("for (int index = 0; index < iterations; index++)");
            Console.WriteLine("\tsb.Append(text1 + text2 + text3);");

            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < iterations; index++)
                sb.Append(text + text2 + text3);
        }

        private static void runStrBuild3(int iterations, string text, string text2, string text3)
        {
            Console.WriteLine("for (int index = 0; index < iterations; index++)");
            Console.WriteLine("{\n\tsb.Append(text1);\n\tsb.Append(text2);\n\tsb.Append(text3);\n}");

            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < iterations; index++)
            {
                sb.Append(text);
                sb.Append(text2);
                sb.Append(text3);
            }
        }

        private static void runStrBuild4(int iterations, string text, string text2, string text3)
        {
            Console.WriteLine("iterations *= 200;");
            Console.WriteLine("for (int index = 0; index < iterations; index++)");
            Console.WriteLine("{\n\tStringBuilder sb = new StringBuilder(text);\n\tsb.Append(text2);\n}");

            iterations *= 200;
            for (int index = 0; index < iterations; index++)
            {
                StringBuilder sb = new StringBuilder(text);
                sb.Append(text2);
            }
        }
    }
}
