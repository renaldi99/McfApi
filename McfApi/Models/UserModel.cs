using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McfApi.Models
{
    [Table(name: "ms_user")]
    public class UserModel
	{
        [Key]
        public int user_id { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? user_name { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? password { get; set; }
        public bool? is_active { get; set; }
    }
}

