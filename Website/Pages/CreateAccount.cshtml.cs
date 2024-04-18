using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheFlyingSaucer.Data.DataDelegates;


namespace Website.Pages
{
    public class CreateAccountModel : PageModel
    {
        public void OnGet(string email)
        {
            Submit(email);
        }

        /// <summary>
        /// This will send the account information to SQL for creating a new accound
        /// </summary>
        /// <param name="email"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        public void Submit(string email)
        {
            //send this information to the create account table, FIXME what else
            CreateUserDataDelegate n = new CreateUserDataDelegate(email);
        }

    }
}
