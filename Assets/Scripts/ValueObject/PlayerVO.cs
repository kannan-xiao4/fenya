using NcmbAsObservables;
using NCMB;
using UniRx;

namespace ValueObject
{
    public class PlayerVO
    {
        public string Name { get; private set; }
        public string Password { get; private set; }

        /// <summary>
        /// NCMBUserオブジェクトを取得する
        /// </summary>
        /// <returns></returns>
        public NCMBUser CreateNcmbUser()
        {
            var user = new NCMBUser
            {
                UserName = Name,
                Password = Password
            };

            return user;
        }

        public PlayerVO(string name)
        {
            Name = name;
            Password = "fenya";
        }
        
        public PlayerVO(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}