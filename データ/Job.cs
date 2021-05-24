using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE_Editer
{
    public class Job
    {
        static public List<Job> data = new List<Job>();

        public string 名前 = "";
        public string 説明 = "";
        public int 武器種;
        public int 防具種;

        public int HP;
        public int 筋力;
        public int 技力;
        public int 知力;
        public int 物防;
        public int 魔防;
        public int 命中;
        public int 回避;
        public int 会心;

        public bool[] 習得Aスキル = new bool[MyType.Max];
        public bool[] 習得Pスキル = new bool[MyType.Max];

        public int[] 習得キースキル = new int[3];


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

            Eq.Set( form.textBoxジョブ名前, ref 名前);
            Eq.Set( form.textBoxジョブ説明, ref 説明);
            Eq.Set( form.comboBoxジョブ武器種, ref 武器種);
            Eq.Set( form.comboBoxジョブ防具種, ref 防具種);

            Eq.Set( form.trackbarジョブHP, ref HP);
            Eq.Set( form.trackbarジョブ筋力, ref 筋力);
            Eq.Set( form.trackbarジョブ技力, ref 技力);
            Eq.Set( form.trackbarジョブ知力, ref 知力);
            Eq.Set( form.trackbarジョブ物防, ref 物防);
            Eq.Set( form.trackbarジョブ魔防, ref 魔防);
            Eq.Set( form.trackbarジョブ命中, ref 命中);
            Eq.Set( form.trackbarジョブ回避, ref 回避);
            Eq.Set( form.trackbarジョブ会心, ref 会心);

            Eq.Set( form.checkedListBoxジョブAスキル, ref 習得Aスキル , ASkill.data.Count);
            Eq.Set( form.checkedListBoxジョブPスキル, ref 習得Pスキル , PSkill.data.Count);

            Eq.Set( form.comboBoxジョブキースキル1, ref 習得キースキル[0]);
            Eq.Set( form.comboBoxジョブキースキル2, ref 習得キースキル[1]);
            Eq.Set( form.comboBoxジョブキースキル3, ref 習得キースキル[2]);
        }

        private void Save(StreamWriter sw_str, BinaryWriter bw_data)
        {
            //文字とそれ以外は別ファイルに保存
            sw_str.WriteLine(名前 + CV.区切りSave + 説明.Replace("\r\n",CV.改行Save));

            RW.ReadWrite(bw_data, ref 武器種);
            RW.ReadWrite(bw_data, ref 防具種);

            RW.ReadWrite(bw_data, ref HP);
            RW.ReadWrite(bw_data, ref 筋力);
            RW.ReadWrite(bw_data, ref 技力);
            RW.ReadWrite(bw_data, ref 知力);
            RW.ReadWrite(bw_data, ref 物防);
            RW.ReadWrite(bw_data, ref 魔防);
            RW.ReadWrite(bw_data, ref 命中);
            RW.ReadWrite(bw_data, ref 回避);
            RW.ReadWrite(bw_data, ref 会心);

            RW.ReadWrite(bw_data, ref 習得Aスキル , ASkill.data.Count);
            RW.ReadWrite(bw_data, ref 習得Pスキル , PSkill.data.Count);

            for(int i=0;i<3;i++)
            {
                RW.ReadWrite(bw_data, ref 習得キースキル[i]);
            }
        }

        private void Load(StreamReader br_str, BinaryReader br_data)
        {
            var strS = br_str.ReadLine().Split(CV.区切りLoad);
            名前 = strS[0];
            説明 = strS[1].Replace("\t", "\r\n");

            RW.ReadWrite(br_data, ref 武器種);
            RW.ReadWrite(br_data, ref 防具種);

            RW.ReadWrite(br_data, ref HP);
            RW.ReadWrite(br_data, ref 筋力);
            RW.ReadWrite(br_data, ref 技力);
            RW.ReadWrite(br_data, ref 知力);
            RW.ReadWrite(br_data, ref 物防);
            RW.ReadWrite(br_data, ref 魔防);
            RW.ReadWrite(br_data, ref 命中);
            RW.ReadWrite(br_data, ref 回避);
            RW.ReadWrite(br_data, ref 会心);

            RW.ReadWrite(br_data, ref 習得Aスキル, ASkill.data.Count);
            RW.ReadWrite(br_data, ref 習得Pスキル, PSkill.data.Count);

            for (int i = 0; i < 3; i++)
            {
                RW.ReadWrite(br_data, ref 習得キースキル[i]);
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
                data.Add(new Job());
                data[i].Load(sr, br);
            }

            sr.Close();
            br.Close();
        }

        public Job Clone()
        {
            var clone = (Job)this.MemberwiseClone();

            clone.習得Pスキル = new bool[MyType.Max];
            clone.習得Aスキル = new bool[MyType.Max];
            clone.習得キースキル = new int[3];


            for (int i = 0; i < MyType.Max; i++)
            {
                clone.習得Pスキル[i] = 習得Pスキル[i];
                clone.習得Aスキル[i] = 習得Aスキル[i];
            }

            for(int i=0; i<習得キースキル.Length;i++)
            {
                clone.習得キースキル[i] = 習得キースキル[i];
            }

            return clone;
        }

        static public void Insert(int index)
        {
            data.Insert(index, new Job());
        }

        static public void Remove(int index)
        {
            data.RemoveAt(index);
        }

    }
}
