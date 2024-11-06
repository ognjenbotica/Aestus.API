using AutoMapper;
using Aestus.API.Data;
using Aestus.API.Interfaces;
using Aestus.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aestus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingRepository settingRepository;
        private readonly IMapper mapper;
        private readonly ILogger<SettingController> logger;

        public SettingController(ISettingRepository settingRepository, IMapper mapper, ILogger<SettingController> logger)
        {
            this.settingRepository = settingRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SettingDto>>> GetAllSettings()
        {
            try
            {
                var settingList = await settingRepository.GetAllSettingsAsync();
                var settingDtos = mapper.Map<IEnumerable<SettingDto>>(settingList);
                return Ok(settingDtos);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(GetAllSettings)} action: {ex}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SettingDto>> GetSetting(int id)
        {
            try
            {
                var setting = await settingRepository.GetSettingBySettingIdAsync(id);
                if (setting == null)
                {
                    return NotFound();
                }
                var settingDto = mapper.Map<SettingDto>(setting);
                return Ok(settingDto);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(GetSetting)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<SettingDto>> CreateSetting(SettingDto settingDto)
        {
            try
            {
                var setting = mapper.Map<Setting>(settingDto);
                var newSetting = await settingRepository.CreateSettingAsync(setting);
                var newSettingDto = mapper.Map<SettingDto>(settingDto);
                return CreatedAtAction(nameof(CreateSetting), new { id = newSettingDto.SettingId }, newSettingDto);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(CreateSetting)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSetting(SettingDto settingDto)
        {
            try
            {
                var setting = mapper.Map<Setting>(settingDto);
                await settingRepository.UpdateSettingAsync(setting);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(UpdateSetting)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSetting(int id)
        {
            try
            {
                var setting = await settingRepository.GetSettingBySettingIdAsync(id);
                if (setting == null)
                {
                    return NotFound();
                }
                await settingRepository.DeleteSettingAsync(setting);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(DeleteSetting)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }  
}
