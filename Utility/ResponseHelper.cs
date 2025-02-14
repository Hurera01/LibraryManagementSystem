namespace LibraryManagementSystem.Utility
{
    public static class ResponseHelper
    {
        public static Response<T> SuccessResponse<T>(T data, string message = null)
        {
            return new Response<T>(data, message);
        }
    }
}
