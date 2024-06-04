using BusinessServices.Services;
using DomainModel.DTO.User;
using DomainModel.Models;
using Framework.Password;
using Microsoft.AspNetCore.Mvc;

namespace AdminPannel.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IRoleBusiness _roleBusiness;
        private readonly IGenderBusiness _genderBusiness;
        private readonly IAddressBusiness _addressBusiness;
        private readonly IPasswordHasher _passwordHasher;

        public UserController(IUserBusiness userBusiness, IRoleBusiness roleBusiness, IGenderBusiness genderBusiness, IAddressBusiness addressBusiness, IPasswordHasher passwordHasher)
        {
            _userBusiness = userBusiness;
            _roleBusiness = roleBusiness;
            _genderBusiness = genderBusiness;
            _addressBusiness = addressBusiness;
            _passwordHasher = passwordHasher;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UserProfile(int id)
        {
            var user = _userBusiness.Get(id);
            var roleAddEditModel = _roleBusiness.Get(user.RoleId);
            var genderAddEditModel = _genderBusiness.Get(user.GenderId);
            var gender = new Gender
            {
                GenderId = genderAddEditModel.GenderId,
                GenderName = genderAddEditModel.GenderName,
            };
            user.Gender = gender;
            var role = new Role
            {
                RoleId = roleAddEditModel.RoleId,
                RoleName = roleAddEditModel.RoleName
            };
            user.Role = role;
            return View(user);
        }
        [HttpGet]
        public IActionResult GetAllUser()
        {
            var user = _userBusiness.GetAll();
            foreach (var item in user)
            {
                var roleAddEditModel = _roleBusiness.Get(item.RoleId);
                var genderAddEditModel = _genderBusiness.Get(item.GenderId);
                var gender = new Gender
                {
                    GenderId = genderAddEditModel.GenderId,
                    GenderName = genderAddEditModel.GenderName,
                };
                item.Gender = gender;
                var role = new Role
                {
                    RoleId = roleAddEditModel.RoleId,
                    RoleName = roleAddEditModel.RoleName
                };
                item.Role = role;
            }

            return View(user);
        }
        [HttpDelete]
        public IActionResult DeleteUser(int userId)
        {
            var result = _userBusiness.Delete(userId);
            return Json(result);
        }
        [HttpGet]
        public IActionResult UpdateUserPage(int userId)
        {

            var result = _userBusiness.Get(userId);
            var userUpdate = new UserAddEditModel
            {
                UserName = result.UserName,
                Active = result.Active,
                AddDate = result.AddDate,
                BirthDay = result.BirthDay,
                Email = result.Email,
                FirstName = result.FirstName,
                GenderId = result.GenderId,
                LastName = result.LastName,
                Phone = result.Phone,
                RoleId = result.RoleId,
                UserId = result.UserId
            };
            return View(userUpdate);
        }
        //[HttpGet]
        //public IActionResult GetAllEmployee()
        //{
        //    var hg = new UserSearchModel
        //    {
                
        //    };
        //    var result = _userBusiness.Search();
        //    return View(userUpdate);
        //}
        [HttpPost]
        public IActionResult UpdateUser(UserAddEditModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _userBusiness.Update(model);
                return Json(result);
            }

            return Json(" اطلاعات مورد نیاز را وارد کنید ");
        }
        [HttpGet]
        public IActionResult AddNewUserPage()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddNewUser(UserAddEditModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != null)
                {
                    model.Password = _passwordHasher.Hash(model.Password);
                }
                var userAddResult = _userBusiness.Add(model);
                if (userAddResult.Success == false)
                {
                    return Json(userAddResult);
                }
                if (model.Address != null)
                {
                    model.Address.UserId = userAddResult.RecordId;
                    var addressResult = _addressBusiness.Add(model.Address);

                    if (addressResult.Success == false)
                    {
                        return Json(addressResult);
                    }
                }
                return Json(userAddResult);

            }
            return Json("  اطلاعات را وارد کنید ");

        }
    }
}
