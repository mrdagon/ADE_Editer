using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE_Editer
{
    public class Monster
    {
        static public List<Monster> data = new List<Monster>();

        public string 名前 = "";
        public string 説明 = "";

        public int 画像ID;
        public int 素材種;
        public int 隊列;
        public bool ボス;
        public int ボスドロップ;
        public int レア素材率;

        public int HP;
        public int 筋力;
        public int 技力;
        public int 知力;
        public int 物防;
        public int 魔防;
        public int 命中;
        public int 回避;
        public int 会心;

        public bool[] 習得Pスキル = new bool[MyType.Max];
        public bool[] 習得Aスキル = new bool[MyType.Max];
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

            Eq.Set(form.textBoxモンスター名前, ref 名前);
            Eq.Set(form.textBoxモンスター説明, ref 説明);

            Eq.Set(form.numモンスター画像ID, ref 画像ID);
            Eq.Set(form.comboBoxモンスター素材種, ref 素材種);
            Eq.Set(form.comboBoxモンスター隊列, ref 隊列);
            Eq.Set(form.checkBoxモンスターボス, ref ボス);
            Eq.Set(form.comboBoxモンスターボスドロップ, ref ボスドロップ);
            Eq.Set(form.trackbarモンスターレア素材率, ref レア素材率);

            Eq.Set(form.trackbarモンスターHP, ref HP);
            Eq.Set(form.trackbarモンスター筋力, ref 筋力);
            Eq.Set(form.trackbarモンスター技力, ref 技力);
            Eq.Set(form.trackbarモンスター知力, ref 知力);
            Eq.Set(form.trackbarモンスター物防, ref 物防);
            Eq.Set(form.trackbarモンスター魔防, ref 魔防);
            Eq.Set(form.trackbarモンスター命中, ref 命中);
            Eq.Set(form.trackbarモンスター回避, ref 回避);
            Eq.Set(form.trackbarモンスター会心, ref 会心);

            Eq.Set(form.checkedListBoxtrackbarモンスターPスキル, ref 習得Pスキル , PSkill.data.Count);
            Eq.Set(form.checkedListBoxtrackbarモンスターAスキル, ref 習得Aスキル , ASkill.data.Count);
        }

        private void Save(StreamWriter sw_str, BinaryWriter bw_data)
        {
            //文字とそれ以外は別ファイルに保存
            sw_str.WriteLine(名前 + "," + 説明);

            RW.ReadWrite(bw_data, ref 画像ID);
            RW.ReadWrite(bw_data, ref 素材種);
            RW.ReadWrite(bw_data, ref 隊列);
            RW.ReadWrite(bw_data, ref ボス);
            RW.ReadWrite(bw_data, ref ボスドロップ);
            RW.ReadWrite(bw_data, ref レア素材率);

            RW.ReadWrite(bw_data, ref HP);
            RW.ReadWrite(bw_data, ref 筋力);
            RW.ReadWrite(bw_data, ref 技力);
            RW.ReadWrite(bw_data, ref 知力);
            RW.ReadWrite(bw_data, ref 物防);
            RW.ReadWrite(bw_data, ref 魔防);
            RW.ReadWrite(bw_data, ref 命中);
            RW.ReadWrite(bw_data, ref 回避);
            RW.ReadWrite(bw_data, ref 会心);

            RW.ReadWrite(bw_data, ref 習得Pスキル , PSkill.data.Count);
            RW.ReadWrite(bw_data, ref 習得Aスキル , ASkill.data.Count);
        }

        private void Load(StreamReader br_str, BinaryReader br_data)
        {
            var strS = br_str.ReadLine().Split(',');
            名前 = strS[0];
            説明 = strS[1];

            RW.ReadWrite(br_data, ref 画像ID);
            RW.ReadWrite(br_data, ref 素材種);
            RW.ReadWrite(br_data, ref 隊列);
            RW.ReadWrite(br_data, ref ボス);
            RW.ReadWrite(br_data, ref ボスドロップ);
            RW.ReadWrite(br_data, ref レア素材率);

            RW.ReadWrite(br_data, ref HP);
            RW.ReadWrite(br_data, ref 筋力);
            RW.ReadWrite(br_data, ref 技力);
            RW.ReadWrite(br_data, ref 知力);
            RW.ReadWrite(br_data, ref 物防);
            RW.ReadWrite(br_data, ref 魔防);
            RW.ReadWrite(br_data, ref 命中);
            RW.ReadWrite(br_data, ref 回避);
            RW.ReadWrite(br_data, ref 会心);

            RW.ReadWrite(br_data, ref 習得Pスキル, PSkill.data.Count);
            RW.ReadWrite(br_data, ref 習得Aスキル, ASkill.data.Count);
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
                data.Add(new Monster());
                data[i].Load(sr, br);
            }

            sr.Close();
            br.Close();
        }

        public Monster Clone()
        {
            var clone = (Monster)this.MemberwiseClone();

            clone.習得Pスキル = new bool[MyType.Max];
            clone.習得Aスキル = new bool[MyType.Max];


            for (int i = 0; i < MyType.Max; i++)
            {
                clone.習得Pスキル[i] = 習得Pスキル[i];
                clone.習得Aスキル[i] = 習得Aスキル[i];
            }

            return clone;
        }

        static public void Insert(int index)
        {
            data.Insert(index, new Monster());


            InsertRemove(index, +1);
        }

        static public void Remove(int index)
        {
            data.RemoveAt(index);
            InsertRemove(index, -1);
        }

        static private void InsertRemove(int index, int num)
        {
            //ダンジョンボス
            //ダンジョンザコx5
            foreach (var it in Dungeon.data)
            {
                if (it.ボス >= index) { it.ボス += num; }
                if (it.ザコ1 >= index) { it.ザコ1 += num; }
                if (it.ザコ2 >= index) { it.ザコ2 += num; }
                if (it.ザコ3 >= index) { it.ザコ3 += num; }
                if (it.ザコ4 >= index) { it.ザコ4 += num; }
                if (it.ザコ5 >= index) { it.ザコ5 += num; }
            }
        }
    }
}
