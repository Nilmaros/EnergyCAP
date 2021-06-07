using EnergyCAP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnergyCAP.Interfaces
{
    public interface IRepoService
    {
        Task<bool> DeleteRepoAsync(string username);
        Task<List<Repo>> GetListReposAsync(string username);
        Task<List<Repo>> GetListStarredReposFromGithubAsync(string username);
        Task<bool> InsertRepoAsync(Repo repo);
    }
}