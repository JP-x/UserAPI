namespace UserAPI.Models
{
    public class UserComment
    {
        //Need to map post Ids to the user Id
        public int PostId { get; set; }
        public int Id { get; set; }
        /// <summary>
        /// Email of the user that commented on the post
        /// </summary>
        public string Email { get; set; }
    }
}
