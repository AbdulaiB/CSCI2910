using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System;
using System.Collections.Generic;

namespace _2910_Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {

           // static void GetFile()
            //{
                List<VideoGames> listOfGames = new List<VideoGames>();

                //File Path that needs to be read
                string rootFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
                string filePath = $"{rootFolder}{Path.DirectorySeparatorChar}videogames.csv";


                try
                {
                    //Read all text from the file
                    string fileContents = File.ReadAllText(filePath);

                    //Print the contents of the file to the console
                    Console.WriteLine("File Contents: ");
                    //Console.WriteLine(fileContents);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error has occured while trying to read this file, please try again");
                    Console.WriteLine(ex.Message);
                }

                using (var rdr = new StreamReader(filePath))
                {
                    rdr.ReadLine();

                    while (!rdr.EndOfStream)
                    {
                        string nextLine = rdr.ReadLine();

                        string[] fields = nextLine.Split(",");

                        VideoGames videoGame = new VideoGames(fields[0].Trim(), fields[1].Trim(), Int32.Parse(fields[2].Trim()), fields[3].Trim(), fields[4], Decimal.Parse(fields[5].Trim()), Decimal.Parse(fields[6]), Decimal.Parse(fields[7].Trim()), Decimal.Parse(fields[8].Trim()), Decimal.Parse(fields[9].Trim()));

                        videoGame.CompareTo(videoGame);    

                        listOfGames.Add(videoGame);
                }
            }

            listOfGames.Sort();
            foreach (VideoGames Game in listOfGames)
            {
                Console.WriteLine(Game.ToString());
            }

            int numOfGames = listOfGames.Count();

            Console.WriteLine("\n\n\n\n");

            var selectPublisher = from x in listOfGames
                                  where x.Publisher == "Nintendo"
                                  select x;

            foreach (VideoGames vGame in selectPublisher)
            {
                Console.WriteLine(vGame.ToString());
            }

            int numOfVGames = selectPublisher.Count();

            double numGames = Double.Parse(numOfGames.ToString());
            double numVGames = Double.Parse(numOfVGames.ToString());


            double percentageOfPublishers = Math.Round((numVGames / numGames) * 100, 2);
            Console.WriteLine(percentageOfPublishers + "%");
            Console.WriteLine("Please Press Enter to Continue");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("\n\n\n\n");

            var selectGenre = from a in listOfGames
                                  where a.Genre == "Simulation"
                              select a;

            foreach (VideoGames vGameG in selectGenre)
            {
                Console.WriteLine(vGameG.ToString());
            }

            int numOfVGameG = selectGenre.Count();

            double numVGameG = Double.Parse(numOfVGameG.ToString());


            Console.WriteLine(numOfVGameG);

            double percentageOfGenres = Math.Round((numVGameG / numGames) * 100, 2);
            Console.WriteLine(percentageOfGenres + "%");
            Console.WriteLine("Please Press Enter to Continue");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("What Publisher would you like to select?");
            string usrSelect = Console.ReadLine();

            var usrSelectPublisher = from z in listOfGames
                                  where z.Publisher == usrSelect
                                  select z;

            foreach (VideoGames usrGame in usrSelectPublisher)
            {
                Console.WriteLine(usrGame.ToString());
            }

            int usrNumOfVGames = usrSelectPublisher.Count();

            double usrNumVGames = Double.Parse(numOfVGames.ToString());


            Console.WriteLine(usrNumOfVGames);

            double usrPercentageOfPublishers = Math.Round((usrNumOfVGames / numGames) * 100, 2);
            Console.WriteLine(usrPercentageOfPublishers + "%");
            Console.WriteLine("Please Press Enter to Continue");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("\n\n\n\n");

            Console.WriteLine("What Genre would you like to see?");
            string usrGenreInput = Console.ReadLine();

            var usrSelectGenre = from b in listOfGames
                              where b.Genre == usrGenreInput
                              select b;

            foreach (VideoGames usrVGame in usrSelectGenre)
            {
                Console.WriteLine(usrVGame.ToString());
            }

            int usrNumOfVGameG = usrSelectGenre.Count();

            double usrNumVGameG = Double.Parse(numOfVGameG.ToString());


            Console.WriteLine("Genre: " + usrNumOfVGameG);
            Console.WriteLine("Total Games: " + numGames);

            double usrPercentageOfGenres = Math.Round((usrNumOfVGameG / numGames) * 100, 2);
            Console.WriteLine(usrPercentageOfGenres + "%");
        }
    }
}