using HeartToHeartNon_Profit.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Repositories.Interfaces
{
    public interface IReportRepository
    {
        /// <summary>
        /// Register new account auto set role member
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task<int> CreateReport(CreateReportInput input, int memberid);

        /// <summary>
        /// update picture when create campaign
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task<bool> UpdateReportAlbum(UpdatePictureReportInput input);
    }
}
