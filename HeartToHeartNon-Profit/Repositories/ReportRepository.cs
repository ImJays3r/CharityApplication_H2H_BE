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
        /// get first pic report
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task<string> GetFirstPicReport(int taskId)
        {
            string url = "";
            var report = await _context.Reports.Where(a => a.TaskId == taskId).FirstOrDefaultAsync();
            if (report != null)
            {
                var photo = await _context.Media.Where(u => u.ReportId == report.ReportId).FirstOrDefaultAsync();
                if (photo != null)
                {
                    url = photo.Url.ToString();
                }
            }
            return url;
        }

        /// <summary>
        /// get all photo of report
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetListAllPhoto(int reportId)
        {
            List<string> album = new List<string> { };
            var ListPhoto = await _context.Media
                .Where(u => u.ReportId == reportId)
                .ToListAsync();
            foreach(var photo in ListPhoto.ToList())
            {
                album.Add(photo.Url);
            }

            return album;
        }

        /// <summary>
        /// get list all report
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Data.Task>> GetLisAllReport(int campaignId)
        {
            var TaskList = await _context.Tasks
                .Where(u => u.CampaignId == campaignId)
                .ToListAsync();
            return TaskList;
        }

        /// <summary>
        /// get list all report of task
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Report>> GetLisAllReportOfTask(int taskId)
        {
            var listReport = await _context.Reports
                .Where(u => u.TaskId == taskId)
                .ToListAsync();
            return listReport;
        }

        /// <summary>
        /// get all report of task by member
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Report>> GetLisAllReportOfTaskByMember(int taskId, int memberid)
        {
            var listReport = await _context.Reports
                .Where(u => u.TaskId == taskId)
                .Where(t => t.MemberId == memberid)
                .ToListAsync();
            return listReport;
        }

        /// <summary>
        /// get list report of manager
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="ManagerId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Data.Task>> GetListReportManager(int campaignId, int ManagerId)
        {
            var ReportListManager = await _context.Tasks
                 .Where(u => u.CampaignId == campaignId)
                 .Where(a => a.ManagerId == ManagerId)
                 .ToListAsync();
            return ReportListManager;
        }


        /// <summary>
        /// get list report member
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TaskDetail>> GetListReportMember(int campaignId, int MemberId)
        {
            var ReportListMember = await _context.TaskDetails
                .Include(u => u.Task)
                .Where(c => c.Task.CampaignId == campaignId)
                .Where(a => a.MemberId == MemberId)
                .ToListAsync();

            return ReportListMember;
        }

        /// <summary>
        /// get total value of a single report
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task<decimal> GetTotalReportOfTask(int taskId)
        {
            var ListReport = await _context.Reports
                .Where(t => t.TaskId == taskId)
                .ToListAsync();
            var listCount = ListReport.ToList();
            decimal total = 0;
            foreach(var value in listCount)
            {
                total = total + value.Value;
            }
            return total;
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

        /// <summary>
        /// get report by id
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        public async Task<Report> GetReportById(int reportId)
        {
            var report = await _context.Reports
                 .Where(u => u.ReportId == reportId)
                 .FirstOrDefaultAsync();

            return report;
        }
    }
}
