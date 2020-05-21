namespace backend.Models
{
    public class User
    {
    public long Id { get; set; }
    public string Name { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    }
}