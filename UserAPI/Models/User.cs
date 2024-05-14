namespace UserAPI.Models
{
    /// <summary>
    /// Class to serialize incoming data 
    /// </summary>
    public class User
    {
        //#1
        public int Id { get; set; } = 0;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserAddress Address { get; set; } = new UserAddress();
        //#2
        public List<UserPost> Posts { get; set; }
        public List<UserTodo> Todos { get; set; }
        public int? NumberOfPosts { get; set; } = 0;
        public int? NumberOfTodos { get; set; } = 0;
        //#3 
        public List<User> Commentors { get; set; } = new List<User>();
    }
}
