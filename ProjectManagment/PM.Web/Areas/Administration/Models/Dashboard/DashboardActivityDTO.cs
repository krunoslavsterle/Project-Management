using PM.Common.Enums;
using System;

namespace PM.Web.Areas.Administration.Models
{
    public class DashboardActivityDTO
    {
        public string AuthorUsername { get; set; }

        public string ActivityText { get; set; }

        // TODO: ActivityType - this should be enum or lookup
        public ActivityType ActivityType { get; set; }

        // TODO: Magnitude - this should be enum or lookup
        public ActivityMagnitude Magnitude { get; set; }

        // TODO: DateTime extension - format date to string (today, yesterday...).
        public DateTime DateCreated { get; set; }
    }
}
