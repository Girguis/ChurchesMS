using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Domain.Entites;
using ChurchMS.Persistence.DatabaseContext;

namespace ChurchMS.Persistence.Repositories;

public class StreetRepo(ChurchMSContext dbContext) : GenericRepo<Street, int>(dbContext), IStreetRepo
{
}