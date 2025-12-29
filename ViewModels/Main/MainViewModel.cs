using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfDIDemo.Options;
using WpfDIDemo.Services.LocalizationService;
using WpfDIDemo.ViewModels.Main;

namespace WpfDIDemo.ViewModels
{
    public partial class MainViewModel : ObservableObject , IMainViewModel
    {
        private readonly ILocalizationService _localizationService;
        private readonly IOptionsMonitor<LocalizationOption> _localizationOption;

        public MainViewModel(ILocalizationService localizationService, IOptionsMonitor<LocalizationOption> localizationOption)
        {
            _localizationService = localizationService;
            _localizationOption = localizationOption;
        }

        [ObservableProperty]
        private string _message;


        [RelayCommand]
        public void SayHello()
        {
            Message = "Hello";
        }

        [RelayCommand]
        public void ChangeLanguage()
        {
            var culture = _localizationOption.CurrentValue.DefaultCulture;
            string next = culture == "zh-CN" ? "en-US" : "zh-CN";
            _localizationService.SetCulture(next);
            UpdateDefaultCulture(next);
        }

        /// <summary>
        /// 待优化
        /// </summary>
        /// <param name="newCulture"></param>
        public void UpdateDefaultCulture(string newCulture)
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configurations", "Localization.json");

            string json = File.ReadAllText(configPath);
            var root = JObject.Parse(json);

            // 安全地设置嵌套值
            if (root["Localization"] == null)
                root["Localization"] = new JObject();

            root["Localization"]["DefaultCulture"] = newCulture;

            File.WriteAllText(configPath, root.ToString(Formatting.Indented));
        }
    }
}
