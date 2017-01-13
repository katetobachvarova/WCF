using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using WCF_Core;

namespace WCF_Data
{
    public interface IStateRepository : IDataRepository<State>
    {
        State Get(string abbrev);
        IEnumerable<State> Get(bool primaryOnly);
    }
}
