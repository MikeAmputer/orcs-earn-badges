﻿using System.Text.RegularExpressions;

namespace Action;

public static class RegexExtensions
{
	public static string TryGetGroupValue(this Match match, int groupId, string fallbackValue = "")
	{
		if (match.Success)
		{
			return match.Groups[groupId].Value;
		}

		return fallbackValue;
	}
}
