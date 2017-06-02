using System;

namespace PM.Model.Common
{
    /// <summary>
    /// Base poco contract.
    /// </summary>
    public interface IBasePoco
    {
        Guid Id { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateUpdated { get; set; }
    }
}
