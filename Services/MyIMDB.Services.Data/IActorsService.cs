namespace MyIMDB.Services.Data
{
    using System.Collections.Generic;

    public interface IActorsService
    {
        IEnumerable<T> GetAll<T>();
    }
}
