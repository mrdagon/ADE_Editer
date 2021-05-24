using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE_Editer
{
    public class Item
    {
        static public List<Item> data = new List<Item>();

        public string 名前 = "";
        public string 説明 = "";

        public int 装備種;
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

            Eq.Set(form.textBox装備品名前, ref 名前);
            Eq.Set(form.textBox装備品説明, ref 説明);

            Eq.Set(form.comboBox装備品装備種, ref 装備種);
            Eq.Set(form.comboBox装備品Pスキル, ref Pスキル);
            Eq.Set(form.trackbar装備品PスキルLv, ref PスキルLv);
            Eq.Set(form.trackbar装備品ランク, ref ランク);
            Eq.Set(form.trackbar装備品HP, ref HP);
            Eq.Set(form.trackbar装備品筋力, ref 筋力);
            Eq.Set(form.trackbar装備品技力, ref 技力);
            Eq.Set(form.trackbar装備品知力, ref 知力);
            Eq.Set(form.trackbar装備品物防, ref 物防);
            Eq.Set(form.trackbar装備品魔防, ref 魔防);
            Eq.Set(form.trackbar装備品命中, ref 命中);
            Eq.Set(form.trackbar装備品回避, ref 回避);
            Eq.Set(form.trackbar装備品会心, ref 会心);
        }

        private void Save(StreamWriter sw_str, BinaryWriter bw_data)
        {
            //文字とそれ以外は別ファイルに保存
            sw_str.WriteLine(名前 + CV.区切りSave + 説明.Replace("\r\n",CV.改行Save));

            RW.ReadWrite(bw_data, ref 装備種);
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
            var strS = br_str.ReadLine().Split(CV.区切りLoad);
            名前 = strS[0];
            説明 = strS[1].Replace(CV.改行Load , "\r\n");

            RW.ReadWrite(br_data, ref 装備種);
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
                data.Add(new Item());
                data[i].Load(sr, br);
            }

            sr.Close();
            br.Close();
        }

        public Item Clone()
        {
            return (Item)this.MemberwiseClone();
        }

        static public void Insert(int index)
        {
            data.Insert(index, new Item());
        }

        static public void Remove(int index)
        {
            data.RemoveAt(index);
        }
    }
}
