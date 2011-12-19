using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System.Web.Security;

namespace SPKTWeb.MembershipProvider
{
  public class MxhMembershipProvider : System.Web.Security.MembershipProvider
  {    

    #region Properties

    //
    // If false, exceptions are thrown to the caller. If true,
    // exceptions are written to the event log.
    //
    private bool pWriteExceptionsToEventLog;
    public bool WriteExceptionsToEventLog
    {
      get { return pWriteExceptionsToEventLog; }
      set { pWriteExceptionsToEventLog = value; }
    }

    // Auto unlock user time out
    private int pAutoUnLockTimeOut;
    public int AutoUnlockTimeOut
    {
      get { return pAutoUnLockTimeOut; }
      set { pAutoUnLockTimeOut = value; }
    }

    //
    // System.Web.Security.MembershipProvider properties.
    //
    private string pApplicationName;
    private bool pEnablePasswordReset;
    private bool pEnablePasswordRetrieval;
    private bool pRequiresQuestionAndAnswer;
    private bool pRequiresUniqueEmail;
    private int pMaxInvalidPasswordAttempts;
    private int pPasswordAttemptWindow;
    private MembershipPasswordFormat pPasswordFormat;

    public override string ApplicationName
    {
      get { return pApplicationName; }
      set { pApplicationName = value; }
    }

    public override bool EnablePasswordReset
    {
      get { return pEnablePasswordReset; }
    }

    public override bool EnablePasswordRetrieval
    {
      get { return pEnablePasswordRetrieval; }
    }

    public override bool RequiresQuestionAndAnswer
    {
      get { return pRequiresQuestionAndAnswer; }
    }

    public override bool RequiresUniqueEmail
    {
      get { return pRequiresUniqueEmail; }
    }

    public override int MaxInvalidPasswordAttempts
    {
      get { return pMaxInvalidPasswordAttempts; }
    }

    public override int PasswordAttemptWindow
    {
      get { return pPasswordAttemptWindow; }
    }

    public override MembershipPasswordFormat PasswordFormat
    {
      get { return pPasswordFormat; }
    }

    private int pMinRequiredNonAlphanumericCharacters;

    public override int MinRequiredNonAlphanumericCharacters
    {
      get { return pMinRequiredNonAlphanumericCharacters; }
    }

    private int pMinRequiredPasswordLength;

    public override int MinRequiredPasswordLength
    {
      get { return pMinRequiredPasswordLength; }
    }

    private string pPasswordStrengthRegularExpression;

    public override string PasswordStrengthRegularExpression
    {
      get { return pPasswordStrengthRegularExpression; }
    }

    #endregion


    #region Initialization

    //
    // System.Configuration.Provider.ProviderBase.Initialize Method
    //
    public override void Initialize(string name, NameValueCollection config)
    {
      //
      // Initialize values from web.config.
      //

      if (config == null)
        throw new ArgumentNullException("config");

      if (name == null || name.Length == 0)
        name = "SQLMembershipProvider";

      if (String.IsNullOrEmpty(config["description"]))
      {
        config.Remove("description");
        config.Add("description", "SQL Server Membership provider");
      }

      // Initialize the abstract base class.
      base.Initialize(name, config);

      pMaxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config["maxInvalidPasswordAttempts"], "10"));
      pPasswordAttemptWindow = Convert.ToInt32(GetConfigValue(config["passwordAttemptWindow"], "10"));
      pMinRequiredNonAlphanumericCharacters = Convert.ToInt32(GetConfigValue(config["minRequiredNonAlphanumericCharacters"], "0"));
      pMinRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config["minRequiredPasswordLength"], "8"));
      pPasswordStrengthRegularExpression = Convert.ToString(GetConfigValue(config["passwordStrengthRegularExpression"], ""));
      pEnablePasswordReset = Convert.ToBoolean(GetConfigValue(config["enablePasswordReset"], "true"));
      pEnablePasswordRetrieval = Convert.ToBoolean(GetConfigValue(config["enablePasswordRetrieval"], "true"));
      pRequiresQuestionAndAnswer = Convert.ToBoolean(GetConfigValue(config["requiresQuestionAndAnswer"], "false"));
      pRequiresUniqueEmail = Convert.ToBoolean(GetConfigValue(config["requiresUniqueEmail"], "false"));
      pWriteExceptionsToEventLog = Convert.ToBoolean(GetConfigValue(config["writeExceptionsToEventLog"], "false"));
      pAutoUnLockTimeOut = Convert.ToInt32(GetConfigValue(config["autoUnlockTimeOut"], "5"));

      string temp_format = config["passwordFormat"];
      if (temp_format == null)
      {
        temp_format = "Hashed";
      }

      switch (temp_format)
      {
        case "Hashed":
          pPasswordFormat = MembershipPasswordFormat.Hashed;
          break;
        case "Encrypted":
          pPasswordFormat = MembershipPasswordFormat.Encrypted;
          break;
        case "Clear":
          pPasswordFormat = MembershipPasswordFormat.Clear;
          break;
        default:
          throw new ProviderException("Password format not supported.");
      }

    }

    //
    // A helper function to retrieve config values from the configuration file.
    //
    private string GetConfigValue(string configValue, string defaultValue)
    {
      if (String.IsNullOrEmpty(configValue))
        return defaultValue;

      return configValue;
    }

    #endregion

    //TODO: 
    #region Implements Abstract Method

    public override bool ChangePassword(string username, string oldPassword, string newPassword)
    {
      throw new NotImplementedException();
    }

    public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
    {
      throw new NotImplementedException();
    }

    public override System.Web.Security.MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out System.Web.Security.MembershipCreateStatus status)
    {
      throw new NotImplementedException();
    }

    public override bool DeleteUser(string username, bool deleteAllRelatedData)
    {
      throw new NotImplementedException();
    }


    public override System.Web.Security.MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
      throw new NotImplementedException();
    }

    public override System.Web.Security.MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
      throw new NotImplementedException();
    }

    public override System.Web.Security.MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
    {
      throw new NotImplementedException();
    }

    public override int GetNumberOfUsersOnline()
    {
      throw new NotImplementedException();
    }

    public override string GetPassword(string username, string answer)
    {
      throw new NotImplementedException();
    }

    public override System.Web.Security.MembershipUser GetUser(string username, bool userIsOnline)
    {
      throw new NotImplementedException();
    }

    public override System.Web.Security.MembershipUser GetUser(object providerUserKey, bool userIsOnline)
    {
      throw new NotImplementedException();
    }

    public override string GetUserNameByEmail(string email)
    {
      throw new NotImplementedException();
    }



    public override string ResetPassword(string username, string answer)
    {
      throw new NotImplementedException();
    }

    public override bool UnlockUser(string userName)
    {
      throw new NotImplementedException();
    }

    public override void UpdateUser(System.Web.Security.MembershipUser user)
    {
      throw new NotImplementedException();
    }

    public override bool ValidateUser(string username, string password)
    {
      throw new NotImplementedException();
    }
    #endregion
  }
}