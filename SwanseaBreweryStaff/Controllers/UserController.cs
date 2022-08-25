using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Constants;
using Models.Entities;
using Models.ViewModels;
using Services.Interfaces;
using SwanseaBreweryStaff.Extensions;

namespace SwanseaBreweryStaff.Controllers
{
    public class UserController : Controller
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, BreweryContext breweryContext, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        #region user search 

        public async Task<IActionResult> Index()
        {
            var userList = new UserListViewModel();
            try
            {
                userList = await _userService.BuildInitialUserListViewModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(userList);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserListViewModel viewModel)
        {
            var userList = await _userService.BuildUserListViewModel(viewModel);

            return View(userList);

        }

        public async Task<IActionResult> SortUserResultsTable(string sortColumn, string sortDirection, int currentPage)
        {
            Sorting<ConstantStrings> sorting = new Sorting<ConstantStrings>(sortColumn, sortDirection, new ConstantStrings());
            Paging paging = new Paging();
            paging.CurrentPage = currentPage;
            var viewModel = new UserListViewModel(sorting, paging);
            var userList = await _userService.BuildUserListViewModel(viewModel);
            return PartialView("_UserResults", userList.UserResults);

        }

        #endregion

        #region add user 
       
        public async Task<IActionResult> Create()
        {
            var viewModel = await _userService.BuildCreateUserViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostUserViewModel viewModel)
        {
            var result = await _userService.ValidateCreateUserViewModel(viewModel);
            if(!result.IsValid)
            {
                viewModel = await _userService.BuildCreateUserViewModel(viewModel);
                result.AddToModelState(this.ModelState);
                return View(viewModel);
            }
            await _userService.AddUser(viewModel.User);

            return Redirect("Index");
        }

        #endregion create user 
        #region edit user

        public async Task<IActionResult> Edit(Guid userId)
        {
            var viewModel = await _userService.BuildEditUserViewModel(userId);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostUserViewModel viewModel)
        {
            var result = await _userService.ValidateEditUserViewModel(viewModel);
            if(!result.IsValid)
            {
                viewModel = await _userService.BuildEditUserViewModel(viewModel.User.UserId, viewModel);
                result.AddToModelState(this.ModelState);
                return View(viewModel);
            }

            await _userService.EditUser(viewModel.User);
              return Redirect("Index");
        }
        #endregion edit user
        #region
        [HttpPost]
        public async Task<IActionResult> Delete(User user)
        {
            await _userService.DeleteUser(user);
            return Redirect("Index");
        }
        #endregion



    }
}
