namespace LibraryManagementSystem.Utility
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public Response(T data, string message = null)
        {
            Success = true;
            Data = data;
            Message = message ?? "Request was successful.";
        }

    } 
}
