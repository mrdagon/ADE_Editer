using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE_Editer
{
    public class Accessory
    {
        static public List<Accessory> data = new List<Accessory>();

        public string 名前 = "";
        public string 説明 = "";

        public int 画像ID;
        public int Pスキル;
        public int PスキルLv;
        public int ランク;
        public int HP;
        public int 筋力;
        public int 技力;
        public int 知力;
        public int 物防;
        public int 魔防;
        public int 命中;
        public int 回避;
        public int 会心;
        //コントロールに数値を反映
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

            Eq.Set(form.textBoxアクセサリー名前, ref 名前);
            Eq.Set(form.textBoxアクセサリー説明, ref 説明);

            Eq.Set(form.numアクセサリー画像ID, ref 画像ID);
            Eq.Set(form.comboBoxアクセサリーPスキル, ref Pスキル);
            Eq.Set(form.trackbarアクセサリーPスキルLv, ref PスキルLv);
            Eq.Set(form.trackbarアクセサリーランク, ref ランク);
            Eq.Set(form.trackbarアクセサリーHP, ref HP);
            Eq.Set(form.trackbarアクセサリー筋力, ref 筋力);
            Eq.Set(form.trackbarアクセサリー技力, ref 技力);
            Eq.Set(form.trackbarアクセサリー知力, ref 知力);
            Eq.Set(form.trackbarアクセサリー物防, ref 物防);
            Eq.Set(form.trackbarアクセサリー魔防, ref 魔防);
            Eq.Set(form.trackbarアクセサリー命中, ref 命中);
            Eq.Set(form.trackbarアクセサリー回避, ref 回避);
            Eq.Set(form.trackbarアクセサリー会心, ref 会心);
        }

        private void Save(StreamWriter sw_str, BinaryWriter bw_data)
        {
            //文字とそれ以外は別ファイルに保存
            sw_str.WriteLine(名前 + "," + 説明.Replace("\r\n", "\t"));

            RW.ReadWrite(bw_data, ref 画像ID);
            RW.ReadWrite(bw_data, ref Pスキル);
            RW.ReadWrite(bw_data, ref PスキルLv);
            RW.ReadWrite(bw_data, ref ランク);
            RW.ReadWrite(bw_data, ref HP);
            RW.ReadWrite(bw_data, ref 筋力);
            RW.ReadWrite(bw_data, ref 技力);
            RW.ReadWrite(bw_data, ref 知力);
            RW.ReadWrite(bw_data, ref 物防);
            RW.ReadWrite(bw_data, ref 魔防);
            RW.ReadWrite(bw_data, ref 命中);
            RW.ReadWrite(bw_data, ref 回避);
            RW.ReadWrite(bw_data, ref 会心);
        }

        private void Load(StreamReader br_str, BinaryReader br_data)
        {
            var strS = br_str.ReadLine().Split(',');
            名前 = strS[0];
            説明 = strS[1].Replace( "\t" , "\r\n");

            RW.ReadWrite(br_data, ref 画像ID);
            RW.ReadWrite(br_data, ref Pスキル);
            RW.ReadWrite(br_data, ref PスキルLv);
            RW.ReadWrite(br_data, ref ランク);
            RW.ReadWrite(br_data, ref HP);
            RW.ReadWrite(br_data, ref 筋力);
            RW.ReadWrite(br_data, ref 技力);
            RW.ReadWrite(br_data, ref 知力);
            RW.ReadWrite(br_data, ref 物防);
            RW.ReadWrite(br_data, ref 魔防);
            RW.ReadWrite(br_data, ref 命中);
            RW.ReadWrite(br_data, ref 回避);
            RW.ReadWrite(br_data, ref 会心);
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
                data.Add(new Accessory());
                data[i].Load(sr, br);
            }

            sr.Close();
            br.Close();
        }

        public Accessory Clone()
        {
            return (Accessory)this.MemberwiseClone();
        }

        static public void Insert(int index)
        {
            data.Insert(index, new Accessory());
            InsertRemove(index,+1);
        }

        static public void Remove(int index)
        {
            data.RemoveAt(index);
            InsertRemove(index,-1);
        }

        static private void InsertRemove(int index , int num)
        {
            //モンスターボスドロップ
            //ダンジョン遺物1～5

            foreach (var it in Monster.data)
            {
                if (it.ボスドロップ >= index) { it.ボスドロップ+=num; }
            }

            foreach (var it in Dungeon.data)
            {
                if (it.遺物1 >= index) { it.遺物1 += num; }
                if (it.遺物2 >= index) { it.遺物2 += num; }
                if (it.遺物3 >= index) { it.遺物3 += num; }
                if (it.遺物4 >= index) { it.遺物4 += num; }
                if (it.遺物5 >= index) { it.遺物5 += num; }
            }

            foreach (var it in Quest.data)
            {
                if (it.入手アクセサリー >= index) { it.入手アクセサリー += num; }
            }
        }

    }
}