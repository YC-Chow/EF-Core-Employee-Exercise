using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models.VarCharNVarChar;
using System;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MaxIterationCount(300)]
    [MinIterationCount(100)]
    public class VarcharNVarcharBenchmarks {
        [Benchmark]
        public void VarcharSelect() {
            using (var _db = new VarcharNVarcharContext()) {
                _db.VarcharName
                    .Where(a => a.CreatedDate == DateTime.Parse("2022-04-04 00:00:00"))
                    .Select(a => new VarcharName() {
                        FName = a.FName,
                        MName = a.MName,
                        LName = a.LName
                    })
                    .ToList();
            }
        }

        [Benchmark]
        public void NVarcharSelect() {
            using (var _db = new VarcharNVarcharContext()) {
                _db.NVarcharName
                    .Where(a => a.CreatedDate == DateTime.Parse("2022-04-04 00:00:00"))
                    .Select(a => new NVarcharName() {
                        FName = a.FName,
                        MName = a.MName,
                        LName = a.LName
                    })
                    .ToList();
            }
        }

        [Benchmark]
        public void VarcharTop() {
            using (var _db = new VarcharNVarcharContext()) {
                _db.VarcharName
                    .Take(50000)
                    .ToList();
            }
        }

        [Benchmark]
        public void NVarcharTop() {
            using (var _db = new VarcharNVarcharContext()) {
                _db.NVarcharName
                    .Take(50000)
                    .ToList();
            }
        }
    }
}
