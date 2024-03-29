﻿using HeartToHeartNon_Profit.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeartToHeartNon_Profit.Models.Data;

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

        /// <summary>
        /// get list all report of campaign
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Models.Data.Task>> GetLisAllReport(int campaignId);

        /// <summary>
        /// get list report of campaign for manager
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Models.Data.Task>> GetListReportManager(int campaignId, int ManagerId);

        /// <summary>
        /// get list report of campaign for member
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TaskDetail>> GetListReportMember(int campaignId, int MemberId);

        /// <summary>
        /// get number of report in a task
        /// </summary>
        /// <returns></returns>
        Task<decimal> GetTotalReportOfTask (int taskId);

        /// <summary>
        /// get first pic of report
        /// </summary>
        /// <returns></returns>
        Task<string> GetFirstPicReport(int taskId);

        /// <summary>
        /// get list all report of task
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Report>> GetLisAllReportOfTask(int taskId);

        /// <summary>
        /// get list all report of task by member
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Report>> GetLisAllReportOfTaskByMember(int taskId, int memberid);

        /// <summary>
        /// get list all photo of report
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<string>> GetListAllPhoto(int reportId);

        /// <summary>
        /// get report by id
        /// </summary>
        /// <returns></returns>
        Task<Report> GetReportById(int reportId);
    }
}
