

using Security.Domain.DTO.User;
using Framework.BaseModel;

namespace Security.BussinessServiceContract.Services
{
    public interface IAccountBuss
    {
        OperationResult Login(Login login);
//OperationResult Register(User command);
        void LogoutUser();
        UserInfo GetAccountInfo();
        bool CheckIfUserHasaccess(CheckPermission per);
        //OperationResult Delete(long id);
        //OperationResult Activate(long id);

        //OperationResult ChangePassword(ChangePassword command);
        //OperationResult CreateVerificationCodeByMobile(string mobile);
        //OperationResult CreateVerificationCodeByEmail(string email);
        //OperationResult VerifyWithSms(string commandPhonenumber, long code);
        //OperationResult VerifyWithEmail(string commandEmail, long code);
    }
}
