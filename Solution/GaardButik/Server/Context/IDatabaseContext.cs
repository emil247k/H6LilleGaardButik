using Microsoft.EntityFrameworkCore;

namespace GaardButik.Server.Context
{
    public interface IDatabaseContext
    {
        DbContext Instance { get; }
    }
}
