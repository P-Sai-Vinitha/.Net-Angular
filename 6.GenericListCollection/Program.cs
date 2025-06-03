using System;

class Program
{
    static void Main(string[] args)
    {
        MyPlaylist playlist = new MyPlaylist();
        while (true)
        {
            Console.WriteLine("\nMENU:");
            Console.WriteLine("1. Add Song");
            Console.WriteLine("2. Remove Song by Id");
            Console.WriteLine("3. Get Song by Id");
            Console.WriteLine("4. Get Song by Name");
            Console.WriteLine("5. Get All Songs");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Song song = new Song();
                    Console.Write("Enter Song ID: ");
                    song.SongId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Song Name: ");
                    song.SongName = Console.ReadLine();
                    Console.Write("Enter Song Genre: ");
                    song.SongGenre = Console.ReadLine();
                    playlist.Add(song);
                    break;

                case 2:
                    Console.Write("Enter Song ID to remove: ");
                    int idToRemove = int.Parse(Console.ReadLine());
                    playlist.Remove(idToRemove);
                    break;

                case 3:
                    Console.Write("Enter Song ID: ");
                    int id = int.Parse(Console.ReadLine());
                    var songById = playlist.GetSongById(id);
                    Console.WriteLine(songById != null ? songById.ToString() : "Song not found.");
                    break;

                case 4:
                    Console.Write("Enter Song Name: ");
                    string name = Console.ReadLine();
                    var songByName = playlist.GetSongByName(name);
                    Console.WriteLine(songByName != null ? songByName.ToString() : "Song not found.");
                    break;

                case 5:
                    var allSongs = playlist.GetAllSongs();
                    if (allSongs.Count == 0)
                        Console.WriteLine("No songs in playlist.");
                    else
                        allSongs.ForEach(s => Console.WriteLine(s));
                    break;

                case 6:
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
