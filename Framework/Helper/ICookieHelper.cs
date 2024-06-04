namespace Framework.Helper
{
  public  interface ICookieHelper
  {
      bool WriteItemToCookie(string Key,string Value);
      string ReadItemFromCookie(string Key);
  }
}
