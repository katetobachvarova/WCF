using System;
using System.Collections.Generic;
using System.Linq;

namespace WCF_Core
{
    public interface IIdentifiableEntity
    {
        int EntityId { get; set; }
    }
}
