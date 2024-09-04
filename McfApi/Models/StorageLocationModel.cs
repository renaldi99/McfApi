using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McfApi.Models
{
	[Table(name: "ms_storage_location")]
	public class StorageLocationModel
	{
		[Key]
		public int location_id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? location_name { get; set; }
    }
}

