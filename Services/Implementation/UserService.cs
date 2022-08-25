using AutoMapper;
using Data;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Constants;
using Models.Entities;
using Models.ViewModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class UserService : BaseService, IUserService
    {
        private readonly IValidator<PostUserViewModel> _validator;
        private readonly IMapper _mapper;

        public UserService(BreweryContext brewerContext, IValidator<PostUserViewModel> validator, IMapper mapper) : base(brewerContext)
        {
            _validator = validator;
            _mapper = mapper;
        }

        #region user find and sort 

        public async Task<UserListViewModel> BuildInitialUserListViewModel()
        {
            var viewModel = new UserListViewModel();
            try
            {
                viewModel.UserTypeList = await _breweryContext.UserType.ToListAsync();
                viewModel.UserSectionList = await _breweryContext.UserSection.ToListAsync();

                var query = BuildUserResultsQuery();
                query = FilterUserResults(query, viewModel.FirstName, viewModel.LastName, viewModel.SelectedUserTypeId, viewModel.SelectedUserTypeId);

                viewModel.UserResults.TableControls.Paging = new Paging(await query.CountAsync());

                query = (IQueryable<User>)viewModel.UserResults.TableControls.Sorting.SortUserResults(viewModel.UserResults.TableControls.Sorting, viewModel.UserResults.TableControls.Paging, query);

                viewModel.UserResults.Results = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return viewModel;
        }

        public async Task<UserListViewModel> BuildUserListViewModel(UserListViewModel viewModel)
        {

            viewModel.UserTypeList = await _breweryContext.UserType.ToListAsync();
            viewModel.UserSectionList = await _breweryContext.UserSection.ToListAsync();
            if (viewModel.UserResults.TableControls.Sorting == null)
            {
                viewModel.UserResults.TableControls.Sorting = new Sorting<ConstantStrings>(new ConstantStrings().FIRST_NAME, "asc", new ConstantStrings());
            };

            var query = BuildUserResultsQuery();
            query = FilterUserResults(query, viewModel.FirstName, viewModel.LastName, viewModel.SelectedUserTypeId, viewModel.SelectedUserTypeId);

            viewModel.UserResults.TableControls.Paging = new Paging(await query.CountAsync(), viewModel.UserResults.TableControls.Paging.CurrentPage);

            query = (IQueryable<User>)viewModel.UserResults.TableControls.Sorting.SortUserResults(viewModel.UserResults.TableControls.Sorting, viewModel.UserResults.TableControls.Paging, query);

            viewModel.UserResults.Results = await query.ToListAsync();

            return viewModel;
        }

        #endregion

        #region create user 

        public async Task<PostUserViewModel> BuildCreateUserViewModel(PostUserViewModel? viewModel = null)
        {
            if (viewModel == null)
            {
                viewModel = new PostUserViewModel { User = new User() };
            }

            viewModel.UserTypeList = await _breweryContext.UserType.ToListAsync();
            viewModel.UserSectionList = await _breweryContext.UserSection.ToListAsync();

            return viewModel;
        }

        public async Task<ValidationResult> ValidateCreateUserViewModel(PostUserViewModel viewModel)
        {
            ValidationResult result = await _validator.ValidateAsync(viewModel);

            return result;
        }

        public async Task<ActionResult> AddUser(User user)
        {
            await _breweryContext.User.AddAsync(user);
            await _breweryContext.SaveChangesAsync();

            return new OkResult();
        }

        #endregion

        #region edit user

        public async Task<PostUserViewModel> BuildEditUserViewModel(Guid userId, PostUserViewModel? viewModel = null)
        {
            if (viewModel == null)
            {
                viewModel = new PostUserViewModel { User = new User() };
                viewModel.User = await _breweryContext.User.SingleAsync(a => a.UserId == userId);
            }

            viewModel.UserTypeList = await _breweryContext.UserType.ToListAsync();
            viewModel.UserSectionList = await _breweryContext.UserSection.ToListAsync();

            return viewModel;

        }

        public async Task<ValidationResult> ValidateEditUserViewModel(PostUserViewModel viewModel)
        {
            ValidationResult result = await _validator.ValidateAsync(viewModel);

            return result;
        }

        public async Task<ActionResult> EditUser(User user)
        {
            var userToEdit = await _breweryContext.User.SingleOrDefaultAsync(a => a.UserId == user.UserId);
            userToEdit = _mapper.Map(user, userToEdit);
            if (userToEdit != null)
            {
                _breweryContext.User.Update(userToEdit);
                await _breweryContext.SaveChangesAsync();
                return new OkResult();
            }

            return new NotFoundResult();
        }

        #region delete user

        public async Task<bool> DeleteUser(User user)
        {
            if (await _breweryContext.User.AnyAsync(a => a.UserId == user.UserId))
            {
                var userToDelete = await _breweryContext.User.SingleAsync(a => a.UserId == user.UserId);
                _breweryContext.User.Remove(userToDelete);
                await _breweryContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion

        #endregion
        #region sorting and paging for users

        private IQueryable<User> BuildUserResultsQuery()
        {
            return _breweryContext.User.Include(a => a.UserType).Include(a => a.UserSection).AsQueryable();
        }

        private IQueryable<User> FilterUserResults(IQueryable<User> query, string? firstName, string? lastName, int? userTypeId, int? userSectionId)
        {
            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(a => a.FirstName.Contains(firstName));
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                query = query.Where(a => a.LastName.Contains(lastName));
            }
            if (userTypeId != 0 && userTypeId != null)
            {
                query = query.Where(a => a.UserTypeId == userTypeId);
            }
            if (userSectionId != 0 && userSectionId != null)
            {
                query = query.Where(a => a.UserTypeId == userTypeId);
            }

            return query;
        }

        #endregion

    }
}




















