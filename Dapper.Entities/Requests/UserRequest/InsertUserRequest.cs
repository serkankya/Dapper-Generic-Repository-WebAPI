namespace Dapper.Entities.Requests.UserRequest
{
	//Record type.
	public record InsertUserRequest(string Username, string Password, string Email);
}
