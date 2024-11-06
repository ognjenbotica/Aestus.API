using Aestus.API.Data;

namespace Aestus.API.Interfaces
{
    public interface ISettingRepository
    {
        Task<List<Setting>> GetAllSettingsAsync();

        Task<Setting?> GetSettingBySettingIdAsync(int id);

        Task<Setting?> CreateSettingAsync(Setting setting);

        Task UpdateSettingAsync(Setting setting);

        Task DeleteSettingAsync(Setting setting);
    }
}