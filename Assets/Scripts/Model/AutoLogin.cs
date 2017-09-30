using UnityEngine;
using ValueObject;

namespace Model
{
    /// <summary>
    /// 自動ログインモデル
    /// </summary>
    public class AutoLogin
    {
        /// <summary>
        /// ログイン名を保存するKey
        /// </summary>
        private const string LOGIN_NAME = "LoginName";

        /// <summary>
        /// 自動ログインするさいの名前
        /// </summary>
        private static string AutoLoginName = "";

        /// <summary>
        /// ユーザー名を保存する
        /// </summary>
        /// <param name="userName"></param>
        public static void SaveUserName(string userName)
        {
            if (CanAutoLogin()) return;

            PlayerPrefs.SetString(LOGIN_NAME, userName);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// 自動ログインできるか？
        /// </summary>
        /// <returns></returns>
        public static bool CanAutoLogin()
        {
            return LoadLoginName() != "";
        }

        /// <summary>
        /// PlayerPrefsに保存された名前があれば自動でログインする
        /// </summary>
        /// <returns></returns>
        public static void LoginByAutoName()
        {
            if(!CanAutoLogin()) return;
            
            Login.LoginByNCMB(new PlayerVO(LoadLoginName(), true));
        }

        /// <summary>
        /// 名前をロードする
        /// </summary>
        /// <returns></returns>
        private static string LoadLoginName()
        {
            if (AutoLoginName != "") return AutoLoginName;

            AutoLoginName = PlayerPrefs.GetString(LOGIN_NAME, null);
            return AutoLoginName;
        }
    }
}