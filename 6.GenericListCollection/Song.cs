public class Song
{
    public int SongId { get; set; }
    public string SongName { get; set; }
    public string SongGenre { get; set; }

    public override string ToString()
    {
        return $"ID: {SongId}, Name: {SongName}, Genre: {SongGenre}";
    }
}
