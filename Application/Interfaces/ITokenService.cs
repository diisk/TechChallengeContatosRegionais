﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITokenService
    {
        string GetToken(Usuario usuario);
        int GetUserIdFromClaimsPrincipal(ClaimsPrincipal user);
    }
}
