using WindowsyProjekt.Models.Requests;

namespace WindowsyProjekt.Repository
{
    public interface IProjectRepository
    {
        int SaveToDatabase(DataRequest request);
    }
}
