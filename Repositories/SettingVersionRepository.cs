using Aestus.API.Data;
using Aestus.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aestus.API.Repositories
{
    public class SettingVersionRepository : RepositoryBase<AestusDBContext, SettingVersion>, ISettingVersionRepository
    {
        private readonly AestusDBContext context;
        public SettingVersionRepository(AestusDBContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<SettingVersion>> GetAllSettingVersionsAsync()
        {
            return await context.SettingVersions
                .Include(q => q.Setting)
                .ToListAsync();
        }

        public async Task<SettingVersion?> GetSettingVersionBySettingVersionIdAsync(int id)
        {
            return await context.SettingVersions.Include(q => q.Setting).FirstOrDefaultAsync(q => q.VersionId == id);
        }

        public async Task<SettingVersion?> CreateSettingVersionAsync(SettingVersion settingVersion)
        {
            return await CreateAsync(settingVersion);
        }

        public async Task UpdateSettingVersionAsync(SettingVersion settingVersion)
        {
            await UpdateAsync(settingVersion);
        }

        public async Task DeleteSettingVersionAsync(SettingVersion settingVersion)
        {
            await DeleteAsync(settingVersion);
        }
    }
}
