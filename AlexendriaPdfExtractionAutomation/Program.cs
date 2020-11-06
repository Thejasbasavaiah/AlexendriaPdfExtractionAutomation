using System;

namespace AlexendriaPdfExtractionAutomation
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Alex PDF extractoion tool");
            Console.WriteLine($"Please enter folder path");
            var folderPath = Console.ReadLine();


            Automation.RunAutomation(folderPath);
        }


      

        


    }

}
