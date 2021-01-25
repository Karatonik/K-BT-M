namespace WindowsyProjekt.Utils
{
    public class AppSettings
    {
        #region Account settings

        public const int AccountSuspensionDays = 60;

        #endregion

        #region RegularExpressionss

        public const string EmailExpression = @"^(([^<>()\[\]\\.,;:\s@""]+(\.[^<>()\[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";

        #endregion

        #region CORS Configuration

        public const string CorsConfigurationName = nameof(CorsConfigurationName);

        #endregion
    }
}
