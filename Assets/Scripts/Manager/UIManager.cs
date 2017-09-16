using System.Collections.Generic;
using System.Linq;
using PageSettings;
using UnityEngine;
using Utility;

namespace Manager
{
    /// <summary>
    /// UIに関して管理するシングルトン
    /// </summary>
    public class UIManager : SingletonMonoBehaviour<UIManager>
    {
        [SerializeField]
        private Transform pageLayer;
        
        [SerializeField]
        private List<PageSetting> pageSettings;

        private PageSetting currentPageSetting;

        /// <summary>
        /// 指定のPageSettingを用いてPageを生成する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void InstancePage<T>() where T : PageSetting
        {
            currentPageSetting = GetPageSetting<T>();
            currentPageSetting.InstantiatePage(pageLayer);
        }
        
        /// <summary>
        /// PageのViewを返す
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetCurrentView<T>()
        {
            return currentPageSetting.GetPageView<T>();
        }
        
        /// <summary>
        /// 指定のPageSettingを取得する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private T GetPageSetting<T>() where T : PageSetting
        {
            return (T) pageSettings.First(setting => setting.GetType() == typeof(T));
        }
    }
}