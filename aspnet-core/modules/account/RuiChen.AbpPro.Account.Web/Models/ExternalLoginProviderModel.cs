﻿using System;

namespace RuiChen.AbpPro.Account.Web.Models;

public class ExternalLoginProviderModel
{
    public Type ComponentType { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string AuthenticationScheme { get; set; }
}
