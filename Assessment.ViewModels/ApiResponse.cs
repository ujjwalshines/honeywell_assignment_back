using System;

namespace Assessment.ViewModels
{
    public class ApiResponse
    {
        public string Message { get; set; }
        public dynamic Response { get; set; }
        public ApiError Error { get; set; }
        public string Status { get; set; }
    }
}
