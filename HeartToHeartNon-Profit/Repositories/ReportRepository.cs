using HeartToHeartNon_Profit.Models.Data;
using HeartToHeartNon_Profit.Models.Input;
using HeartToHeartNon_Profit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private const string Format = "dd-MM-yyyy";
        private readonly HeartToHeartContext _context;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public ReportRepository(HeartToHeartContext context)
        {
            _context = context;
        }

        /// <summary>
        /// create a report
        /// </summary>
        /// <param name="input"></param>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public async Task<int> CreateReport(CreateReportInput input, int memberid)
        {
            var task = await _context.Tasks.Where(c => c.TaskId == input.TaskId).SingleOrDefaultAsync();
           Report report = new()
            {
               TaskId = input.TaskId,
               MemberId = memberid,
               Description =input.Description,
               ReportType = task.TaskType,
               Value = input.Value,
               Status = false
            };

            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
            return  report.ReportId;
        }

        /// <summary>
        /// Update albumn of report to table media
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<bool> UpdateReportAlbum(UpdatePictureReportInput input)
        {
            var listPhoto = input.Url.ToList();
            foreach(var photo in listPhoto)
            {
                Medium media = new()
                {
                    ReportId = input.ReportId,
                    Url = photo
                };
                await _context.Media.AddAsync(media);
            }
            
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
