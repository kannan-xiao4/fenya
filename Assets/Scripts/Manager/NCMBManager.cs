using System.Linq;
using DateTime = System.DateTime;
using TimeSpan = System.TimeSpan;
using NCMB;
using NcmbAsObservables;
using UniRx;
using Utility;
using ValueObject;

namespace Manager
{
    /// <summary>
    /// NCMBとの通信を行うクラス
    /// </summary>
    public class NCMBManager : SingletonMonoBehaviour<NCMBManager>
    {
        /// <summary>
        /// 最新の有効なFenya情報取得する
        /// </summary>
        /// <returns></returns>
        public IObservable<FenyaVO> FetchFenyaObject()
        {
            var fenyaVo = new FenyaVO();

            return NcmbQueryHelper<NCMBObject>
                .FindAsync(fenyaVo.CreateNcmbQuery())
                .Select(list =>
                {
                    fenyaVo.UpdateByNCMBList(list);
                    return fenyaVo;
                });
        }

        /// <summary>
        /// 受け取ったFenyaVOでサーバのFenyaを更新する
        /// </summary>
        /// <param name="fenyaVo"></param>
        /// <returns></returns>
        public IObservable<NCMBObject> PostFenyaHp(FenyaVO fenyaVo)
        {
            var fenyaObject = fenyaVo.CreateNcmbObject();

            return fenyaObject.SaveAsyncAsStream();
        }
    }
}