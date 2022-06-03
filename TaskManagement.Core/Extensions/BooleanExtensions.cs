﻿namespace TaskManagement.Core.Extensions
{
    public static class BooleanExtensions
    {

        /// <summary>
        /// Biến string thành kiểu bool
        /// </summary>
        /// <param name="s">Chuỗi cần convert</param>
        /// <returns>bool hoặc null nếu không convert được</returns>
        public static bool ToBool(this string s)
        {
            switch (s)
            {
                case "1":
                    return true;
                case "0":
                    return false;
                default:
                    bool.TryParse(s, out var i);
                    return i;
            }
        }
    }
}
