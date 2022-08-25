using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class UserSection
    {
        public UserSection(int userSectionId, string name)

        {
            UserSectionId = userSectionId;
            Name = name;
        }

        public int UserSectionId { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

    }
        
}
