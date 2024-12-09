using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Domain.Entites;
using ChurchMS.Persistence.DatabaseContext;

namespace ChurchMS.Persistence.Repositories;

public class CityRepo(ChurchMSContext dbContext) : GenericRepo<City, int>(dbContext), ICityRepo
{
}