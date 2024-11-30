using UKParliament.CodeTest.Data.Models;

namespace UKParliament.CodeTest.Data.Repositories;

public class PayBandRepository(PersonManagerContext db) : BaseRepository<PayBand>(db)
{
    public override IQueryable<PayBand> Search()
    {
        return _db.PayBands.AsQueryable();
    }
}
