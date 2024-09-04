using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McfApi.Models
{
	[Table(name: "tr_bpkb")]
	public class BPKBModel
	{
		[Key]
		public int agreement_number { get; set; }
		[Column(TypeName = "varchar(100)")]
		public string? bpkb_no { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string? branch_id { get; set; }
        public DateTime? bpkb_date { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? faktur_no { get; set; }
		public DateTime? faktur_date { get; set; }

        // Foreign Key Property
        public int location_id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? police_no { get; set; }
		public DateTime? bpkb_date_in { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? created_by { get; set; }
		public DateTime? created_on { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? last_updated_by { get; set; }
		public DateTime? last_updated_on { get; set; }

        // Navigation Property
        [ForeignKey("location_id")]
        public StorageLocationModel? storage_location { get; set; }
    }
}

