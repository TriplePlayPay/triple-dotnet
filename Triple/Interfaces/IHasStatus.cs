using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triple.Interfaces
{
    /// <summary>
    /// Interface that identifies entities returned by Triple that have a `status` attribute.
    /// </summary>
    public interface IHasStatus
    {
        /// <summary>
        /// Status identifier for the object.
        /// </summary>
        bool Status { get; set; }
    }
}
