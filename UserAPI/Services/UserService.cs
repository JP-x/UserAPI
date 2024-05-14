using Newtonsoft.Json;
using System.Text.Json.Serialization;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class UserService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUri;
        public UserService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _baseUri = _configuration.GetConnectionString("userapi");
        }

        /// <summary>
        /// Return User Id, Username, Email and City
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient();
                //users endpoint
                var apiUrl = $"{_baseUri}/users";
                var response = await client.GetAsync(apiUrl);
                var users = JsonConvert.DeserializeObject<List<User>>(await response.Content.ReadAsStringAsync());
                return users ?? new List<User>();
            }
            catch(Exception ex)
            {
                return await Task.FromException<List<User>>(ex);
            }
        }

        public async Task<List<UserPost>> GetAllUserPostsAsync()
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient();
                //users endpoint
                var apiUrl = $"{_baseUri}/posts";
                var response = await client.GetAsync(apiUrl);
                var userPosts = JsonConvert.DeserializeObject<List<UserPost>>(await response.Content.ReadAsStringAsync());
                return userPosts ?? new List<UserPost>();
            }
            catch (Exception ex)
            {
                return await Task.FromException<List<UserPost>>(ex);
            }
        }

        public async Task<List<UserPost>> GetUserPostsByUserIdAsync(int userId)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient();
                //users endpoint
                var apiUrl = $"{_baseUri}/users/{userId}/posts";
                var response = await client.GetAsync(apiUrl);
                var userPosts = JsonConvert.DeserializeObject<List<UserPost>>(await response.Content.ReadAsStringAsync());
                return userPosts ?? new List<UserPost>();
            }
            catch (Exception ex)
            {
                return await Task.FromException<List<UserPost>>(ex);
            }
        }


        public async Task<List<UserTodo>> GetAllUserTodosAsync()
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient();
                //users endpoint
                var apiUrl = $"{_baseUri}/todos";
                var response = await client.GetAsync(apiUrl);
                var userTodos = JsonConvert.DeserializeObject<List<UserTodo>>(await response.Content.ReadAsStringAsync());
                return userTodos ?? new List<UserTodo>();
            }
            catch (Exception ex)
            {
                return await Task.FromException<List<UserTodo>>(ex);
            }
        }

        public async Task<List<UserComment>> GetUserCommentsByPostIdAsync(int postId)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient();
                //users endpoint
                var apiUrl = $"{_baseUri}/posts/{postId}/comments";
                var response = await client.GetAsync(apiUrl);
                var userComments = JsonConvert.DeserializeObject<List<UserComment>>(await response.Content.ReadAsStringAsync());
                return userComments ?? new List<UserComment>();
            }
            catch (Exception ex)
            {
                return await Task.FromException<List<UserComment>>(ex);
            }
        }


    }
}
