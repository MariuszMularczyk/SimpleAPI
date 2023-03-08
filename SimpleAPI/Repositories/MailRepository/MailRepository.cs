namespace SimpleAPI
{
    public class MailRepository : Repository<Mail, DatabaseContext>, IMailRepository
    {
        public MailRepository(DatabaseContext context) : base(context)
        { }

    }
}
