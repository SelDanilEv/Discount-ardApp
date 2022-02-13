using DiscountСardApp.Common.Enums;

namespace DiscountСardApp.Application.Models.V1.EmptyResult
{
    public class EmptyResult
    {
        public EmptyResult(string message, ResponseStatus status)
        {
            Message = message;
            Status = status;
        }

        public string Message { get; set; } = String.Empty;
        public ResponseStatus Status { get; set; }

        public static EmptyResult SuccessResult(string message) => new EmptyResult(message, ResponseStatus.Success);
        public static EmptyResult SuccessResult() => new EmptyResult(String.Empty, ResponseStatus.Success);
        public static EmptyResult ErrorResult(string message) => new EmptyResult(message, ResponseStatus.Error);
        public static EmptyResult ErrorResult() => new EmptyResult(String.Empty, ResponseStatus.Error);
    }
}
