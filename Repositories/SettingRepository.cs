using Aestus.API.Data;
using Aestus.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aestus.API.Repositories
{
    public class SettingRepository : RepositoryBase<AestusDBContext, Setting>, ISettingRepository
    {
        private readonly AestusDBContext context;
        public SettingRepository(AestusDBContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Setting>> GetAllSettingsAsync()
        {
            return await context.Settings
                .Include(q => q.SettingVersions)
                .ToListAsync();
        }

        public async Task<Setting?> GetSettingBySettingIdAsync(int id)
        {
            return await context.Settings.Include(q => q.SettingVersions).FirstOrDefaultAsync(q => q.SettingId == id);
        }

        public async Task<Setting?> CreateSettingAsync(Setting setting)
        {
            return await CreateAsync(setting);
        }

        public async Task UpdateSettingAsync(Setting setting)
        {
            await UpdateAsync(setting);
        }

        public async Task DeleteSettingAsync(Setting setting)
        {
            await DeleteAsync(setting);
        }
    }
}
