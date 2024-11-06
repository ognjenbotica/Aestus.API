using System.ComponentModel.DataAnnotations;

namespace Aestus.API.Models
{
    public class SettingVersionRequest
    {
        public DateTime? StartDate { get; set; }

        [Required]
        [AllowedValues("profit_tax", "sales_tax", "vat_rate")]
        public string? SettingName { get; set; }
    }
}
