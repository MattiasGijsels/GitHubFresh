using Examen.Advanced.Csharp.Contracts.Defines;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Advanced.Csharp.Contracts.Shared
{
    public class ModelBase : IModel
    {
        [StringLength(50)]
        public string Id { get; set; } = default!; 
        public bool IsDeleted { get; set; } = false;
        public ModelBase()
        {
            Id = Guid.NewGuid().ToString("N");
        }
        public ModelBase(string id)
        {
            Id = id;
        }
    }
    #region
    // default! = Id will always be assigned a value
    // Id = Guid.NewGuid().ToString("N"); formats the GUID as a 32-character string without dashes
    #endregion
}
