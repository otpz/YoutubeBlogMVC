﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeBlogMVC.Service.Services.Abstraction
{
    public interface IDashboardService
    {
        Task<List<int>> GetYearlyArticleCounts();
        Task<int> GetTotalArticleCount();
        Task<int> GetTotalCategoryCount();
    }
}
