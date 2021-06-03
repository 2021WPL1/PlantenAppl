using System.Runtime.CompilerServices;

namespace PlantenApplicatie.Services.Interfaces
{/*written by kenny*/
    public interface IloginUserService
    {
        void LoginButton(string userNameInput, string passwordInput);
        void CancelButton();
        void RegisterButtonView();
        void RegisterButton(string vivesNrInput, string lastNameInput,
            string firstNameInput, string emailAdresInput,
            string passwordInput, string passwordRepeatInput, string rolInput);

    }
}