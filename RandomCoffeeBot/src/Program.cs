using RandomCoffeeBot.dbController;
using RandomCoffeeBot.dialogWindow;
using Telegram.Bot;
using Telegram.Bot.Types;
using User = RandomCoffeeBot.dbController.User;

namespace RandomCoffeeBot;

class Program
{
    static void Main(string[] args)
    {
        var botClient = new TelegramBotClient("5955887823:AAFVS_Y5I9bMlcjkvDrVLHRQyGEnS1k5EHA");

        var _dbContext = new DbManager();
        var auth = new Authorization();

        Console.WriteLine("Запуск программы");

        botClient.StartReceiving(
            HandleUpdateAsync,
            HandlePollingErrorAsync
        );

        async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            if (update.Message!.Text == "/start")
            {
                var chatId = update.Message.Chat.Id;

                var user = new User
                {
                    TelegramUserId = chatId
                };

                _dbContext.AddUser(user);

                await client.SendTextMessageAsync(chatId: chatId, DialogWindow.PasswordStep(),
                    cancellationToken: cancellationToken);
            }

            if (update.Message.Text != null && _dbContext.GetUser(update.Message.Chat.Id).IsAuthorized == null && update.Message!.Text != "/start")
            {
                var usersMessageText = update.Message.Text;

                var user = _dbContext.GetUser(update.Message.Chat.Id);

                if (user.IsAuthorized == null)
                {
                    auth.CheckPassword(user, usersMessageText, _dbContext);
                    if (user.IsAuthorized == null)
                    {
                        await client.SendTextMessageAsync(chatId: update.Message.Chat.Id,
                            DialogWindow.WrongPasswordStep(user.Attempts),
                            cancellationToken: cancellationToken);
                    }
                }
            }
            
            if (_dbContext.GetUser(update.Message.Chat.Id).IsAuthorized == true)
            {
                await client.SendTextMessageAsync(chatId: update.Message.Chat.Id, "Авторизация успешна",
                    cancellationToken: cancellationToken);
            }

            if (_dbContext.GetUser(update.Message.Chat.Id).IsAuthorized == false)
            {
                await client.SendTextMessageAsync(chatId: update.Message.Chat.Id, "Пользователь заблокирован",
                    cancellationToken: cancellationToken);
            }

        }

        async Task HandlePollingErrorAsync(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        Console.ReadLine();
    }
}