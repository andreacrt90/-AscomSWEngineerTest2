using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AscomSWEngineerTest2.Models
{
    public class Patient
    {

        /// <summary>
        /// ID of the patient
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Family name of the patient
        /// </summary>
        public string FamilyName { get; set; }

        /// <summary>
        /// Given name of the patient
        /// </summary>
        public string GivenName { get; set; }

        /// <summary>
        /// Datetime of last selection by users
        /// </summary>
        public DateTime? LastSelectedDate { get; set; }

        public Patient(int id, string familyName, string givenName)
        {
            Id = id;
            FamilyName = familyName;
            GivenName = givenName;
        }
    }
}
