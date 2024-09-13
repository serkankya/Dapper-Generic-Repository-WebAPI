using Dapper.Business.Abstract;
using Dapper.Entities.Concrete;
using Dapper.Entities.Requests.UserRequest;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		readonly IGenericRepository<User> _userRepository;

		public UserController(IGenericRepository<User> userRepository)
		{
			_userRepository = userRepository;
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAll()
		{
			var values = await _userRepository.GetAllAsync();
			return Ok(values);
		}

		[HttpGet("GetUser/{id}")]
		public async Task<IActionResult> GetUserById(int id)
		{
			var value = await _userRepository.GetByIdAsync(id);
			return Ok(value);
		}

		[HttpPost("InsertUser")]
		public async Task<IActionResult> InsertUser(InsertUserRequest insertUserRequest)
		{
			//Create a new User entity from the request data (InsertUserRequst)
			var user = new User
			{
				Username = insertUserRequest.Username,
				Password = insertUserRequest.Password,
				Email = insertUserRequest.Email
			};

			await _userRepository.InsertAsync(user);
			return Ok("User inserted successfully.");
		}

		[HttpPut("UpdateUser")]
		public async Task<IActionResult> UpdateUser(UpdateUserRequest updateUserRequest)
		{
			// Create a User entity with updated data from the request (UpdateUserRequest)
			var user = new User
			{
				UserId = updateUserRequest.UserId,
				Username = updateUserRequest.Username,
				Password = updateUserRequest.Password,
				Email = updateUserRequest.Email,
				Status = updateUserRequest.Status
			};

			await _userRepository.UpdateAsync(user);
			return Ok("User updated successfully.");
		}

		[HttpDelete("DeleteUser/{id}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			await _userRepository.DeleteAsync(id);
			return Ok("User deleted successfully.");
		}
	}
}