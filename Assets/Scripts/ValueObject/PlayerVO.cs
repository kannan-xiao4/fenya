using NCMB;

namespace ValueObject
{
    /// <summary>
    /// プレイヤー情報を扱うVO
    /// </summary>
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

        /// <summary>
        /// 名前と自分かどうかを指定して作成
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isSelf"></param>
        public PlayerVO(string name, bool isSelf)
        {
            Name = name;
            Password = "fenya";
            IsSelf = isSelf;
        }

        /// <summary>
        /// プレイヤー名とパスワードからVO作成
        /// これがわかってるのは自分だけなのでIsSelf = true
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        public PlayerVO(string name, string password)
        {
            Name = name;
            Password = password;
            IsSelf = true;
        }

        public override string ToString()
        {
            return Name;
        } 

        public override bool Equals(object obj)
        {
            var p = obj as PlayerVO;
            if (p == null)
                return false;
            return Name == p.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}