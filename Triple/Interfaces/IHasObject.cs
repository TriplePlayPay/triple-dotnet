using System.Collections.Generic;

namespace Triple.Interfaces
{
    /// <summary>
    /// Interface that identifies entities returned by Stripe that have an `object` attribute.
    /// </summary>
    public interface IHasObject
    {
        /// <summary>
        /// String representing the object's type. Objects of the same type share the same value.
        /// </summary>
        string Object { get; set; }
    }
}
