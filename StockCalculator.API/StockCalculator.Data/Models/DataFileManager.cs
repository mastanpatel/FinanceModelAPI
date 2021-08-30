using System;
using System.Collections.Generic;

#nullable disable

namespace StockCalculator.Data.Models
{
    public partial class DataFileManager
    {
        public int DataFileManagerId { get; set; }
        public int? DataFileId { get; set; }
        public string YearMonth { get; set; }
        public DateTime? Date { get; set; }
        public string FileName { get; set; }
        public string DownloadLink { get; set; }
        public bool IsDownloaded { get; set; }
        public bool IsProcessed { get; set; }
        public bool IsErrorInFile { get; set; }
        public string FilePath { get; set; }

        public virtual DataFile DataFile { get; set; }
    }
}
