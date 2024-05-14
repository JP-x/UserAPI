using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    //NOTE: I ran across these endpoints as I reached method #3.
    /*
    /posts/1/comments
    /albums/1/photos
    /users/1/albums
    /users/1/todos
    /users/1/posts
    */



    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;
        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// 1. Create a function that outputs a json file with a list of all users obtained from the /users web
        ///service.Your user json object should only include id, username, email, and city.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("UserList")]
        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                List<UserDTO> userDTOs = users.Select(u => new UserDTO 
                { 
                    Id = u.Id, 
                    Username = u.Username, 
                    City = u.Address.City, 
                    Email = u.Email 
                }).ToList();
                return userDTOs ?? new List<UserDTO>();
            }
            catch (Exception ex) { 
                return new List<UserDTO>();
            }
        }

        /// <summary>
        /// 2. Add another function to output a list of users, but this time only include the user’s id,
        ///     numberOfPosts, and numberOfTodos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Metrics")]
        public async Task<IEnumerable<UserDTO>> GetUserMetricsAsync()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                var posts = await _userService.GetAllUserPostsAsync();
                var todos = await _userService.GetAllUserTodosAsync();

                //initialize the object to iterate through
                List<UserDTO> userDTOs = users.Select(u => new UserDTO
                {
                    Id = u.Id,
                    City = null,
                    Email = null,
                    Username = null,
                    NumberOfPosts = 0,
                    NumberOfTodos = 0
                }).ToList();


                //small collection sizes so will not be too concerned about performance
                //for simplicity sake here just use LINQ
                //alternatively can make seperate requests per user and get totals using webservice
                // users/1/todos
                // users/1/posts
                foreach (var userDTO in userDTOs)
                {
                   //get count of posts / todos that have matching Ids
                   userDTO.NumberOfPosts = posts.Count(post => post.UserId == userDTO.Id);
                   userDTO.NumberOfTodos = todos.Count(todo => todo.UserId == userDTO.Id);
                }
                return userDTOs ?? new List<UserDTO>();
            }
            catch (Exception ex)
            {
                return new List<UserDTO>();
            }
        }

        /// <summary>
        /// 3. The next function should be another list of users, 
        /// with the objects including id, username, and
        /// commenters (a list of emails that have commented on that user’s posts).
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Commentors")]
        public async Task<IEnumerable<UserDTO>> GetUserEngagementAsync()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                //initialize the object to iterate through
                //the returned object should only contain the Id, username and the list of commenters
                List<UserDTO> userDTOs = users.Select(u => new UserDTO
                {
                    Id = u.Id,
                    City = null,
                    Email = null,
                    Username = u.Username,
                    NumberOfPosts = null,
                    NumberOfTodos = null,
                    Commenters = new List<string>()
                }).ToList();
                
                //iterate through EACH user and within EACH of their posts get a collection of unique commentor emails
                foreach (var userDTO in userDTOs)
                {
                    //set of commenter emails
                    HashSet<string> commenterEmails = new HashSet<string>();
                    //get all of a user's posts
                    List<UserPost> userPosts = await _userService.GetUserPostsByUserIdAsync(userDTO.Id);
                    foreach (var post in userPosts)
                    {
                       //get all user comments within a post
                       var userComments = await _userService.GetUserCommentsByPostIdAsync(post.Id);
                       foreach(var comment in userComments)
                       {
                            //add to commenter set if not found
                            if(!commenterEmails.Contains(comment.Email))
                            {
                                commenterEmails.Add(comment.Email);
                            }
                       }
                    }
                    //get the collection of unique commenters
                    userDTO.Commenters = commenterEmails.ToList();
                }
                return userDTOs ?? new List<UserDTO>();
            }
            catch (Exception ex)
            {
                return new List<UserDTO>();
            }
        }
    }
}