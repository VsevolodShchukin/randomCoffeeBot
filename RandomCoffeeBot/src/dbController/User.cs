namespace RandomCoffeeBot.dbController;

public partial class User
{
    public long Id { get; set; }

    public long TelegramUserId { get; set; }
    public string Password { get; set; }

    public int Attempts  { get; set; }

    public bool? IsAuthorized { get; set; }

    public string? Name { get; set; }

    public string? Specialization { get; set; }

    public string? Interests { get; set; }

    public string? Purpose { get; set; }
}
