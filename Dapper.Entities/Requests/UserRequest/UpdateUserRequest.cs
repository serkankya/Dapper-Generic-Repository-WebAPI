namespace Dapper.Entities.Requests.UserRequest
{
	//Record type.
	public record UpdateUserRequest(int UserId, string Username, string Password, string Email, bool Status);
}
