using System;

namespace Catstagram.Server.Data.Models.Base
{
    interface IDeletableEntity : IEntity
    {
        DateTime? DeletedOn { get; set; }
        string DeletedBy { get; set; }
        bool IsDeleted { get; set; }
    }
}
