namespace UserAPI.Models
{
    /* NOTE: Serializer options are set so that NULL values are ignored when generating output
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    */
    /// <summary>
    /// user object to return
    /// </summary>
    public class UserDTO
    {
        public int Id { get; set; } = 0;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int? NumberOfPosts { get; set; } = null;
        public int? NumberOfTodos { get; set;} = null;
        public List<string>? Commenters { get; set; } = null;
    }
}
