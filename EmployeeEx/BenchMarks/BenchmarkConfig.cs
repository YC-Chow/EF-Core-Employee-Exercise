using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters.Csv;
using Perfolizer.Horology;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Loggers;

namespace EmployeeEx.BenchMarks {
    public class BenchmarkConfig : ManualConfig {
        public BenchmarkConfig() {
            AddColumnProvider(DefaultColumnProviders.Instance);
            AddLogger(new ConsoleLogger());
            AddDiagnoser(MemoryDiagnoser.Default);
            AddExporter(new CsvExporter(
                CsvSeparator.CurrentCulture,
                new SummaryStyle(
                    cultureInfo: System.Globalization.CultureInfo.CurrentCulture,
                    printUnitsInHeader: false,
                    printUnitsInContent: true,
                    timeUnit: TimeUnit.Millisecond,
                    sizeUnit: SizeUnit.KB
                )));
            this.SummaryStyle = SummaryStyle.Default.WithTimeUnit(TimeUnit.Millisecond).WithSizeUnit(SizeUnit.KB);
        }
    }
}
