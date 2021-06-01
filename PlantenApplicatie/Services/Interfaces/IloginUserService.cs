using System.Runtime.CompilerServices;

namespace PlantenApplicatie.Services.Interfaces
{
    public interface IloginUserService
    {
        void LoginButton(string userNameInput, string passwordInput);
        void CancelButton();
        void RegisterButton();
    }
}