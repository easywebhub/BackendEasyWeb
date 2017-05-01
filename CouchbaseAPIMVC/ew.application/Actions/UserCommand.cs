namespace kieuhoi.application.Actions
{
    public abstract class UserCommand: EAction
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IAccountMaganer _accountManager;
        private readonly ITicketManager _ticketManager;

        public UserCommand(EAccount account, EAction action)
        {
            this.Account = account;
            this.Action = action;
        }

        public EAccount Account;
        public EAction Action;
        public EHistory History;

        public abstract bool Process();
        
        public bool SaveHistory()
        {
            return true;
        }

        public bool CanProcess()
        {
            return true;
        }

        public bool ProcessSuccessed()
        {
            return true;
        }

        public bool ProcessFailed()
        {
            return true;
        }
    }
}
