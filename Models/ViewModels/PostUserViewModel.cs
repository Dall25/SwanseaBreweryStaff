using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class PostUserViewModel
    {
        public PostUserViewModel()
        {

        }

        public User User { get; set; } = new User();
        public List<UserType> UserTypeList { get; set; } = new List<UserType>();    
        public List<UserSection> UserSectionList { get; set; } = new List<UserSection>();

    }
}
