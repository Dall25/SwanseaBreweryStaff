using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class UserType
    {
        public UserType(int userTypeId, string name)

        {
            UserTypeId = userTypeId;
            Name = name;
        }

        public int UserTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

    }
    
}
