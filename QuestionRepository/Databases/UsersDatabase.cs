using Autoauto.Models;

namespace Avtotest.Databases;

public class UsersDatabase
{
    public List<User> Users { get; set; }

    public UsersDatabase(List<User> users)
    {
        Users = users;
    }

}