namespace Golmodoth.Shared
{
    public interface ICharacter
    {
        int Id { get; set; }
        int UserId { get; set; }
        string Name { get; set; }
        string TotalXp { get; set; }
        ulong Silver { get; set; }
        ulong Gold { get; set; }
    }
}