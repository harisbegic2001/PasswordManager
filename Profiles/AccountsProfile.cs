using AccountManager.DataAccess.Models;
using AccountManager.Models.AccountModels;
using AutoMapper;

namespace AccountManager.Profiles
{
    public class AccountsProfile : Profile
    {
        public AccountsProfile()
        {
            CreateMap<Account, ReadAccountModel>();
            CreateMap<CreateAccountModel, Account>();
            CreateMap<UpdateAccountModel, Account>();
            CreateMap<Account, UpdateAccountModel>();
        }
    }
}