using System;

namespace Hotes
{
    class NotesApp
    { 
        public static List<NotesConfigsking> NotesConfigskingList = new List<NotesConfigsking>();
        public static List<string> DateList = new List<string>()
        {
            "09.10.2023",
            "10.10.2023",
            "11.10.2023",
            "12.10.2023",
        };
        public static int SelectedNote = 0;
        public static int SlectedList = 0;
        public static bool Active = false;
        public static void Main()
        {
            
            if(!Active)
            {
                StartConfig();
            }
            Active = false;
            NoteSelected(SelectedNote);
            int position = 0;
            while (true)
            {
                
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (SlectedList == 0) return;
                    if(position == 1) return;
                    position--;
                    SlectedList--;
                }
                else if(key.Key == ConsoleKey.DownArrow)
                {
                    position++;
                    SlectedList++;
                }
                else if(key.Key == ConsoleKey.LeftArrow)
                {
                    if (SelectedNote == 0) return;
                    NoteSelected(SelectedNote--);
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (SelectedNote == DateList.Count-1) return;
                    NoteSelected(SelectedNote++);
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Active=true;
                    SelectedNotesList(SlectedList);
                    return;
                }
                
                NoteSelected(SelectedNote);
                Console.SetCursorPosition(0, position);
                
                Console.WriteLine("->");
            }
            
        }

        public static void NoteSelected(int date)
        {
            Console.Clear();
            Console.WriteLine($" Выбрана дата {DateList[date]}");
            var i = 1;
            int top = 1, left = 2;
            foreach (var item in NotesConfigskingList)
            {
                if (item.Date == DateList[date])
                {
                    Console.SetCursorPosition(left, top++);
                    Console.WriteLine($"{i++}.{item.Name}");
                }

            }
            return;
        }

        public static void SelectedNotesList(int name)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            Console.Clear();
            while (key.Key != ConsoleKey.Escape)
            {
                Console.WriteLine(NotesConfigskingList[name].Name);
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Описание {NotesConfigskingList[name].Description}");
                Console.WriteLine($"Дата: {NotesConfigskingList[name].Date} {NotesConfigskingList[name].Time}");

                Console.ReadLine();
                if(key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Main();
                }
            }
        }

        public static void StartConfig()
        {
            NotesConfigskingList.Add(new NotesConfigsking("Дела 1", "Убрать комнату", "09.10.2023", "12:00"));
            NotesConfigskingList.Add(new NotesConfigsking("Дела 2", "Помыть пол", "09.10.2023", "12:00"));
            NotesConfigskingList.Add(new NotesConfigsking("Дела 3", "Сделать уроки", "09.10.2023", "12:00"));
            NotesConfigskingList.Add(new NotesConfigsking("Дела 4", "Получить визитку", "10.10.2023", "12:00"));
            NotesConfigskingList.Add(new NotesConfigsking("Дела 5", "Сходить в рестик", "10.10.2023", "12:00"));
            NotesConfigskingList.Add(new NotesConfigsking("Дела 6", "Покодить", "11.10.2023", "12:00"));
            NotesConfigskingList.Add(new NotesConfigsking("Дела 7", "Проследить за челом", "12.10.2023", "12:00"));
        }
    }

    public class NotesConfigsking
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public NotesConfigsking(string name, string description, string date, string time)
        {
            Name = name;
            Description = description;
            Date = date;
            Time = time;
        }
    }

}