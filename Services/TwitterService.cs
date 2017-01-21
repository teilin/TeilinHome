using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeilinHome.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace TeilinHome.Services
{
    public class TwitterService : ITwitterService
    {
        private readonly IMemoryCache _cache;
        private readonly AppSettings _appSettings;

        public TwitterService(IMemoryCache cache, IOptions<AppSettings> appSettings)
        {
            _cache = cache;
            _appSettings = appSettings.Value;
        }
    }
}