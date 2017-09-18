using Model;
using Utility;
using ValueObject;

namespace Manager
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        private void Start()
        {
            var player = new PlayerVO("hogehoge", "fugafuga");
            NCMBManager.Instance.SignUp(player);
            
        }

        /// <summary>
        /// モデルを作成して表示する
        /// </summary>
        private void ProcessMainCat()
        {
            var model = new MainCat();
            model.Show();
        }
    }
}