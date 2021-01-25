using System.Linq;
using WindowsyProjekt.Models.Requests;
using WindowsyProjekt.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace WindowsyProjekt.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly WinProjDbContext _dbContext;

        public ProjectRepository(WinProjDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int SaveToDatabase(DataRequest request)
        {
            int affectedRows = 0;

            if (!_dbContext.Streets.Where(s => s.StreetName == request.StreetName).AsNoTracking().ToList().Any())
            {
                _dbContext.Streets.Add(new Street
                {
                    City = request.City,
                    StreetName = request.StreetName,
                    StreetCordX = request.StreetCordX,
                    StreetCordY = request.StreetCordY,
                    Additional = request.Additional,
                    PostCode = string.Empty
                });

                affectedRows = _dbContext.SaveChanges();
            }
            else
            {
                var street = _dbContext.Streets.FirstOrDefault(s => s.StreetName == request.StreetName);
                street.City = request.City;
                street.StreetCordX = request.StreetCordX;
                street.StreetCordY = request.StreetCordY;
                street.Additional = request.Additional;

                affectedRows = _dbContext.SaveChanges();
            }

            return affectedRows;
        }
    }
}
