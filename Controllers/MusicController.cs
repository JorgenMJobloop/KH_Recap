using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/music")]
public class MusicController : ControllerBase
{
    // we can create a static list of data, that we fill in, to our model
    private static List<MusicModel> musicModel = new List<MusicModel> {
        new MusicModel { Id = 1, Artist = "Death", AlbumTitle = "Crystal Mountain", AlbumReleaseYear = 1995, Genre = "Death Metal"},
        new MusicModel { Id = 2, Artist = "John Grant", AlbumTitle = "Pale Green Ghosts", AlbumReleaseYear = 2013, Genre = "Alternative" },
        new MusicModel { Id = 3, Artist = "Keane", AlbumTitle = "Hopes and Fears", AlbumReleaseYear = 2004, Genre = "Britpop" },
        new MusicModel { Id = 4, Artist = "MF DOOM", AlbumTitle = "Mm..Food", AlbumReleaseYear = 2004, Genre = "Hip-hop" },
        new MusicModel { Id = 5, Artist = "NF", AlbumTitle = "Hope", AlbumReleaseYear = 2023, Genre = "Rap" },
    };

    // We can define our GET-endpoint, using a IEnumearble
    [HttpGet]
    public IEnumerable<MusicModel> GetMusic()
    {
        return musicModel;
    }

    /// <summary>
    /// We take in a Post HTTP method call, as an action, and pass the body as data to our GET-endpoint
    /// </summary>
    /// <param name="_musicModel">Our model object</param>
    /// <returns>A new action, that "appends" data, to our already existing model data, on our GET-endpoint</returns>
    [HttpPost]
    public IActionResult Post([FromBody] MusicModel _musicModel)
    {
        // we check on this line, that we have the correct format of input from the client-side users of the application, if the input is wrong, we send back a BadRequest error!
        if (_musicModel == null)
        {
            return BadRequest("A Client-side error occured!");
        }
        // we let the body decide, which data to fill in and pass on back to the model object List from line 8
        musicModel.Add(_musicModel);
        return CreatedAtAction(nameof(Post), new { id = _musicModel.Id, artist = _musicModel.Artist, albumTitle = _musicModel.AlbumTitle, albumReleaseYear = _musicModel.AlbumReleaseYear, genre = _musicModel.Genre }, _musicModel);
    }

    /// <summary>
    /// We can try to create a route, where we accept Form data, from an external frontend
    /// </summary>
    /// <param name="_musicModel"></param>
    /// <returns></returns>
    [HttpPost("api/test/formdata")]
    public IActionResult Form([FromForm] MusicModel _musicModel)
    {
        // we check on this line, that we have the correct format of input from the client-side users of the application, if the input is wrong, we send back a BadRequest error!
        if (_musicModel == null)
        {
            return BadRequest("A Client-side error occured!");
        }
        // we let the body decide, which data to fill in and pass on back to the model object List from line 8
        musicModel.Add(_musicModel);
        return CreatedAtAction(nameof(Post), new { id = _musicModel.Id, artist = _musicModel.Artist, albumTitle = _musicModel.AlbumTitle, albumReleaseYear = _musicModel.AlbumReleaseYear, genre = _musicModel.Genre }, _musicModel);
    }
}