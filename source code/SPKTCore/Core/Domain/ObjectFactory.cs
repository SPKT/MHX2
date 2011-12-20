using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Impl;

namespace SPKTCore.Core.Domain
{
  
  public class ObjectFactory 
  {
    static Dictionary<String, String> tableType;
    static ObjectFactory()
    {
      //TODO: Sửa lại hàm này để Đọc thông tin từ metadata để khởi tạo dictionary
      tableType = new Dictionary<string, string>();
      //add ( "Tên interface cha", "Tên kiểu class con sẽ khởi tạo");
      tableType.Add(typeof(IAccountRepository).FullName, typeof(AccountRepository).FullName);

      tableType.Add(typeof(IAlertRepository).FullName, typeof(AlertRepository).FullName);

      tableType.Add(typeof(IBlogRepository).FullName, typeof(BlogRepository).FullName);
      tableType.Add(typeof(IBoardCategoryRepository).FullName, typeof(BlogRepository).FullName);
      tableType.Add(typeof(IBoardForumRepository).FullName, typeof(BoardForumRepository).FullName);
      tableType.Add(typeof(IBoardPostRepository).FullName, typeof(BoardPostRepository).FullName);

      tableType.Add(typeof(ICommentRepository).FullName, typeof(CommentRepository).FullName);

      tableType.Add(typeof(IContentFilterRepository).FullName, typeof(ContentFilterRepository).FullName);

      tableType.Add(typeof(IFileRepository).FullName, typeof(FileRepository).FullName);
      tableType.Add(typeof(IFileSystemFolderRepository).FullName, typeof(FileSystemFolderRepository).FullName);
      tableType.Add(typeof(IFolderRepository).FullName, typeof(FolderRepository).FullName);

      tableType.Add(typeof(IFriendInvitationRepository).FullName, typeof(FriendInvitationRepository).FullName);
      tableType.Add(typeof(IFriendRepository).FullName, typeof(FriendRepository).FullName);

      tableType.Add(typeof(IGroupForumRepository).FullName, typeof(GroupForumRepository).FullName);
      tableType.Add(typeof(IGroupMemberRepository).FullName, typeof(GroupMemberRepository).FullName);
      tableType.Add(typeof(IGroupRepository).FullName, typeof(GroupRepository).FullName);
      tableType.Add(typeof(IGroupToGroupTypeRepository).FullName, typeof(GroupToGroupTypeRepository).FullName);
      tableType.Add(typeof(IGroupTypeRepository).FullName, typeof(GroupTypeRepository).FullName);

      tableType.Add(typeof(ILevelOfExperienceRepository).FullName, typeof(LevelOfExperienceRepository).FullName);

      tableType.Add(typeof(IMessageFolderRepository).FullName, typeof(MessageFolderRepository).FullName);
      tableType.Add(typeof(IMessageRecipientRepository).FullName, typeof(MessageRecipientRepository).FullName);
      tableType.Add(typeof(IMessageRepository).FullName, typeof(MessageRepository).FullName);

      tableType.Add(typeof(INotificationRepository).FullName, typeof(NotificationRepository).FullName);

      tableType.Add(typeof(IParameterIntRepository).FullName, typeof(ParameterIntRepository).FullName);

      tableType.Add(typeof(IPermissionRepository).FullName, typeof(PermissionRepository).FullName);
      tableType.Add(typeof(IPrivacyRepository).FullName, typeof(PrivacyRepository).FullName);
      tableType.Add(typeof(IProfileAttributeRepository).FullName, typeof(ProfileAttributeRepository).FullName);
      tableType.Add(typeof(IProfileRepository).FullName, typeof(ProfileRepository).FullName);
      tableType.Add(typeof(IStatusUpdateRepository).FullName, typeof(StatusUpdateRepository).FullName);
       //Service
      tableType.Add(typeof(IAccountService).FullName, typeof(AccountService).FullName);
      tableType.Add(typeof(IAlertService).FullName, typeof(AlertService).FullName);
      tableType.Add(typeof(IBoardService).FullName, typeof(BoardService).FullName);
      tableType.Add(typeof(ICache).FullName, typeof(Cache).FullName);
      tableType.Add(typeof(ICaptcha).FullName, typeof(Cache).FullName);
      tableType.Add(typeof(IContentFilterService).FullName, typeof(ContentFilterService).FullName);
      tableType.Add(typeof(IConfiguration).FullName, typeof(Configuration).FullName);
      tableType.Add(typeof(IEmail).FullName, typeof(Email).FullName);
      tableType.Add(typeof(IFileService).FullName, typeof(FileService).FullName);
      tableType.Add(typeof(IFriendService).FullName, typeof(FriendService).FullName);
      tableType.Add(typeof(IMessageService).FullName, typeof(MessageService).FullName);
      tableType.Add(typeof(IParameterIntService).FullName, typeof(ParameterIntService).FullName);
      tableType.Add(typeof(NotificationService).FullName, typeof(NotificationService).FullName);
      tableType.Add(typeof(PrivacyService).FullName, typeof(PrivacyService).FullName);
      tableType.Add(typeof(IGroupService).FullName, typeof(GroupService).FullName);
      tableType.Add(typeof(IProfileAttributeService).FullName, typeof(ProfileAttributeService).FullName);
      tableType.Add(typeof(IProfileService).FullName, typeof(ProfileService).FullName);
      tableType.Add(typeof(IRedirector).FullName, typeof(Redirector).FullName);
      tableType.Add(typeof(IStatusUpdateService).FullName, typeof(StatusUpdateService).FullName);
      tableType.Add(typeof(IUserSession).FullName, typeof(UserSession).FullName);
      tableType.Add(typeof(IWebContext).FullName, typeof(WebContext).FullName);
      tableType.Add(typeof(IForumPermissionService).FullName, typeof(ForumPermissionService).FullName);
      tableType.Add("ConsoleApplication1.IView", "ConsoleApplication1.ChildView");

    }
    static string GetInstanceTypeName(String parentType)
    {
      if (tableType.ContainsKey(parentType))
        return tableType[parentType];
      return null;
    }
    public static T GetInstance<T>()
    {
      Type type = typeof(T);
      String instanceTypeName = "";
      if (type.IsInterface || type.IsAbstract)
      {
        String name = type.FullName;
        instanceTypeName = GetInstanceTypeName(name);
        if (instanceTypeName == null)
          throw new Exception("Không tìm thấy lớp con của " + name);
      }
      else
        instanceTypeName = type.FullName;
      Type typeChild = null;
      try
      {
        typeChild = Type.GetType(instanceTypeName);
      }
      catch (Exception ex)
      {
        throw new Exception("Không tạo được type: " + instanceTypeName, ex);
      }
      try
      {
        ConstructorInfo constructorInfo = typeChild.GetConstructor(Type.EmptyTypes);
        return (T)constructorInfo.Invoke(null);
      }
      catch (Exception ex)
      {
        throw new Exception("Không gọi được Constructor mặc định của type: " + instanceTypeName, ex);
      }
    }
  }
}
