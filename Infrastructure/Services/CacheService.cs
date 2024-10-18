﻿using Application.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public object? GetCache(string chave)
        {
            memoryCache.TryGetValue(chave,out var value);
            return value;
        }

        public void SetCache(string chave, object value, TimeSpan? expiration)
        {
            if (expiration==null)
            {
                memoryCache.Set(chave, value);
                return;
            }

            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration,
            };

            memoryCache.Set(chave, value, cacheOptions);
        }
    }
}
