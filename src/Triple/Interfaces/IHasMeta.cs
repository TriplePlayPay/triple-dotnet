using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triple.Interfaces
{
    /// <summary>
    /// Interface that identifies entities with a Meta property of type
    /// <see cref="Dictionary{String, Object}" />.
    /// </summary>
    public interface IHasMeta
    {
        /// <summary>
        /// Set of key-value pairs that you can attach to an object. This can be useful for storing
        /// additional information about the object in a structured format.
        /// </summary>
        dynamic? Meta { get; set; }
    }
}
