using UnityEngine;

namespace PageSettings
{
    public abstract class PageSetting : ScriptableObject
    {
        [SerializeField]
        protected GameObject pagePrefab;

        private GameObject instance;

        public GameObject Instance
        {
            get { return instance ?? (instance = Instantiate(pagePrefab)); }
        }

        /// <summary>
        /// ページPrefabをインスタンス化します
        /// </summary>
        /// <param name="parent"></param>
        public void InstantiatePage(Transform parent)
        {
            instance = Instantiate(pagePrefab, parent);
            BindLoadModel();
        }

        /// <summary>
        /// ページを削除する
        /// </summary>
        public void DeletePage()
        {
            if (instance == null) return;

            Destroy(instance);
            instance = null;
        }

        /// <summary>
        /// 現在のPageのViewを取得します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetPageView<T>()
        {
            return Instance.GetComponent<T>();
        }

        /// <summary>
        /// 読み込んだモデルを遷移先ページに渡します。
        /// </summary>
        internal abstract void BindLoadModel();
    }
}