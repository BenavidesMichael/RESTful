namespace RESTful.API.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }

        public ApiResponse(T data)
        {
            this.Data = data;
        }

    }
}
