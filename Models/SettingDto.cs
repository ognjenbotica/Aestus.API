namespace Aestus.API.Models
{
    public class SettingDto
    {
        public int SettingId { get; set; }

        public string? SettingName { get; set; }

        public virtual ICollection<SettingVersionDto> SettingVersions { get; set; } = new List<SettingVersionDto>();
    }
}
