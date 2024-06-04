//installing package Microsoft.AspNetCore.Authentication

using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;

using DomainModel.DTO.User;
using DomainModel.Models;
using Framework.Password;

namespace Business.IMP
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAuthHelper _authHelper;
         private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;


        public AccountApplication(IAuthHelper authHelper, IAccountRepository accountRepository, IPasswordHasher passwordHasher)
        {
            _authHelper = authHelper;
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
        }

        public OperationResult Login(Login login)
        {
            var result = new OperationResult("Login");
            var u= _accountRepository.GetFullInfo(login.Username);
            if (u==null)
            {
                result.Failed(" این کاربر وجود ندارد ",null);
            }

            var (verified, needsUpgrade) = _passwordHasher.Check(u.Password, login.Password);
            if (!verified)
            {
                return result.Failed(" رمز عبور اشتباه است ",null);
            }

            var userInfo = _accountRepository.GetUserInfo(login.Username);
            

            _authHelper.Signin(userInfo);

            return result.Succeed(" ورود با موفقیت بود ",userInfo.UserId);
        }

        public OperationResult Register(User command)
        {
            return _accountRepository.RegisterNewUser(command);
        }

        public void LogoutUser()
        {
            _authHelper.SignOut();
        }



        public UserInfo GetAccountInfo()
        {
            return _authHelper.GetCurrentUserInfo();
        }



        public bool CheckIfUserHasAccess(CheckPermission per)
        {
            return _accountRepository.CheckIfUserHasAccess(per);
        }

        //public OperationResult Delete(long id)
        //{
        //    var result = new OperationResult("Account", "Delete");
        //    try
        //    {
        //        if (!_accountRepository.Exists(x => x.Id == id))
        //        {
        //            result.Message = ApplicationMessages.EntityNotExists;
        //            return result;
        //        }

        //        var account = _accountRepository.GetAccount(id);

        //        account.IsDeleted = true;
        //        _accountRepository.SaveChanges();
        //        result.Message = ApplicationMessages.OperationSuccess;
        //        result.Success = true;
        //        return result;
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception);
        //        result.Message = ApplicationMessages.SystemFailure;
        //        return result;
        //    }
        //}

        //public OperationResult Activate(long id)
        //{
        //    var result = new OperationResult("Account", "Delete");
        //    try
        //    {
        //        if (!_accountRepository.Exists(x => x.Id == id))
        //        {
        //            result.Message = ApplicationMessages.EntityNotExists;
        //            return result;
        //        }

        //        var account = _accountRepository.GetAccount(id);

        //        account.IsDeleted = false;
        //        _accountRepository.SaveChanges();
        //        result.Message = ApplicationMessages.OperationSuccess;
        //        result.Success = true;
        //        return result;
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception);
        //        result.Message = ApplicationMessages.SystemFailure;
        //        return result;
        //    }
        //}

        //public OperationResult ChangePassword(ChangePassword command)
        //{
        //    var result = new OperationResult("Account", "ChangePassword");
        //    try
        //    {
        //        if (command.NewPassword != command.RepeatNewPassword)
        //        {
        //            result.Message = ApplicationMessages.NotSamePassword;
        //            return result;
        //        }

        //        var hashedPassword = _passwordHasher.Hash(command.NewPassword);
        //        var account = _accountRepository.GetAccount(command.AccountId);
        //        account.Password = hashedPassword;
        //        _accountRepository.SaveChanges();
        //        result.Message = ApplicationMessages.OperationSuccess;
        //        result.Success = true;
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception);
        //        result.Message = ApplicationMessages.SystemFailure;
        //    }

        //    return result;
        //}

        //public OperationResult CreateVerificationCodeByMobile(string mobile)
        //{
        //    var result = new OperationResult("Accounts", "CreateVerificationCode");
        //    try
        //    {
        //        //long referenceRecordId;
        //        //var user = _userRepository.Get(x => x.UserPhoneNumber == mobile).FirstOrDefault();
        //        //if (user == null)
        //        //{
        //        //    var job = _jobRepository.Get(x => x.JobMobile1 == mobile || x.JobMobile2 == mobile)
        //        //        .FirstOrDefault();
        //        //    if (job == null)
        //        //    {
        //        //        result.Message = ApplicationMessages.UserMobileNotExists;
        //        //        return result;
        //        //    }

        //        //    referenceRecordId = job.JobId;
        //        //}
        //        //else
        //        //{
        //        //    referenceRecordId = user.UserId;
        //        //}

        //        //var random = new Random();
        //        //var code = random.Next(10000, 99999);
        //        //var forgetPasswordMessage = $"{_settingApplication.GetForgetPasswordText()} {code}";
        //        //_smsService.SendSms(forgetPasswordMessage, mobile);
        //        //var account = _accountRepository.GetAccountByReferenceRecord(referenceRecordId);
        //        //account.RefereshToken = code;
        //        //_accountRepository.SaveChanges();
        //        result.Message = ApplicationMessages.VerificationCodeSent;
        //        //result.RecordId = code;
        //        result.Success = true;
        //        return result;
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception);
        //        result.Message = ApplicationMessages.SystemFailure;
        //        return result;
        //    }
        //}

        //public OperationResult CreateVerificationCodeByEmail(string email)
        //{
        //    var result = new OperationResult("Accounts", "CreateVerificationCode");
        //    try
        //    {
        //        //long referenceRecordId;
        //        //var user = _userRepository.Get(x => x.UserEmail == email).FirstOrDefault();
        //        //if (user == null)
        //        //{
        //        //    var job = _jobRepository.Get(x => x.JobEmailAddress == email)
        //        //        .FirstOrDefault();
        //        //    if (job == null)
        //        //    {
        //        //        result.Message = ApplicationMessages.UserEmailNotExists;
        //        //        return result;
        //        //    }

        //        //    referenceRecordId = job.JobId;
        //        //}
        //        //else
        //        //{
        //        //    referenceRecordId = user.UserId;
        //        //}

        //        //var random = new Random();
        //        //var code = random.Next(10000, 99999);
        //        //_emailService.SendEmail("کد احراز هویت اُکاپیا", $"کد احراز هویت شما: {code}", email);
        //        //var account = _accountRepository.GetAccountByReferenceRecord(referenceRecordId);
        //        //account.RefereshToken = code;
        //        _accountRepository.SaveChanges();
        //        result.Message = ApplicationMessages.VerificationCodeSent;
        //        //result.RecordId = code;
        //        result.Success = true;
        //        return result;
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception);
        //        result.Message = ApplicationMessages.SystemFailure;
        //        return result;
        //    }
        //}

        //public OperationResult VerifyWithSms(string mobile, long code)
        //{
        //    var result = new OperationResult("Accounts", "VerifyWithSms");
        //    try
        //    {
        //        //long referenceRecordId;
        //        //var user = _userRepository.Get(x => x.UserPhoneNumber == mobile).FirstOrDefault();
        //        //if (user == null)
        //        //{
        //        //    var job = _jobRepository.Get(x => x.JobMobile1 == mobile || x.JobMobile2 == mobile)
        //        //        .FirstOrDefault();
        //        //    if (job == null)
        //        //    {
        //        //        result.Message = ApplicationMessages.UserMobileNotExists;
        //        //        return result;
        //        //    }

        //        //    referenceRecordId = job.JobId;
        //        //}
        //        //else
        //        //{
        //        //    referenceRecordId = user.UserId;
        //        //}

        //        //var account = _accountRepository.GetAccountByReferenceRecord(referenceRecordId);
        //        //if (account.RefereshToken != code)
        //        //{
        //        //    result.Message = ApplicationMessages.WrongVerificationCode;
        //        //    return result;
        //        //}

        //        //account.RefereshToken = 0;
        //        //_accountRepository.SaveChanges();
        //        result.Message = ApplicationMessages.OperationSuccess;
        //        //result.RecordId = account.Id;
        //        result.Success = true;
        //        return result;
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception);
        //        result.Message = ApplicationMessages.SystemFailure;
        //        return result;
        //    }
        //}

        ////public OperationResult VerifyWithEmail(string email, long code)
        //{
        //    var result = new OperationResult("Accounts", "VerifyWithEmail");
        //    try
        //    {
        //        //long referenceRecordId;
        //        //var user = _userRepository.Get(x => x.UserEmail == email).FirstOrDefault();
        //        //if (user == null)
        //        //{
        //        //    var job = _jobRepository.Get(x => x.JobMobile1 == email || x.JobMobile2 == email)
        //        //        .FirstOrDefault();
        //        //    if (job == null)
        //        //    {
        //        //        result.Message = ApplicationMessages.UserMobileNotExists;
        //        //        return result;
        //        //    }

        //        //    referenceRecordId = job.JobId;
        //        //}
        //        //else
        //        //{
        //        //    referenceRecordId = user.UserId;
        //        //}

        //        //var account = _accountRepository.GetAccountByReferenceRecord(referenceRecordId);
        //        //if (account.RefereshToken != code)
        //        //{
        //        //    result.Message = ApplicationMessages.WrongVerificationCode;
        //        //    return result;
        //        //}

        //        //account.RefereshToken = 0;
        //        _accountRepository.SaveChanges();
        //        result.Message = ApplicationMessages.OperationSuccess;
        //        //result.RecordId = account.Id;
        //        result.Success = true;
        //        return result;
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception);
        //        result.Message = ApplicationMessages.SystemFailure;
        //        return result;
        //    }
        //}
    }
}