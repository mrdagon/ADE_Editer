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
        public bool isボス;
        public int[] ボスドロップ = new int[2];
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

        public int[] Aスキル = new int[8];
        public int[] AスキルLv = new int[8];

        public int[] Pスキル = new int[8];
        public int[] PスキルLv = new int[8];

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
            Eq.Set(form.checkBoxモンスターボス, ref isボス);
            Eq.Set(form.comboBoxモンスターボスドロップA, ref ボスドロップ[0]);
            Eq.Set(form.comboBoxモンスターボスドロップB, ref ボスドロップ[1]);
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

            Eq.Set(form.comboBoxモンスターAスキル1, ref Aスキル[0]);
            Eq.Set(form.comboBoxモンスターAスキル2, ref Aスキル[1]);
            Eq.Set(form.comboBoxモンスターAスキル3, ref Aスキル[2]);
            Eq.Set(form.comboBoxモンスターAスキル4, ref Aスキル[3]);
            Eq.Set(form.comboBoxモンスターAスキル5, ref Aスキル[4]);
            Eq.Set(form.comboBoxモンスターAスキル6, ref Aスキル[5]);
            Eq.Set(form.comboBoxモンスターAスキル7, ref Aスキル[6]);
            Eq.Set(form.comboBoxモンスターAスキル8, ref Aスキル[7]);

            Eq.Set(form.numericUpDownモンスターAスキルLv1, ref AスキルLv[0]);
            Eq.Set(form.numericUpDownモンスターAスキルLv2, ref AスキルLv[1]);
            Eq.Set(form.numericUpDownモンスターAスキルLv3, ref AスキルLv[2]);
            Eq.Set(form.numericUpDownモンスターAスキルLv4, ref AスキルLv[3]);
            Eq.Set(form.numericUpDownモンスターAスキルLv5, ref AスキルLv[4]);
            Eq.Set(form.numericUpDownモンスターAスキルLv6, ref AスキルLv[5]);
            Eq.Set(form.numericUpDownモンスターAスキルLv7, ref AスキルLv[6]);
            Eq.Set(form.numericUpDownモンスターAスキルLv8, ref AスキルLv[7]);

            Eq.Set(form.comboBoxモンスターPスキル1, ref Pスキル[0]);
            Eq.Set(form.comboBoxモンスターPスキル2, ref Pスキル[1]);
            Eq.Set(form.comboBoxモンスターPスキル3, ref Pスキル[2]);
            Eq.Set(form.comboBoxモンスターPスキル4, ref Pスキル[3]);
            Eq.Set(form.comboBoxモンスターPスキル5, ref Pスキル[4]);
            Eq.Set(form.comboBoxモンスターPスキル6, ref Pスキル[5]);
            Eq.Set(form.comboBoxモンスターPスキル7, ref Pスキル[6]);
            Eq.Set(form.comboBoxモンスターPスキル8, ref Pスキル[7]);

            Eq.Set(form.numericUpDownモンスターPスキルLv1, ref PスキルLv[0]);
            Eq.Set(form.numericUpDownモンスターPスキルLv2, ref PスキルLv[1]);
            Eq.Set(form.numericUpDownモンスターPスキルLv3, ref PスキルLv[2]);
            Eq.Set(form.numericUpDownモンスターPスキルLv4, ref PスキルLv[3]);
            Eq.Set(form.numericUpDownモンスターPスキルLv5, ref PスキルLv[4]);
            Eq.Set(form.numericUpDownモンスターPスキルLv6, ref PスキルLv[5]);
            Eq.Set(form.numericUpDownモンスターPスキルLv7, ref PスキルLv[6]);
            Eq.Set(form.numericUpDownモンスターPスキルLv8, ref PスキルLv[7]);

        }

        private void Save(StreamWriter sw_str, BinaryWriter bw_data)
        {
            //文字とそれ以外は別ファイルに保存
            sw_str.WriteLine(名前 + CV.区切りSave + 説明.Replace("\r\n",CV.改行Save));

            RW.ReadWrite(bw_data, ref 画像ID);
            RW.ReadWrite(bw_data, ref 素材種);
            RW.ReadWrite(bw_data, ref 隊列);
            RW.ReadWrite(bw_data, ref isボス);
            RW.ReadWrite(bw_data, ref ボスドロップ[0]);
            RW.ReadWrite(bw_data, ref ボスドロップ[1]);
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

            for(int i=0;i<Aスキル.Length;i++)
            {
                RW.ReadWrite(bw_data, ref Aスキル[i]);
                RW.ReadWrite(bw_data, ref AスキルLv[i]);
            }
            for (int i = 0; i < Pスキル.Length; i++)
            {
                RW.ReadWrite(bw_data, ref Pスキル[i]);
                RW.ReadWrite(bw_data, ref PスキルLv[i]);
            }

        }

        private void Load(StreamReader br_str, BinaryReader br_data)
        {
            var strS = br_str.ReadLine().Split(CV.区切りLoad);
            名前 = strS[0];
            説明 = strS[1].Replace( CV.改行Load , "\r\n");

            RW.ReadWrite(br_data, ref 画像ID);
            RW.ReadWrite(br_data, ref 素材種);
            RW.ReadWrite(br_data, ref 隊列);
            RW.ReadWrite(br_data, ref isボス);
            RW.ReadWrite(br_data, ref ボスドロップ[0]);
            RW.ReadWrite(br_data, ref ボスドロップ[1]);
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

            for (int i = 0; i < Aスキル.Length; i++)
            {
                RW.ReadWrite(br_data, ref Aスキル[i]);
                RW.ReadWrite(br_data, ref AスキルLv[i]);
            }
            for (int i = 0; i < Pスキル.Length; i++)
            {
                RW.ReadWrite(br_data, ref Pスキル[i]);
                RW.ReadWrite(br_data, ref PスキルLv[i]);
            }
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


            clone.Aスキル = new int[4];
            clone.AスキルLv = new int[4];

            clone.Pスキル = new int[8];
            clone.PスキルLv = new int[8];

            clone.ボスドロップ = new int[2];

            clone.ボスドロップ[0] = ボスドロップ[0];
            clone.ボスドロップ[1] = ボスドロップ[1];

            for (int i=0;i<Aスキル.Length;i++)
            {
                clone.Aスキル[i] = Aスキル[i];
                clone.AスキルLv[i] = AスキルLv[i];
            }

            for (int i = 0; i < Pスキル.Length; i++)
            {
                clone.Pスキル[i] = Pスキル[i];
                clone.PスキルLv[i] = PスキルLv[i];
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
                for(int i=0;i<it.ボス.Length;i++)
                {
                    if (it.ボス[i] >= index) { it.ボス[i] += num; }
                    if (it.ザコ[i] >= index) { it.ザコ[i] += num; }
                }
            }
        }
    }
}
