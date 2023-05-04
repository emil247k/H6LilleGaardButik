using Microsoft.EntityFrameworkCore;

namespace GaardButik.Server.Context
{
    public interface IDatabaseContext
    {
        DatabaseContext Instance { get; }
    }
}
