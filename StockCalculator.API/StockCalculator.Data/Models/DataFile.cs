using System;
using System.Collections.Generic;

#nullable disable

namespace StockCalculator.Data.Models
{
    public partial class DataFile
    {
        public int DataFileId { get; set; }
        public string DataFileName { get; set; }
        public string DataFileType { get; set; }
        public string DataFileDesc { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ParentId { get; set; }
        public int? ChildId { get; set; }
        public bool? IsEnable { get; set; }
    }
}
