using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE_Editer
{
    public class Dungeon
    {
        static public List<Dungeon> data = new List<Dungeon>();

        public string 名前 = "";
        public string 説明 = "";

        public int ボス;
        public int ボスLv;
        public int ザコ1;
        public int ザコ2;
        public int ザコ3;
        public int ザコ4;
        public int ザコ5;
        public int ザコLv;

        public int ボス地図;
        public int 探索地図;

        public int 遺物1;
        public int 遺物2;
        public int 遺物3;
        public int 遺物4;
        public int 遺物5;

        public int 部屋数;
        public int ボス出現探索率;
        public int 地図A出現探索率;
        public int 地図B出現探索率;

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
            Eq.Set(form.textBoxダンジョン名前, ref 名前);
            Eq.Set(form.textBoxダンジョン説明, ref 説明);

            Eq.Set(form.comboBoxダンジョンボス, ref ボス);
            Eq.Set(form.trackbarダンジョンボスLv, ref ボスLv);
            Eq.Set(form.comboBoxダンジョンザコ1, ref ザコ1);
            Eq.Set(form.comboBoxダンジョンザコ2, ref ザコ2);
            Eq.Set(form.comboBoxダンジョンザコ3, ref ザコ3);
            Eq.Set(form.comboBoxダンジョンザコ4, ref ザコ4);
            Eq.Set(form.comboBoxダンジョンザコ5, ref ザコ5);
            Eq.Set(form.trackbarダンジョンザコLv, ref ザコLv);

            Eq.Set(form.trackbarダンジョンボス地図, ref ボス地図);
            Eq.Set(form.trackbarダンジョン探索地図A, ref 探索地図);

            Eq.Set(form.comboBoxダンジョン遺物1, ref 遺物1);
            Eq.Set(form.comboBoxダンジョン遺物2, ref 遺物2);
            Eq.Set(form.comboBoxダンジョン遺物3, ref 遺物3);
            Eq.Set(form.comboBoxダンジョン遺物4, ref 遺物4);
            Eq.Set(form.comboBoxダンジョン遺物5, ref 遺物5);

            Eq.Set(form.numダンジョン部屋数, ref 部屋数);
            Eq.Set(form.trackbarダンジョンボス地図, ref ボス出現探索率);
            Eq.Set(form.trackbarダンジョン地図発見A, ref 地図A出現探索率);
            Eq.Set(form.trackbarダンジョン地図発見B, ref 地図B出現探索率);

        }
        private void Save(StreamWriter sw_str, BinaryWriter bw_data)
        {
            //文字とそれ以外は別ファイルに保存
            sw_str.WriteLine(名前 + "," + 説明);

            RW.ReadWrite(bw_data, ref ボス);
            RW.ReadWrite(bw_data, ref ボスLv);
            RW.ReadWrite(bw_data, ref ザコ1);
            RW.ReadWrite(bw_data, ref ザコ2);
            RW.ReadWrite(bw_data, ref ザコ3);
            RW.ReadWrite(bw_data, ref ザコ4);
            RW.ReadWrite(bw_data, ref ザコ5);
            RW.ReadWrite(bw_data, ref ザコLv);

            RW.ReadWrite(bw_data, ref ボス地図);
            RW.ReadWrite(bw_data, ref 探索地図);

            RW.ReadWrite(bw_data, ref 遺物1);
            RW.ReadWrite(bw_data, ref 遺物2);
            RW.ReadWrite(bw_data, ref 遺物3);
            RW.ReadWrite(bw_data, ref 遺物4);
            RW.ReadWrite(bw_data, ref 遺物5);

            RW.ReadWrite(bw_data, ref 部屋数);
            RW.ReadWrite(bw_data, ref ボス出現探索率);
            RW.ReadWrite(bw_data, ref 地図A出現探索率);
            RW.ReadWrite(bw_data, ref 地図B出現探索率);
        }

        private void Load(StreamReader br_str, BinaryReader br_data)
        {
            var strS = br_str.ReadLine().Split(',');
            名前 = strS[0];
            説明 = strS[1];

            RW.ReadWrite(br_data, ref ボス);
            RW.ReadWrite(br_data, ref ボスLv);
            RW.ReadWrite(br_data, ref ザコ1);
            RW.ReadWrite(br_data, ref ザコ2);
            RW.ReadWrite(br_data, ref ザコ3);
            RW.ReadWrite(br_data, ref ザコ4);
            RW.ReadWrite(br_data, ref ザコ5);
            RW.ReadWrite(br_data, ref ザコLv);

            RW.ReadWrite(br_data, ref ボス地図);
            RW.ReadWrite(br_data, ref 探索地図);

            RW.ReadWrite(br_data, ref 遺物1);
            RW.ReadWrite(br_data, ref 遺物2);
            RW.ReadWrite(br_data, ref 遺物3);
            RW.ReadWrite(br_data, ref 遺物4);
            RW.ReadWrite(br_data, ref 遺物5);

            RW.ReadWrite(br_data, ref 部屋数);
            RW.ReadWrite(br_data, ref ボス出現探索率);
            RW.ReadWrite(br_data, ref 地図A出現探索率);
            RW.ReadWrite(br_data, ref 地図B出現探索率);
        }
        static public void Save(string fileName)
        {
            var sw = new StreamWriter(fileName + ".csv");
            var bw = new BinaryWriter(new StreamWriter(fileName + ".dat").BaseStream);

            //データ件数を保存した後データを保存

            bw.Write(data.Count());
            for (int i = 0; i < data.Count(); i++)
            {
                data[i].Save(sw, bw);
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
                data.Add(new Dungeon());
                data[i].Load(sr, br);
            }

            sr.Close();
            br.Close();
        }

        public Dungeon Clone()
        {
            return (Dungeon)this.MemberwiseClone();
        }

        static public void Insert(int index)
        {
            data.Insert(index, new Dungeon());
        }

        static public void Remove(int index)
        {
            data.RemoveAt(index);
        }
    }
}
