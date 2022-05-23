using EFDataAccessLibrary.Models.BigData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess {
    public interface IBigDataContext {
        DbSet<BigData> BigData { get; set; }
    }
}
