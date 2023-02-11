using RandomCoffeeBot.dbController;

namespace RandomCoffeeBot;

public class Authorization
{
    public void CheckPassword(User user, string password, DbManager _dbContext)
    {
        //var user = _dbContext.GetUser(telegramId);

        if (user.Password == password)
        {
            user.IsAuthorized = true;
            user.Attempts = 0;
            _dbContext.UpdateUser(user);
        }
        else
        {
            user.Attempts += 1;
            _dbContext.UpdateUser(user);
            if (user.Attempts == 3)
            {
                user.IsAuthorized = false;
                _dbContext.UpdateUser(user);
            }
        }
    }
}