using NcmbAsObservables;
using NCMB;
using UniRx;

namespace ValueObject
{
    public class PlayerVO
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }

        /// <summary>
        /// NCMBUserオブジェクトを取得する
        /// </summary>
        /// <returns></returns>
        public NCMBUser CreateNcmbUser()
        {
            var user = new NCMBUser
            {
                UserName = UserName,
                Password = Password
            };

            return user;
        }

        public PlayerVO(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}