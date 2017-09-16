using UnityEngine;

namespace PageSettings
{
    public abstract class PageSetting : ScriptableObject
    {
        [SerializeField]
        protected GameObject pagePrefab;

        private GameObject pageInstance;

        public GameObject PageInstance
        {
            get { return pageInstance; }
        }

        /// <summary>
        /// ページPrefabをインスタンス化します
        /// </summary>
        /// <param name="parent"></param>
        public void InstantiatePage(Transform parent)
        {
            pageInstance = Instantiate(pagePrefab, parent);
        }

        /// <summary>
        /// 現在のPageのViewを取得します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetPageView<T>()
        {
            return pageInstance.GetComponent<T>();
        }

        /// <summary>
        /// 読み込んだモデルを遷移先ページに渡します。
        /// </summary>
        public abstract void BindLoadedModels();
    }
}