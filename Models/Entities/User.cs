using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class User
    {


        public User(Guid userId, int userTypeId, int? userSectionId, string? firstName, string? lastName, string email)
        {
            UserId = userId;
            UserTypeId = userTypeId;
            UserSectionId = userSectionId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
           
        }
        public User()
        {

        }

        public Guid UserId { get; set; }
        public int UserTypeId { get; set; } 
        public int? UserSectionId { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }   

        public UserType UserType { get; set; }
        public UserSection? UserSection { get; set; }    
        

    }
}
