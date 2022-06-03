namespace TaskManagement.Core.Common;

public class AppConstants
{
    //public const string DataTypes = "DataTypes";
  
   




    public class DateTimeFormat
    {
        public const string DateTimeIsoString = "yyyy-MM-dd'T'HH:mm:ss.fffZ";
        public const string DateTimeLocalString = "yyyy-MM-dd HH:mm:ss.fff";
        public const string DateString = "dd/MM/yyyy";
        public const string DateFormatString = "yyyy-MM-dd";
        public const string TimeString = "HH:mm";
        public const string DateTimeString = "yyyy-MM-dd'T'HH:mm:ss";
        public const string DateTimeFormatString = "dd-MM-yyyy";
    }

    public class Platform
    {
        public const string SupportedPlatformWeb = "web";
        public const string SupportedPlatformiOS = "ios";
        public const string SupportedPlatformAndroid = "android";
        public static string[] SupportedPlatforms = { SupportedPlatformWeb, SupportedPlatformiOS, SupportedPlatformAndroid };
    }


    public class RegularExpression
    {
        public const string Password = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W]).{6,}$";
        public const string PhoneNumber = @"^[+0-9]{1}[0-9]+$";
        public const string Email = @"^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$";
        public const string NotSpecialCharacter = @"^[a-zA-Z0-9]*$";
        public const string NotExistSpecialCharacter = @"^[a-zA-Z0-9-]*$";
        public const string NumberCharacter = @"^[0-9]*$";
    }

    public class Status
    {
        public const int IsActive = 1;
        public const int UnActive = 2;
    }

}
