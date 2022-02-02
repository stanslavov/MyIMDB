namespace MyIMDB.Services.Data
{
    using System.Collections.Generic;

    public interface IGenreService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
