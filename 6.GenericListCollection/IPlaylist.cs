using System.Collections.Generic;

public interface IPlaylist
{
    void Add(Song song);
    void Remove(int songId);
    Song GetSongById(int songId);
    Song GetSongByName(string songName);
    List<Song> GetAllSongs();
}
