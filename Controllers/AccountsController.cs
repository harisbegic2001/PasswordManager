using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManager.DataAccess;
using AccountManager.DataAccess.Models;
using AccountManager.Models.AccountModels;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AccountsController : ControllerBase{
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public AccountsController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<ReadAccountModel>> GetAllAccounts(){
            var accountItem = _dataContext.Accounts.ToList();
            return Ok(_mapper.Map<IEnumerable<ReadAccountModel>>(accountItem));
            
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(Guid id){
            var accountItems = _dataContext.Accounts.ToList();
            var acc = _dataContext.Accounts.Find(id);
            if (!accountItems.Contains(acc)) {return NotFound();}
            else {
                _dataContext.Accounts.Remove(acc);
                _dataContext.SaveChanges();
                return Ok();
            }
        }
        //Šifru ne zaboraviti//Šifru ne zaboraviti//Šifru ne zaboraviti//Šifru ne zaboraviti//Šifru ne zaboraviti
        [HttpPost]
        public ActionResult <Account> CreateAccount(CreateAccountModel createAccountModel){
            var newAccount = new Account{
               AppName =  createAccountModel.AppName,
               AppUsername = createAccountModel.AppUsername,
               AppDescription = createAccountModel.AppDescription,
               AppPassword = createAccountModel.AppPassword
            };
            _dataContext.Add(newAccount);
            _dataContext.SaveChanges();
            return Ok(newAccount);
        }

        [HttpPatch("{id}")]
        public ActionResult AccountUpdate(Guid id, JsonPatchDocument<UpdateAccountModel> update ){
            var accountModelsplur = _dataContext.Accounts.ToList();
            
            var accountModel = _dataContext.Accounts.Find(id);
            
            if(!accountModelsplur.Contains(accountModel)) {return NotFound();}

            

            var accToPatch = _mapper.Map<UpdateAccountModel>(accountModel); // Ta je linija problematična
            
            update.ApplyTo(accToPatch, ModelState);
            

            if (!TryValidateModel(accToPatch))
            {
                return ValidationProblem(ModelState);
            }


            _mapper.Map(accToPatch, accountModel);

            _dataContext.Update(accountModel);

            _dataContext.SaveChanges();

            return NoContent();

        }//Šifru ne zaboraviti//Šifru ne zaboraviti//Šifru ne zaboraviti//Šifru ne zaboraviti//Šifru ne zaboraviti

    }
}