﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopHelpers
{
    public class ConfigurationHelper
	{

		const string SettingsHttpcontextkey = "HTTPCONTEXTKEY";
		const string SettingsConnectionString = "ConnectionString";
		
		public static string HttpContextKey { get { return ConfigurationManager.AppSettings[SettingsHttpcontextkey]; } }
		public static string ConnectionString { get { return ConfigurationManager.AppSettings[SettingsConnectionString]; } }

	}
}
