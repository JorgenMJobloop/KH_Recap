public class MusicModel
{
    /// <summary>
    /// Our unique identifier for each different data field, useful when we implement our database
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Field for our artists with a getter and a setter
    /// </summary>
    public required string Artist { get; set; }
    /// <summary>
    /// The title of the album
    /// </summary>
    public required string AlbumTitle { get; set; }
    /// <summary>
    /// The release year of the album
    /// </summary>
    public required int AlbumReleaseYear { get; set; }
    /// <summary>
    /// The genre of music the artists perform
    /// </summary>
    public required string Genre { get; set; }
}