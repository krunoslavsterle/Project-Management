using PM.Model.Common;
using System;

namespace PM.Model
{
    /// <summary>
    /// Base Poco class.
    /// </summary>
    public abstract class BasePoco : IBasePoco
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
