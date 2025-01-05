using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Advanced.Csharp.Contracts.Defines
{
    public interface IModel
    {
        string Id { get; }
        bool IsDeleted { get; }

        #region
        // no setters for encapsulation,immutability, data-integrity
        #endregion
    }
}
