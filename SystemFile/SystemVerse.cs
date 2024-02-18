using Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemFile
{
    class Verse
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public int? YearWrite { get; set; }
        public string? Theme { get; set; }
    }
    class AppVerse : Verse
    {
        List<Verse> list = new List<Verse>()
        {
            new Verse()
            {
                Name = "STEP",
                Author = "Code",
                YearWrite = 2024,
                Theme = "Why are you zombie?"
            },
            new Verse()
            {
                Name = "Step",
                Author = "92kxa",
                YearWrite = 1991,
                Theme = "Why are you zombie? #2"
            }
        };
        public void Menu()
        {
            do
            {
                Console.Clear();
                int choice = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center,
                    "Add", "Delete", "Find", "Save", "Load", "View in the Console", "Exit");
                switch (choice)
                {
                    case 0: Add(); break;
                    case 1: Delete(); break;
                    case 2: Find(); break;
                    case 3: SaveFile(); break;
                    case 4: LoadFile(); break;
                    case 5: PrintVersesInConsole(); break;
                    case 6: return;
                }
            } while (true);
        }
        public void Add()
        {
            do
            {
                Console.Clear();
                int choice = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center,
                    "Name", "Author", "Year", "Theme", "Return");
                switch (choice)
                {
                    case 0:
                        {
                            Console.Write("Input a new Name: ");
                            Name = Console.ReadLine(); break;
                        }
                    case 1:
                        {
                            Console.Write("Input a new Author: ");
                            Author = Console.ReadLine(); break;
                        }
                    case 2:
                        {
                            Console.Write("Input a new Year: ");
                            YearWrite = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Input a new Theme: ");
                            Theme = Console.ReadLine(); ;
                            break;
                        }
                    case 4:
                        {
                            if (Name != null && Author != null && YearWrite != null && Theme != null)
                            {
                                list.Add(new Verse()
                                {
                                    Name = Name,
                                    Author = Author,
                                    YearWrite = YearWrite,
                                    Theme = Theme
                                });
                            }
                            return;
                        }
                }
            } while (true);
        }
        public void Delete() //+ще один метод для пошуку індекса вірша
        {
            do
            {
                Console.Clear();
                int choice = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center,
                    "Index Verse", "Return");
                switch (choice)
                {
                    case 0:
                        {
                            int input = Convert.ToInt32(Console.ReadLine());
                            searchIndex(input); break;
                        }
                    case 1: return;
                }
            } while (true);
        }
        private void searchIndex(int index)
        {
            try
            {
                if (list == null || list[index] == null) throw new ArgumentOutOfRangeException("The List is null or Index is not found!");
                list.Remove(list[index]);
            }
            catch (ArgumentOutOfRangeException error)
            {
                Console.WriteLine(error.Message);
                Thread.Sleep(5000);
            }
        }
        public void Find() //я хотів скоротити його, але в кінці написання зрозумів, що для лямбди потрібно окремо створювати метод під конкретний тип. Тож я залишаю цю ідею подалік
        {
            Console.WriteLine("Exit ~~ Enter");
            do
            {
                Console.Clear();
                int choice = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center,
                    "Name", "Author", "Year", "Theme", "Return");
                string? searchName = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case 0:
                        {
                            var search = list.Where(x => x.Name.ToLower() == searchName).ToList();
                            search.ForEach(x => Console.WriteLine($"{x.Name} || {x.Author} || {x.YearWrite} || {x.Theme}"));
                            break;
                        }
                    case 1:
                        {
                            var search = list.Where(x => x.Author.ToLower() == searchName).ToList();
                            search.ForEach(x => Console.WriteLine($"{x.Name} || {x.Author} || {x.YearWrite} || {x.Theme}"));
                            break;
                        }
                    case 2:
                        {
                            var search = list.Where(x => x.YearWrite == (Convert.ToInt32(searchName))).ToList();
                            search.ForEach(x => Console.WriteLine($"{x.Name} || {x.Author} || {x.YearWrite} || {x.Theme}")); break;
                        }
                    case 3:
                        {
                            var search = list.Where(x => x.Theme.ToLower() == searchName).ToList();
                            search.ForEach(x => Console.WriteLine($"{x.Name} || {x.Author} || {x.YearWrite} || {x.Theme}")); break;
                        }
                    case 4: return;
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
        }
        public void SaveFile()
        {

        }
        public void LoadFile()
        {

        }
        public void PrintVersesInConsole()
        {
            Console.Clear();
            Console.WriteLine("Exit ~~ Enter");
            do
            {
                list.ForEach(x => Console.WriteLine($"{x.Name} || {x.Author} || {x.YearWrite} || {x.Theme}"));
            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
        }
    }
}
