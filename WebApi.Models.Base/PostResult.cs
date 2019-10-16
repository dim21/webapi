namespace WebApi.Models.Base
{
    public class PostResult<TId>
    {
        public TId Id { get; set; }

        public string Error { get; set; }
    }
}