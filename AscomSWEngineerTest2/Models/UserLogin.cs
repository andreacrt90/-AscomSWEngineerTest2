using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AscomSWEngineerTest2.Models
{
    public class UserLogin
    {

        /// <summary>
        /// Username of the user
        /// </summary>
        [Required]
        public string? Username { get; set; }

        /// <summary>
        /// Password of the user
        /// </summary>
        [Required]
        public string? Password { get; set; }
    }
}
