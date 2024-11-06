using AutoMapper;
using Aestus.API.Data;
using Aestus.API.Interfaces;
using Aestus.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aestus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingVersionController : ControllerBase
    {
        private readonly ISettingVersionRepository settingVersionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<SettingVersionController> logger;

        public SettingVersionController(ISettingVersionRepository settingVersionRepository, IMapper mapper, ILogger<SettingVersionController> logger)
        {
            this.settingVersionRepository = settingVersionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SettingDto>>> GetAllSettingVersions()
        {
            try
            {
                var settingVersionList = await settingVersionRepository.GetAllSettingVersionsAsync();
                var settingVersionDtos = mapper.Map<IEnumerable<SettingDto>>(settingVersionList);
                return Ok(settingVersionDtos);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(GetAllSettingVersions)} action: {ex}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SettingDto>> GetSettingVersion(int id)
        {
            try
            {
                var settingVersion = await settingVersionRepository.GetSettingVersionBySettingVersionIdAsync(id);
                if (settingVersion == null)
                {
                    return NotFound();
                }
                var settingVersionDto = mapper.Map<SettingVersionDto>(settingVersion);
                return Ok(settingVersionDto);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(GetSettingVersion)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<SettingDto>> CreateSettingVersion(SettingVersionDto settingVersionDto)
        {
            try
            {
                var settingVersion = mapper.Map<SettingVersion>(settingVersionDto);
                var newSettingVersion = await settingVersionRepository.CreateSettingVersionAsync(settingVersion);
                var newSettingVersionDto = mapper.Map<SettingVersionDto>(settingVersionDto);
                return CreatedAtAction(nameof(CreateSettingVersion), new { id = newSettingVersionDto.VersionId }, newSettingVersionDto);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(CreateSettingVersion)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("byParams")]
        public async Task<ActionResult<SettingDto>> GetSettingVersionByParams(SettingVersionRequest request)
        {
            try
            {
                var settingVersion = await settingVersionRepository.GetSettingVersionByParamsAsync(request);
                if (settingVersion == null)
                {
                    return NotFound();
                }
                var settingVersionDto = mapper.Map<SettingVersionDto>(settingVersion);
                return Ok(settingVersionDto);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(GetSettingVersionByParams)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSettingVersion(SettingVersionDto settingVersionDto)
        {
            try
            {
                var settingVersion = mapper.Map<SettingVersion>(settingVersionDto);
                await settingVersionRepository.UpdateSettingVersionAsync(settingVersion);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(UpdateSettingVersion)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSettingVersion(int id)
        {
            try
            {
                var setting = await settingVersionRepository.GetSettingVersionBySettingVersionIdAsync(id);
                if (setting == null)
                {
                    return NotFound();
                }
                await settingVersionRepository.DeleteSettingVersionAsync(setting);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(DeleteSettingVersion)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }  
}
