namespace Application.Dtos.MediatR
{
    public class OperationResult<T>
    {
        public T? Result { get; set; }
        public required bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }

        public static OperationResult<T> Ok(T data) =>
            new OperationResult<T> { IsSuccess = true, Result = data };

        public static OperationResult<T> Fail(string error) =>
            new OperationResult<T> { IsSuccess = false, ErrorMessage = error };
    }
}
