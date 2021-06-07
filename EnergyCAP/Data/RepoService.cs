using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnergyCAP.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace EnergyCAP.Data
{
    public class RepoService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly HttpClient _httpClient;

        public RepoService(ApplicationDbContext ApplicationDbContext, HttpClient HttpClient)
        {
            _dbContext = ApplicationDbContext;
            _httpClient = HttpClient;
        }

        /// <summary>
        /// Insert Repo
        /// </summary>
        /// <param name="repo"></param>
        /// <returns></returns>
        public async Task<bool> InsertRepoAsync(Repo repo)
        {
            await _dbContext.Repos.AddAsync(repo);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Get list of Repos from database
        /// </summary>
        /// <param name="username">Github username</param>
        /// <returns></returns>
        public async Task<List<Repo>> GetListReposAsync(string username)
        {
            return await _dbContext.Repos.Where(c => c.Username.Equals(username)).ToListAsync();
        }

        /// <summary>
        /// Delete repo from database
        /// </summary>
        /// <param name="username">Github username</param>
        /// <returns></returns>
        public async Task<bool> DeleteRepoAsync(string username)
        {
            var repos = await _dbContext.Repos.Where(c => c.Username.Equals(username)).ToListAsync();
            foreach (var repo in repos)
            {
                _dbContext.Remove(repo);
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Get list of starred repos from Github
        /// </summary>
        /// <param name="username">Github username</param>
        /// <returns></returns>
        public async Task<List<Repo>> GetListStarredReposFromGithubAsync(string username)
        {
            var header = new ProductInfoHeaderValue("User-Agent", "request");
            _httpClient.DefaultRequestHeaders.UserAgent.Add(header);
            var response = await _httpClient.GetAsync("https://api.github.com/users/" + username + "/starred");

            var responseStream = await response.Content.ReadAsStringAsync();
            dynamic responseObjects = JsonConvert.DeserializeObject(responseStream);
            List<Repo> repList = new List<Repo>();
            foreach (var responseItem in responseObjects)
            {
                Repo repo = new Repo();
                repo.Name = responseItem.name;
                repo.Description = responseItem.description;
                repo.License = "";
                var a = responseItem.license.GetType();

                if (responseItem.license.GetType().Name == "JObject")
                {
                    repo.License = responseItem.license.key;
                }

                repo.Username = username;
                repList.Add(repo);
                await InsertRepoAsync(repo);
            }
            
            return repList;
        }
    }
}