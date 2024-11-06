using Aestus.API.Data;
using Aestus.API.Models;

namespace Aestus.API.Interfaces
{
    public interface ISettingVersionRepository
    {
        Task<List<SettingVersion>> GetAllSettingVersionsAsync();
        Task<SettingVersion?> GetSettingVersionBySettingVersionIdAsync(int id);
        Task<SettingVersion?> CreateSettingVersionAsync(SettingVersion settingVersion);
        Task UpdateSettingVersionAsync(SettingVersion settingVersion);
        Task DeleteSettingVersionAsync(SettingVersion settingVersion);
        Task<SettingVersion?> GetSettingVersionByParamsAsync(SettingVersionRequest request);
    }
}