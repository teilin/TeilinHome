using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeilinHome.Models;

namespace TeilinHome.Services
{
    public interface IGithubService
    {
        Task<IList<GithubRepository>> GetLatestRepositories(int numLast);
    }
}