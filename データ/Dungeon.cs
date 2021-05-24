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

        public int[] ボス = new int[6];
        public int[] ボスLv = new int[6];
        public int[] ザコ = new int[6];
        public int[] ザコLv = new int[6];

        public int ボス地図;
        public int 探索地図A;
        public int 探索地図B;

        public int[] 遺物 = new int[6];


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

            Eq.Set(form.comboBoxダンジョンボス1, ref ボス[0]);
            Eq.Set(form.comboBoxダンジョンボス2, ref ボス[1]);
            Eq.Set(form.comboBoxダンジョンボス3, ref ボス[2]);
            Eq.Set(form.comboBoxダンジョンボス4, ref ボス[3]);
            Eq.Set(form.comboBoxダンジョンボス5, ref ボス[4]);
            Eq.Set(form.comboBoxダンジョンボス6, ref ボス[5]);

            Eq.Set(form.trackbarダンジョンボスLv1, ref ボスLv[0]);
            Eq.Set(form.trackbarダンジョンボスLv2, ref ボスLv[1]);
            Eq.Set(form.trackbarダンジョンボスLv3, ref ボスLv[2]);
            Eq.Set(form.trackbarダンジョンボスLv4, ref ボスLv[3]);
            Eq.Set(form.trackbarダンジョンボスLv5, ref ボスLv[4]);
            Eq.Set(form.trackbarダンジョンボスLv6, ref ボスLv[5]);

            Eq.Set(form.comboBoxダンジョンザコ1, ref ザコ[0]);
            Eq.Set(form.comboBoxダンジョンザコ2, ref ザコ[1]);
            Eq.Set(form.comboBoxダンジョンザコ3, ref ザコ[2]);
            Eq.Set(form.comboBoxダンジョンザコ4, ref ザコ[3]);
            Eq.Set(form.comboBoxダンジョンザコ5, ref ザコ[4]);
            Eq.Set(form.comboBoxダンジョンザコ6, ref ザコ[5]);

            Eq.Set(form.trackbarダンジョンザコLv1, ref ザコLv[0]);
            Eq.Set(form.trackbarダンジョンザコLv2, ref ザコLv[1]);
            Eq.Set(form.trackbarダンジョンザコLv3, ref ザコLv[2]);
            Eq.Set(form.trackbarダンジョンザコLv4, ref ザコLv[3]);
            Eq.Set(form.trackbarダンジョンザコLv5, ref ザコLv[4]);
            Eq.Set(form.trackbarダンジョンザコLv6, ref ザコLv[5]);

            Eq.Set(form.trackbarダンジョンボス地図, ref ボス地図);
            Eq.Set(form.trackbarダンジョン探索地図A, ref 探索地図A);
            Eq.Set(form.trackbarダンジョン探索地図B, ref 探索地図B);

            Eq.Set(form.comboBoxダンジョン遺物1, ref 遺物[0]);
            Eq.Set(form.comboBoxダンジョン遺物2, ref 遺物[1]);
            Eq.Set(form.comboBoxダンジョン遺物3, ref 遺物[2]);
            Eq.Set(form.comboBoxダンジョン遺物4, ref 遺物[3]);
            Eq.Set(form.comboBoxダンジョン遺物5, ref 遺物[4]);
            Eq.Set(form.comboBoxダンジョン遺物6, ref 遺物[5]);

            Eq.Set(form.numダンジョン部屋数, ref 部屋数);
            Eq.Set(form.trackbarダンジョンボス探索率, ref ボス出現探索率);
            Eq.Set(form.trackbarダンジョン地図発見A, ref 地図A出現探索率);
            Eq.Set(form.trackbarダンジョン地図発見B, ref 地図B出現探索率);
        }
        private void Save(StreamWriter sw_str, BinaryWriter bw_data)
        {
            //文字とそれ以外は別ファイルに保存
            sw_str.WriteLine(名前 + CV.区切りSave + 説明.Replace("\r\n",CV.改行Save));

            for(int i=0;i<6;i++)
            {
                RW.ReadWrite(bw_data, ref ボス[i]);
                RW.ReadWrite(bw_data, ref ボスLv[i]);
                RW.ReadWrite(bw_data, ref ザコ[i]);
                RW.ReadWrite(bw_data, ref ザコLv[i]);
            }

            RW.ReadWrite(bw_data, ref ボス地図);
            RW.ReadWrite(bw_data, ref 探索地図A);
            RW.ReadWrite(bw_data, ref 探索地図B);

            for(int i=0;i<遺物.Length;i++)
            {
                RW.ReadWrite(bw_data, ref 遺物[i]);
            }

            RW.ReadWrite(bw_data, ref 部屋数);
            RW.ReadWrite(bw_data, ref ボス出現探索率);
            RW.ReadWrite(bw_data, ref 地図A出現探索率);
            RW.ReadWrite(bw_data, ref 地図B出現探索率);
        }

        private void Load(StreamReader br_str, BinaryReader br_data)
        {
            var strS = br_str.ReadLine().Split(CV.区切りLoad);
            名前 = strS[0];
            説明 = strS[1].Replace( CV.改行Load , "\r\n");

            for (int i = 0; i < 6; i++)
            {
                RW.ReadWrite(br_data, ref ボス[i]);
                RW.ReadWrite(br_data, ref ボスLv[i]);
                RW.ReadWrite(br_data, ref ザコ[i]);
                RW.ReadWrite(br_data, ref ザコLv[i]);
            }

            RW.ReadWrite(br_data, ref ボス地図);
            RW.ReadWrite(br_data, ref 探索地図A);
            RW.ReadWrite(br_data, ref 探索地図B);

            for (int i = 0; i < 遺物.Length; i++)
            {
                RW.ReadWrite(br_data, ref 遺物[i]);
            }

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
            var clone = (Dungeon)this.MemberwiseClone();

            clone.ボス = new int[6];
            clone.ボスLv = new int[6];
            clone.ザコ = new int[6];
            clone.ザコLv = new int[6];

            clone.遺物 = new int[6];

            for(int i=0;i<6;i++)
            {
                clone.ボス[i] = ボス[i];
                clone.ボスLv[i] = ボスLv[i];
                clone.ザコ[i] = ザコ[i];
                clone.ザコLv[i] = ザコLv[i];
                clone.遺物[i] = 遺物[i];
            }

            return clone;
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
