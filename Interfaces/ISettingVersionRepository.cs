using Aestus.API.Data;

namespace Aestus.API.Interfaces
{
    public interface ISettingVersionRepository
    {
        Task<List<SettingVersion>> GetAllSettingVersionsAsync();
        Task<SettingVersion?> GetSettingVersionBySettingVersionIdAsync(int id);
        Task<SettingVersion?> CreateSettingVersionAsync(SettingVersion settingVersion);
        Task UpdateSettingVersionAsync(SettingVersion settingVersion);
        Task DeleteSettingVersionAsync(SettingVersion settingVersion);
    }
}