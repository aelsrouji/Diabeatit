using System;
using System.Collections.Generic;

namespace Diabeatit.Models
{
    public partial class UserSetting
    {
        public long SettingId { get; set; }
        public long UserId { get; set; }
        public int SettingKey { get; set; }
        public string SettingValue { get; set; }
    }
}
