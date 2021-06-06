using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnergyCAP.Models;

namespace EnergyCAP.Data
{
    public class RepoService
    {
        #region Property  
        private readonly ApplicationDbContext _dbContext;
        #endregion

        #region Constructor  
        public RepoService(ApplicationDbContext ApplicationDbContext)
        {
            _dbContext = ApplicationDbContext;
        }
        #endregion

        #region Get List of Repos
        public async Task<List<Repo>> GetAllReposAsyn()
        {
            return await _dbContext.Repos.ToListAsync();
        }
        #endregion

        #region Insert Repo
        public async Task<bool> InsertRepoAsync(Repo employee)
        {
            await _dbContext.Repos.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Repo by UserNameReposId
        public async Task<List<Repo>> GetListReposAsync(int UserNameReposId)
        {
            List<Repo> repos = await _dbContext.Repos.Where(c => c.Id.Equals(UserNameReposId)).ToListAsync();
            return repos;
        }
        #endregion

        #region Update Repo  
        public async Task<bool> UpdateRepoAsync(Repo repo)
        {
            _dbContext.Repos.Update(repo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Repo
        public async Task<bool> DeleteRepoAsync(Repo repo)
        {
            _dbContext.Remove(repo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}