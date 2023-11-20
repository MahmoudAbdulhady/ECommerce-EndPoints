using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Model;
using EcommerceApp.Services;




namespace EcommerceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly TokenService _tokenService;
        private readonly IUserRepository _userRepository;


        

       
        

        public UserController(TokenService tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("/register")]
        public IActionResult AddUser([FromBody] User user)
        {
            if(ModelState.IsValid)
            {
            _userRepository.CreateUser(user);

            }

            return Ok(new { Message = "User Created Sucessfully" });

        }

        [HttpPost]
        [Route("/login")]
        public IActionResult loginUser([FromBody] LoginModel login)
        {
            
           if(!ModelState.IsValid)
            {
                return BadRequest(new {Message ="Invalid User data"});
            }

            var user = _userRepository.LoginUser(login.UserName, login.Password);
             
            if(user != null)
            {
                var token = _tokenService.CreateToken(user);
                return Ok(new { Message = "User Logged in Sucessfully  "  + token});
            }
            else
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }

        }



    }


}

