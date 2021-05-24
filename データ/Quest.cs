using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE_Editer
{
    public class Quest
    {
        static public List<Quest> data = new List<Quest>();

        public string 名前 = "";
        public string 説明 = "";

        public int 種類;
        public int 条件値;
        public int 開放フロア;
        public int 開放クエスト;

        public int 入手アクセサリー;
        public int 入手ゴールド;

        public bool 重要クエスト;
        public int 対象フロア;
        public int 目標日数;
        public int 獲得ポイント;

        public int 依頼人;
        public void Set(MainForm form)
        {
            SetGet(form, true);
        }

        //コントロールの数値を取得
        public void Get(MainForm form)
        {
            SetGet(form, false);
        }

        private void SetGet(MainForm form, bool isSet)
        {
            Eq.isSetMode = isSet;

            Eq.Set(form.textBoxクエスト名前, ref 名前);
            Eq.Set(form.textBoxクエスト説明, ref 説明);

            Eq.Set(form.comboBoxクエスト種類, ref 種類);
            Eq.Set(form.numクエスト条件値, ref 条件値);
            Eq.Set(form.numクエスト開放フロア, ref 開放フロア);
            Eq.Set(form.comboBox開放クエスト, ref 開放クエスト);

            Eq.Set(form.numクエストゴールド, ref 入手ゴールド);
            Eq.Set(form.comboBoxクエストアクセサリ, ref 入手アクセサリー);

            Eq.Set(form.checkBoxクエスト重要, ref 重要クエスト);
            Eq.Set(form.numクエスト対象フロア, ref 対象フロア);
            Eq.Set(form.numクエスト目標日数, ref 目標日数);
            Eq.Set(form.numクエスト獲得ポイント, ref 獲得ポイント);

            Eq.Set(form.numクエスト依頼人, ref 依頼人);
        }

        private void SaveData(StreamWriter sw_str, BinaryWriter bw_data)
        {
            //文字とそれ以外は別ファイルに保存
            sw_str.WriteLine(名前 + CV.区切りSave + 説明.Replace("\r\n",CV.改行Save));

            RW.ReadWrite(bw_data, ref 種類);
            RW.ReadWrite(bw_data, ref 条件値);
            RW.ReadWrite(bw_data, ref 開放フロア);
            RW.ReadWrite(bw_data, ref 開放クエスト);
            RW.ReadWrite(bw_data, ref 入手ゴールド);
            RW.ReadWrite(bw_data, ref 入手アクセサリー);

            RW.ReadWrite(bw_data, ref 重要クエスト);
            RW.ReadWrite(bw_data, ref 対象フロア);
            RW.ReadWrite(bw_data, ref 目標日数);
            RW.ReadWrite(bw_data, ref 獲得ポイント);

            RW.ReadWrite(bw_data, ref 依頼人);
        }

        private void LoadData(StreamReader br_str, BinaryReader br_data)
        {
            var strS = br_str.ReadLine().Split(CV.区切りLoad);
            名前 = strS[0];
            説明 = strS[1].Replace( CV.改行Load , "\r\n");

            RW.ReadWrite(br_data, ref 種類);
            RW.ReadWrite(br_data, ref 条件値);
            RW.ReadWrite(br_data, ref 開放フロア);
            RW.ReadWrite(br_data, ref 開放クエスト);
            RW.ReadWrite(br_data, ref 入手ゴールド);
            RW.ReadWrite(br_data, ref 入手アクセサリー);

            RW.ReadWrite(br_data, ref 重要クエスト);
            RW.ReadWrite(br_data, ref 対象フロア);
            RW.ReadWrite(br_data, ref 目標日数);
            RW.ReadWrite(br_data, ref 獲得ポイント);

            RW.ReadWrite(br_data, ref 依頼人);
        }

        static public void Save(string fileName)
        {
            var sw = new StreamWriter(fileName + ".csv");
            var bw = new BinaryWriter(new StreamWriter(fileName + ".dat").BaseStream);

            //データ件数を保存した後データを保存

            bw.Write(data.Count());
            for (int i = 0; i < data.Count(); i++)
            {
                data[i].SaveData(sw, bw);
            }

            sw.Close();
            bw.Close();
        }

        static public void Load(string fileName)
        {
            var sr = new StreamReader(fileName + ".csv");
            var br = new BinaryReader(new StreamReader(fileName + ".dat").BaseStream);

            int n = br.ReadInt32();

            for (int i = 0; i < n; i++)
            {
                data.Add(new Quest());
                data[i].LoadData(sr, br);
            }

            sr.Close();
            br.Close();
        }


        public Quest Clone()
        {
            return (Quest)this.MemberwiseClone();
        }

        static public void Insert(int index)
        {
            data.Insert(index, new Quest());
            InsertRemove(index, +1);
        }

        static public void Remove(int index)
        {
            data.RemoveAt(index);
            InsertRemove(index, -1);
        }

        static private void InsertRemove(int index, int num)
        {
            //クエスト 開放クエスト
            foreach (var it in Quest.data)
            {
                if (it.開放クエスト >= index) { it.開放クエスト += num; }
            }
        }

    }
}
