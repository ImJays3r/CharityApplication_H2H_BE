using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Interfaces
{
    public interface IRandomService
    {
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);

        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

    }
}
