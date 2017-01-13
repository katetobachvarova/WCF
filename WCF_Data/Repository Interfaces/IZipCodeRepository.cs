using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using WCF_Core;

namespace WCF_Data
{
    public interface IZipCodeRepository : IDataRepository<ZipCode>
    {
        ZipCode GetByZip(string zip);
        IEnumerable<ZipCode> GetByState(string state);
        IEnumerable<ZipCode> GetZipsForRange(ZipCode zip, int range);
    }
}
