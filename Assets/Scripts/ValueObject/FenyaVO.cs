using System;
using System.Collections.Generic;
using System.Linq;
using NCMB;
using UniRx;

namespace ValueObject
{
    /// <summary>
    /// Fenyの保持する数値のVO
    /// NCMBのオブジェクト,クエリへの作成も可能 -> 別のとこでやるべきことかも
    /// </summary>
    public class FenyaVO
    {
        private const string FENYA_CLASS_NAME = "Fenya";
        private const string EXPIRE_DATE = "ExpireDate";
        private const string REMAIN_HP = "HP";

        /// <summary>
        /// NCMBで使用するObjectId
        /// </summary>
        public string ObjectId { get; private set; }

        /// <summary>
        /// 残り時間
        /// </summary>
        public TimeSpan RemaiTimeSpan { get; private set; }

        /// <summary>
        /// 残りのHP
        /// </summary>
        public long RemainHP { get; private set; }

        /// <summary>
        /// 現在有効なFenyaを取得するNCMBクエリを作成する
        /// </summary>
        /// <returns></returns>
        public NCMBQuery<NCMBObject> CreateNcmbQuery()
        {
            var query = new NCMBQuery<NCMBObject>(FENYA_CLASS_NAME);
            query.WhereGreaterThan(EXPIRE_DATE, DateTime.Now);

            return query;
        }

        /// <summary>
        /// 現在の値からNCMBObjectを生成する
        /// </summary>
        /// <returns></returns>
        public NCMBObject CreateNcmbObject()
        {
            var obj = new NCMBObject(FENYA_CLASS_NAME) {ObjectId = ObjectId};
            obj[REMAIN_HP] = RemainHP;

            return obj;
        }

        /// <summary>
        /// リストからFenyaVOを更新する
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public void UpdateByNCMBList(List<NCMBObject> list)
        {
            var ncmbObject = list.Last(x => (DateTime) x[EXPIRE_DATE] > DateTime.Now);
            SetValue(ncmbObject);
        }

        /// <summary>
        /// VOを更新する
        /// </summary>
        /// <param name="ncmbObject"></param>
        private void SetValue(NCMBObject ncmbObject)
        {
            ObjectId = ncmbObject.ObjectId;
            RemaiTimeSpan = (DateTime) ncmbObject[EXPIRE_DATE] - DateTime.Now;
            RemainHP = (long)ncmbObject[REMAIN_HP];
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FenyaVO()
        {
        }

        /// <summary>
        /// NCMBOnjectから作成するコンストラクタ
        /// </summary>
        /// <param name="ncmbObject"></param>
        public FenyaVO(NCMBObject ncmbObject)
        {
            SetValue(ncmbObject);
        }

        /// <summary>
        /// 指定のObjectIdとHpから作成するコンストラクタ
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="remainHp"></param>
        public FenyaVO(string objectId, long remainHp)
        {
            ObjectId = objectId;
            RemainHP = remainHp;
        }
    }
}