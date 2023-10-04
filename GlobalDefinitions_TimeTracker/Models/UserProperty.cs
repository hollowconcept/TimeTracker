using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDefinitions_TimeTracker.Models
{
    public class UserProperty
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Department")]
        public long DepartmentId { get; set; }

        public List<UserRoleProperty> ListRoles { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Maximal 100 Zeichen sind erlaubt !")]
        public string UserName { get; set; }

        public string FullUserName
        {
            get
            {
                if (string.IsNullOrEmpty(UserName))
                    return string.Empty;

                var names = UserName.Split('.');
                if (names.Length != 2)
                    return UserName;

                string firstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(names[0].ToLower());
                string lastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(names[1].ToLower());

                return $"{firstName} {lastName}";
            }
        }

        [Required]
        [MaxLength(50, ErrorMessage = "Maximal 50 Zeichen sind erlaubt !")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Maximal 50 Zeichen sind erlaubt !")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Ungültige E-Mail-Adresse.")]
        public string EMailAddress { get; set; }

        [MaxLength(100, ErrorMessage = "Maximal 100 Zeichen sind erlaubt !")]
        public string ManagerName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastLogin { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        public UserProperty()
        {
            ListRoles = new List<UserRoleProperty>();
        }
    }
}
