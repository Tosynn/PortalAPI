namespace PortalAPI.Entities.HeroesDTO
{
    public class HeroesDTO
    {
        public required string Name { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place {  get; set; } = string.Empty;


    }
}
