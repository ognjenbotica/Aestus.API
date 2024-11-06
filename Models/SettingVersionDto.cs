namespace Aestus.API.Models
{
    public class SettingVersionDto
    {
        public int VersionId { get; set; }

        public int? SettingId { get; set; }

        public decimal Value { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual SettingDto? Setting { get; set; }
    }
}
