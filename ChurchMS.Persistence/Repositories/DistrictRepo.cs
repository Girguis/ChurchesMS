using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Domain.Entites;
using ChurchMS.Persistence.DatabaseContext;

namespace ChurchMS.Persistence.Repositories;

public class DistrictRepo(ChurchMSContext dbContext) : GenericRepo<District, int>(dbContext), IDistrictRepo
{
}