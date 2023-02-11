namespace RandomCoffeeBot.dbController;

public class DbManager
{
    private readonly RandomCoffeeContext _dbContext;

    public DbManager()
    {
        _dbContext = new RandomCoffeeContext();
    }

    public void AddUser(User user)
    {
        _dbContext.Users!.Add(user);
        _dbContext.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        _dbContext.Users!.Update(user);
        _dbContext.SaveChanges();

    }

    public User GetUser(long telegramUserId)
    {
        return _dbContext.Users.FirstOrDefault(u => u.TelegramUserId == telegramUserId);
    }
}