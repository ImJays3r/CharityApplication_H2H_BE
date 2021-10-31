using HeartToHeartNon_Profit.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User u);
    }
}
