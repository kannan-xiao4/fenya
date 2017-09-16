using Model;
using Utility;

namespace Manager
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        private void Start()
        {
            ProcessMainCat();
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