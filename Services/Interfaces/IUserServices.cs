using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<UserListViewModel> BuildUserListViewModel(UserListViewModel viewModel);
        Task<UserListViewModel> BuildInitialUserListViewModel();
        Task<PostUserViewModel> BuildCreateUserViewModel(PostUserViewModel? viewModel = null);
        Task<ValidationResult> ValidateCreateUserViewModel(PostUserViewModel viewModel);
        Task<ActionResult> AddUser(User user);
        Task<PostUserViewModel> BuildEditUserViewModel(Guid userId, PostUserViewModel? viewModel = null);
        Task<ValidationResult> ValidateEditUserViewModel(PostUserViewModel viewModel);
        Task<ActionResult> EditUser(User user);
        Task<bool> DeleteUser(User user);
    }
}
