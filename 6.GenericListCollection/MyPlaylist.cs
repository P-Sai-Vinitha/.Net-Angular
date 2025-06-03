using System;
using System.Collections.Generic;
using System.Linq;

public class MyPlaylist : IPlaylist
{
    public static List<Song> myPlayList = new List<Song>();
    private int capacity;

    public MyPlaylist()
    {
        capacity = 20;
    }

    public void Add(Song song)
    {
        if (myPlayList.Count >= capacity)
        {
            Console.WriteLine("Playlist is full. Cannot add more than 20 songs.");
            return;
        }

        string[] validGenres = { "Pop", "HipHop", "Soul Music", "Jazz", "Rock", "Disco", "Melody", "Classic" };
        if (!validGenres.Contains(song.SongGenre))
        {
            Console.WriteLine("Invalid Genre. Must be one of: " + string.Join(", ", validGenres));
            return;
        }

        myPlayList.Add(song);
        Console.WriteLine("Song added successfully!");
    }

    public void Remove(int songId)
    {
        Song song = myPlayList.FirstOrDefault(s => s.SongId == songId);
        if (song != null)
        {
            myPlayList.Remove(song);
            Console.WriteLine("Song removed successfully!");
        }
        else
        {
            Console.WriteLine("Song not found.");
        }
    }

    public Song GetSongById(int songId)
    {
        return myPlayList.FirstOrDefault(s => s.SongId == songId);
    }

    public Song GetSongByName(string songName)
    {
        return myPlayList.FirstOrDefault(s => s.SongName.Equals(songName, StringComparison.OrdinalIgnoreCase));
    }

    public List<Song> GetAllSongs()
    {
        return myPlayList;
    }
}
