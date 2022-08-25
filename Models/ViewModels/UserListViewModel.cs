using Models.Constants;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class UserListViewModel
    {
        public UserListViewModel()
        {
            UserResults = new PagedResults<List<User>, ConstantStrings>(new List<User>(), new TableControls<ConstantStrings>(new Sorting<ConstantStrings>(new ConstantStrings().FIRST_NAME, "asc", new ConstantStrings()), new Paging()));
        } 
        
        public UserListViewModel(Sorting<ConstantStrings> sorting, Paging paging)
        {
            UserResults = new PagedResults<List<User>, ConstantStrings>(new List<User>(), new TableControls<ConstantStrings>(sorting, paging));
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? SelectedUserTypeId { get; set; }
        public int? SelectedUserSectionId { get; set; }
        public List<UserType> UserTypeList { get; set; } = new List<UserType>();
        public List<UserSection> UserSectionList { get; set; } = new List<UserSection>();
        public PagedResults<List<User>, ConstantStrings> UserResults { get; set; }


    }
}
