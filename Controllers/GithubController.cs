using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using TeilinHome.Services;
using TeilinHome.Models;
using System.Threading;

namespace TeilinHome.Controllers
{
    public class GithubController
    {
        private readonly IHostingEnvironment _env;
        private readonly AppSettings _appSettings;
        private readonly IGithubService _service;

        public GithubController(IHostingEnvironment env, 
                                IGithubService service,
                                IOptions<AppSettings> appSettings)
        {
            _env = env;
            _service = service;
            _appSettings = appSettings.Value;
        }

        public async Task<IEnumerable<GithubRepository>> GetPublicRepos(int numRepos)
        {
            return await _service.GetLatestRepositories(numRepos);
        }
    }
}