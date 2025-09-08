using System.Collections.Generic;

namespace Performance_Prognosis;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("*** Performace Prognosis ***\n\n");
        Console.WriteLine("INSTRUCTIONS: Answer with either 'true' or 'false'\n\n");

        // list of all the prompts to display
        List<string> prompts = new List<string>();

        prompts.Add("I will always read the lecture material before I go to lecture.");
        prompts.Add("I will go over my lecture notes as soon as possible after lecture to rework them and mark problem areas.");
        prompts.Add("I will learn the relevant concepts from General Chemistry so that I have the background necessary to understand the material in Analyticsl Chemistry.");
        prompts.Add("I will try to work on the homework problems without looking at the example problems or my notes from class.");
        prompts.Add("I will go to office hours or tutoring regularly to discuss problems on the homework");
        prompts.Add("I will rework all of the homework problems before the test or quiz.");
        prompts.Add("I will spend some time studying analytical chemistry at least five days per week (outside) of the class time.");
        prompts.Add("I will 'teach' concepts to my friends, myself in the mirror, stuffed animals, imaginary students, etc.");
        prompts.Add("I will make flashcards and use mnemonics for myself to help remember facts and equaltions.");
        prompts.Add("I will make diagrams or draw mental pictures of the concepts, experimental procedures, and instruments discussed in class.");
        prompts.Add("I will acitvely participate in my study group where we will discuss homework problems and quiz ourselves on the material.");
        prompts.Add("I will rework all of the quiz and test items I have missed before the next class session.");
        prompts.Add("I know that I can make an A in this class, and will put forth the effort to do so.");

        int truthCount = 0;
        char grade;

        // prompt the user
        int i = 0;
        while (i < prompts.Count)
        {
            Console.Write(prompts[i] + ": ");
            var input = Console.ReadLine().ToLower();

            if (input == "true")
            {
                truthCount++;
            }
            else if (input == "false")
            {
                i++;
                continue;
            }
            else
            {
                Console.WriteLine("Error: Please answer with either 'true' or 'false'.");
                continue;
            }
            i++;

        }


        // assign scores
        if (truthCount >= 10 && truthCount <= 13)
        {
            grade = 'A';
        }
        else if (truthCount >= 6 && truthCount <= 9)
        {
            grade = 'B';
        }
        else if (truthCount == 4 || truthCount == 5)
        {
            grade = 'C';
        }
        else if (truthCount == 2 || truthCount == 3)
        {
            grade = 'D';
        }
        else
        {
            grade = 'F';
        }

        // print the grade with truth counts
        Console.WriteLine();
        Console.WriteLine($"You answered 'true' to {truthCount} questions.");
        Console.WriteLine($"Your overall grade is {grade}");
        Console.WriteLine();
    }
}

