using System;

namespace GradeBook
{
    class Program
    {
        private static void Main(string[] args)
        {
            IBook book = new DiskBook("GradeBook");
            book.GradeAdded += OnGradeAdded;

            EnterGrade(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrade(IBook  book)
        {
            while (true)
            {
                Console.WriteLine("Enter your grade here or use \"q \" to quit");
                var inputGrade = Console.ReadLine();

                if (inputGrade == "q") break;

                try
                {
                    var grade = double.Parse(inputGrade);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("***");
                }
            }
        }

        private static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("A grade was added");
        }
    }
}