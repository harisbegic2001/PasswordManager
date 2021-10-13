using System;

namespace AccountManager.Models.AccountModels
{
    public class ReadAccountModel
    {
        public Guid Id { get; set; }
        public string AppName { get; set; }
        public string AppUsername { get; set; }
        public string AppPassword { get; set; }
        public string AppDescription { get; set; }
    }
}