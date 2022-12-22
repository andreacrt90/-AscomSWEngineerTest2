using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AscomSWEngineerTest2.Models
{
    public class User
    {
        /// <summary>
        /// ID of the user
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Username of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password of the user
        /// </summary>
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
