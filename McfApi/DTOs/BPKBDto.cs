﻿using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace McfApi.DTOs
{
	public class BPKBDto
	{
        public int agreement_number { get; set; }
        public string branch_id { get; set; }
        public string bpkb_no { get; set; }
        public DateTime bpkb_date_in { get; set; }
        public DateTime bpkb_date { get; set; }
        public string faktur_no { get; set; }
        public DateTime faktur_date { get; set; }
        public string police_no { get; set; }
        public int location_id { get; set; }
        public int user_id { get; set; }
    }
}

