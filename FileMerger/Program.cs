using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------Document Merger------");
            string file1;
            string file2;
            string response;
            do
            {

                do
                {
                    Console.WriteLine("\nWhat is the name of the first text file?");
                    file1 = TxtCheck(Console.ReadLine());

                } while (!fileCheck(file1));    //Loop if file is not found

                do
                {
                    Console.WriteLine("\nWhat is the name of the second text file?");
                    file2 = TxtCheck(Console.ReadLine());

                } while (!fileCheck(file2));

                string newText = ReadFile(file1) + ReadFile(file2); //newText will contain the contents of both files

                string newFilename = RemoveTxt(file1) + file2;
                WriteFile(newText, newFilename);

                Console.WriteLine("Would you like to merge 2 more files? Y to continue");
                response = Console.ReadLine().ToUpper();
            } while (response == "Y");

        }

        static string TxtCheck(string input)
        {
            if (!input.EndsWith(".txt")) input += ".txt";
            return input;
        }

        static bool fileCheck(string filename)
        {
            if (File.Exists(filename)) return true;

            Console.WriteLine("That file does not exist. Please enter filename again.");
            return false;
        }

        static string RemoveTxt(string input)
        {
            if (input.EndsWith(".txt")) input = input.Substring(0, input.Length - 4);   //removes last 4 chars, eg ".txt"
            return input;
        }



        static string ReadFile(string Filename)
        {
            string content = "";
            string line;


            try
            {
                StreamReader sr = new StreamReader(Filename); //Will save to current directory

                line = sr.ReadLine();
                while (line != null)
                {
                    content += line;
                    line = sr.ReadLine();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);   //display exceptions
            }
            finally
            {

            }
            return content;

        }

        static void WriteFile(string FileContent, string Filename)
        {
            try
            {
                StreamWriter sw = new StreamWriter(Filename); //Will save to current directory

                sw.WriteLine(FileContent);

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);   //display exceptions
            }
            finally
            {
                Console.WriteLine("File was successfully written.");
            }
        }
    }
}
