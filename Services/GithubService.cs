using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeilinHome.Models;
using Microsoft.Extensions.Caching.Memory;
using Octokit;

namespace TeilinHome.Services
{
    public class GithubService : IGithubService
    {
        private static readonly string CacheKey = nameof(GithubService);

        private readonly IGitHubClient _client;
        private readonly IMemoryCache _cache;

        public GithubService(IMemoryCache cache, IGitHubClient client)
        {
            _cache = cache;
            _client = client;
        }

        public async Task<IList<GithubRepository>> GetLatestRepositories(int numLast)
        {
            /*
            var liveShowDetails = _cache.Get<LiveShowDetails>(CacheKey);
            if (liveShowDetails == null)
            {
                liveShowDetails = await LoadFromAzureStorage();
                _cache.Set(CacheKey, liveShowDetails, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.MaxValue
                });
            }
            */

            var publicRepos = await _client.Repository.GetAllPublic();

            IEnumerable<GithubRepository> enumerable = publicRepos
                    .Select(s => new GithubRepository()
                    {
                        Id = s.Id,
                        Name = s.FullName,
                        RepoUri = s.GitUrl
                    })
                    .Take(numLast);
            return enumerable.ToList();
        }
    }
}