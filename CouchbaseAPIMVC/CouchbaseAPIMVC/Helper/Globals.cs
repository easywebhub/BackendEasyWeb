﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CouchbaseAPIMVC.Helper
{
    public class Globals
    {
        public class StatusCode
        {
            public static class Success
            {
                public const string Code = "200";
                public const string Message = "Thành công!";
            }

            public static class InvalidData
            {
                public const string Code = "422";
                public const string Message = "Dữ liệu có lỗi!";
            }

            public static class BadRequest
            {
                public const int Code = 400;
                public const string Message = "Yêu cầu không hợp lệ!";
            }

            public static class NotFound
            {
                public const int Code = 404;
                public const string Message = "Yêu cầu không tìm thấy!";
            }

            public static class Error
            {
                public const string Code = "444";
                public const string Message = "Hệ thống gặp sự cố!";
            }

            public static class DataNotFound
            {
                public const string Code = "401";
                public const string Message = "Không tìm thấy dữ liệu!";
            }
            public static class DataConflict
            {
                public const string Code = "403";
                public const string Message = "Dữ liệu trùng!";
            }
        }

        public static object GetParameterNull(object val)
        {
            return val ?? DBNull.Value;
        }
        #region Function
        public static bool ValidateEmail(string email)
        {
            return Validate(email, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

        public static bool Validate(string text, string pattern)
        {
            Regex regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return regex.IsMatch(text);
        }
        #endregion
        public static class AccessLevel
        {
            public static List<string> CreateWebsite = new List<string>() { "creator", "dev" };
            
        }
    }
}