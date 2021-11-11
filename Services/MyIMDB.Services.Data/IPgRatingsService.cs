namespace MyIMDB.Services.Data
{
    using System.Collections.Generic;

    public interface IPgRatingsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
