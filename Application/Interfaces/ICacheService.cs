using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICacheService
    {
        void SetCache(string chave, object value, TimeSpan? expiration);

        object? GetCache(string chave);
    }
}
