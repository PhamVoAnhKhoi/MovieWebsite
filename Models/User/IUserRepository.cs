using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWebsite.Models
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(long id);
        Task AddUserAsync(User user );
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(long? id);
    }
}
