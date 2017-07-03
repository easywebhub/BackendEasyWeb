using ew.core.Configurations;
using ew.core.Enums;
using ew.core.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application.Services
{
    public interface IConfigService
    {
        List<Setting> GetAllSettings();
        string GetValue(ConfigKeys key);
        T GetValue<T>(ConfigKeys key);
        string GetValue(string key);
    }

    public class ConfigService : IConfigService
    {
        private readonly ISettingRepository _settingRepository;

        public ConfigService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        private List<Setting> allSettings;
        public List<Setting> GetAllSettings()
        {
            if (allSettings == null) allSettings = _settingRepository.FindAll().ToList();
            return allSettings;
        }

        public string GetValue(string key)
        {
            try
            {
                var result = string.Empty;
                var setting = GetAllSettings().FirstOrDefault(x => x.CodeName == key); //_settingRepository.GetByKey(key); // 
                if (setting != null)
                {
                    result = setting.Value;
                }
                else
                {
                    try
                    {
                        result = ConfigurationManager.AppSettings[key];
                    }
                    catch (Exception ex)
                    {
                        //if (SystemMode == "Debug") throw ex;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                //_loggingService.Error(ex);
                //_loggingService.Error(ex.StackTrace);
                //_loggingService.Error("KEY: " + key);
            }
            return string.Empty;
        }

        public string GetValue(ConfigKeys key)
        {
            return GetValue(key.ToString());
        }

        public T GetValue<T>(ConfigKeys key)
        {
            try
            {
                return (T)Convert.ChangeType(GetValue(key), typeof(T));
            }
            catch (Exception ex)
            {
                //if (SystemMode == "Debug") throw;
                return default(T);
            }
        }
    }
}
