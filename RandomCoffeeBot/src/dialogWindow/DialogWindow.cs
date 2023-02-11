namespace RandomCoffeeBot.dialogWindow;

public class DialogWindow
{
    private const string Password = @"Доступ к этому боту защищен паролем. Введите пароль для продолжения 🔐";

    private const string Welcome = 
        @"Привет!
        Я Random Coffee бот ☕

        👉 Раз в неделю я буду предлагать тебе онлайн-встречу с интересным человеком - другим пользователем Random Coffee бота.
        👉 Для участия нажми на кнопку ""АНКЕТА"", чтобы кратко описать свои увлечения и цели будущих встреч.
        
        Поехали 🚀";

    private const string WrongPassword = @"Введен некорректный пароль. Кол-во попыток: ";
    
    public static string WelcomeStep()
    {
        return Welcome;
    }

    public static string PasswordStep()
    {
        return Password;
    }

    public static string WrongPasswordStep(int count)
    {
        return WrongPassword.Insert(WrongPassword.Length, (3 - count).ToString());
    }
}