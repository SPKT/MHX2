using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

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
      tableType.Add("ConsoleApplication1.IRepository", "ConsoleApplication1.Child");
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
