using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triple.Interfaces
{
    /// <summary>
    /// Interface that identifies entities returned by Triple that have an `id` attribute.
    /// </summary>
    public interface IHasId
    {
        /// <summary>
        /// Unique identifier for the object.
        /// </summary>
        string Id { get; set; }
    }
}
