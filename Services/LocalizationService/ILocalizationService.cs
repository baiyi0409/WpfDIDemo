using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDIDemo.Services.LocalizationService
{
    public interface ILocalizationService
    {
        string this[string key] { get; }

        void SetCulture(string cultureName);

        event Action? LanguageChanged;
    }
}
