using System;
using SeriesRegister.Classes;

namespace SeriesRegister
{
    class Program
    {
        static seriesRepository repository = new seriesRepository();

        static void Main(string[] args)
        {
            string userOption = getUserOption();

            while(userOption != "X"){
                switch(userOption){
                    case "1":
                        listSeries();
                        break;
                    case "2":
                        insertSeries();
                        break;
                    case "3":
                        updateSeries();
                        break;
                    case "4":
                        deleteSeries();
                        break;
                    case "5":
                        viewSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = getUserOption();
            }

            Console.WriteLine("Thank you for use our service!" + Environment.NewLine);
        }

        private static string getUserOption(){
            string text = Environment.NewLine;
            text += "Welcome to DIO series!" + Environment.NewLine; 
            text += "Choose an option: " + Environment.NewLine;
            text += "1 - List the series" + Environment.NewLine;
            text += "2 - Insert a new series" + Environment.NewLine;
            text += "3 - Update a series" + Environment.NewLine;
            text += "5 - View a series" + Environment.NewLine;
            text += "C - Clean the screen" + Environment.NewLine;
            text += "X - Exit" + Environment.NewLine;
            Console.WriteLine(text);

            string userOption = Console.ReadLine().ToUpper();

            Console.WriteLine();

            return userOption;
        }

        private static void listSeries(){
            Console.WriteLine("Series list");

            var list = repository.list();
            if(list.Count == 0){
                Console.WriteLine("No series registered.");
                return;
            }

            foreach(var s in list){
                if(!s.getDeleted()){
                    Console.WriteLine("-> Id {0} - {1}", s.getId(), s.getTitle());
                }
            }
        }

        private static string getInformation(){
            Console.WriteLine("Choose the genre:");
            foreach(int g in Enum.GetValues(typeof(Genre))){
                Console.WriteLine("-> {0} - {1}", g, Enum.GetName(typeof(Genre), g));
            }
            int genre = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the title?");
            string title = Console.ReadLine(); 

            Console.WriteLine("What is the year of the series?");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Describe the series");
            string description = Console.ReadLine();

            return genre + ".,." + title + ".,." + year + ".,." + description;
        }

        private static void insertSeries(){
            Console.WriteLine("Insert a new series");
            
            string[] data = getInformation().Split(".,.");

            repository.insert(new series(repository.nextId(), (Genre)int.Parse(data[0]), data[1], data[3], int.Parse(data[2])));
        }

        private static void updateSeries(){
            Console.WriteLine("Update a series");

            Console.WriteLine("Write the series id");
            int id = int.Parse(Console.ReadLine());

            string[] data = getInformation().Split(".,.");

            repository.update(id, new series(id, (Genre)int.Parse(data[0]), data[1], data[3], int.Parse(data[2])));
        }

        private static void deleteSeries(){
            Console.WriteLine("Delete a series");

            Console.WriteLine("Write the series id");
            int id = int.Parse(Console.ReadLine());

            repository.delete(id);
        }

        private static void viewSeries(){
            Console.WriteLine("View a series");

            Console.WriteLine("Write the series id");
            int id = int.Parse(Console.ReadLine());

            string seriesInformation = repository.getById(id).ToString();
            Console.WriteLine(seriesInformation);
        }
    }
}
