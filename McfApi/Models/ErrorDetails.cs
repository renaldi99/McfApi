using System;
namespace McfApi.Models
{
	public class ErrorDetails
	{
        public bool is_success { get; set; }
        public int status_code { get; set; }
        public string? message { get; set; }
        public string? path { get; set; }
    }

    public class PayloadDetails
    {
        public bool is_success { get; set; }
        public int status_code { get; set; }
        public string? message { get; set; }
    }

    public class ResponseData
    {
        public bool is_success { get; set; }
        public int status_code { get; set; }
        public string? message { get; set; }
        public dynamic data { get; set; }
    }
}

