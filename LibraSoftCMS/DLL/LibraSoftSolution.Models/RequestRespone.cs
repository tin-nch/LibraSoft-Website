using System;

namespace LibraSoftSolution.Models
{
    public class RequestResponse
    {
        public ErrorCode ErrorCode { get; set; }
        public string Content { get; set; }
    }
    public enum ErrorCode
    {
        Success = 0,
        GeneralFailure = 1,
        NotFound = 2
    }
}
