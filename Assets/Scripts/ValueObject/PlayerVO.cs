using NcmbAsObservables;
using NCMB;
using UniRx;

namespace ValueObject
{
    public class PlayerVO
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public bool IsSelf { get; private set; }

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

        public PlayerVO(string name, bool isSelf)
        {
            Name = name;
            Password = "fenya";
            IsSelf = isSelf;
        }
        
        public PlayerVO(string name, string password)
        {
            Name = name;
            Password = password;
            IsSelf = true;
        }
    }
}