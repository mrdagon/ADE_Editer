using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE_Editer
{
    public class PSkill
    {
        static public List<PSkill> data = new List<PSkill>();

        public string 名前 = "";
        public string 説明 = "";

        public int アイコンID;
        public bool キースキル;

        public bool[] スキルタグ = new bool[MyType.Max];//
        public int 習得前提PスキルID;//
        public int 習得前提PスキルLv;
        public int 習得必要Lv;

        public int 条件;//
        public int 条件値;
        public int 持続時間;

        public int タイミング;//
        public int 発動率;
        public int 対象;//
        public int 効果A;//
        public int 効果値A;
        public int 効果B;//
        public int 効果値B;


        public int レベル補正種類A;
        public int レベル補正A;

        public int レベル補正種類B;
        public int レベル補正B;

        public int レアリティ;

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

            Eq.Set(form.textBoxPスキル名前, ref 名前);
            Eq.Set(form.textBoxPスキル説明, ref 説明);

            Eq.Set(form.numPスキルアイコンID, ref アイコンID);
            Eq.Set(form.checkBoxPスキルキースキル, ref キースキル);

            Eq.Set(form.checkedListBoxPスキルスキルタグ, ref スキルタグ , MyType.スキル系統.Count);//
            Eq.Set(form.comboBoxPスキルレアリティ, ref 習得前提PスキルID);//

            Eq.Set(form.comboBoxPスキル条件, ref 条件);//
            Eq.Set(form.trackbarPスキル条件値, ref 条件値);

            Eq.Set(form.comboBoxPスキルタイミング, ref タイミング);//
            Eq.Set(form.trackbarPスキル発動率, ref 発動率);
            Eq.Set(form.comboBoxPスキル対象, ref 対象);//
            Eq.Set(form.comboBoxPスキル効果A, ref 効果A);//
            Eq.Set(form.trackbarPスキル効果値A, ref 効果値A);
            Eq.Set(form.comboBoxPスキル効果B, ref 効果B);//
            Eq.Set(form.trackbarPスキル効果値B, ref 効果値B);

            Eq.Set(form.comboBoxPスキルレベル補正1, ref レベル補正種類A);
            Eq.Set(form.numPスキルレベル補正Lv1, ref レベル補正A);

            Eq.Set(form.comboBoxPスキルレベル補正2 , ref レベル補正種類B);
            Eq.Set(form.numPスキルレベル補正Lv5 , ref レベル補正B);

            Eq.Set(form.comboBoxPスキルレアリティ, ref レアリティ);

        }

        private void Save(StreamWriter sw_str, BinaryWriter bw_data)
        {
            //文字とそれ以外は別ファイルに保存
            sw_str.WriteLine(名前 + CV.区切りSave + 説明.Replace("\r\n",CV.改行Save));

            RW.ReadWrite(bw_data, ref アイコンID);
            RW.ReadWrite(bw_data, ref キースキル);

            RW.ReadWrite(bw_data, ref スキルタグ , MyType.スキル系統.Count);//
            RW.ReadWrite(bw_data, ref 習得前提PスキルID);//
            RW.ReadWrite(bw_data, ref 習得前提PスキルLv);
            RW.ReadWrite(bw_data, ref 習得必要Lv);

            RW.ReadWrite(bw_data, ref 条件);//
            RW.ReadWrite(bw_data, ref 条件値);
            RW.ReadWrite(bw_data, ref 持続時間);

            RW.ReadWrite(bw_data, ref タイミング);//
            RW.ReadWrite(bw_data, ref 発動率);
            RW.ReadWrite(bw_data, ref 対象);//
            RW.ReadWrite(bw_data, ref 効果A);//
            RW.ReadWrite(bw_data, ref 効果値A);
            RW.ReadWrite(bw_data, ref 効果B);//
            RW.ReadWrite(bw_data, ref 効果値B);

            RW.ReadWrite(bw_data, ref レベル補正種類A);
            RW.ReadWrite(bw_data, ref レベル補正A);
            

            RW.ReadWrite(bw_data, ref レベル補正種類B);
            RW.ReadWrite(bw_data, ref レベル補正B);

            RW.ReadWrite(bw_data, ref レアリティ);
        }

        private void Load(StreamReader br_str, BinaryReader br_data)
        {
            var strS = br_str.ReadLine().Split(CV.区切りLoad);
            名前 = strS[0];
            説明 = strS[1].Replace( CV.改行Load , "\r\n");

            RW.ReadWrite(br_data, ref アイコンID);
            RW.ReadWrite(br_data, ref キースキル);

            RW.ReadWrite(br_data, ref スキルタグ, MyType.スキル系統.Count);//
            RW.ReadWrite(br_data, ref 習得前提PスキルID);//
            RW.ReadWrite(br_data, ref 習得前提PスキルLv);
            RW.ReadWrite(br_data, ref 習得必要Lv);

            RW.ReadWrite(br_data, ref 条件);//
            RW.ReadWrite(br_data, ref 条件値);
            RW.ReadWrite(br_data, ref 持続時間);

            RW.ReadWrite(br_data, ref タイミング);//
            RW.ReadWrite(br_data, ref 発動率);
            RW.ReadWrite(br_data, ref 対象);//
            RW.ReadWrite(br_data, ref 効果A);//
            RW.ReadWrite(br_data, ref 効果値A);

            RW.ReadWrite(br_data, ref 効果B);//
            RW.ReadWrite(br_data, ref 効果値B);

            RW.ReadWrite(br_data, ref レベル補正種類A);
            RW.ReadWrite(br_data, ref レベル補正A);
            
            RW.ReadWrite(br_data, ref レベル補正種類B);
            RW.ReadWrite(br_data, ref レベル補正B);

            RW.ReadWrite(br_data, ref レアリティ);

            if (レアリティ < 0) { レアリティ = 0; }
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
                data.Add(new PSkill());
                data[i].Load(sr, br);
            }

            sr.Close();
            br.Close();
        }

        public PSkill Clone()
        {
            PSkill clone = (PSkill)this.MemberwiseClone();

            clone.スキルタグ = new bool[MyType.Max];

            for (int i = 0; i < スキルタグ.Count(); i++)
            {
                clone.スキルタグ[i] = スキルタグ[i];
            }

            clone.レベル補正A = レベル補正A;
            clone.レベル補正B = レベル補正B;

            clone.レアリティ = レアリティ;

            return clone;
        }

        static public void Insert(int index)
        {
            data.Insert(index, new PSkill());
            //Pスキル習得前提Pスキル
            //ジョブPスキル
            //モンスターPスキル
            //装備品Pスキル
            //アクセサリーPスキル

            InsertRemove(index, +1);
        }

        static public void Remove(int index)
        {
            data.RemoveAt(index);
            InsertRemove(index, -1);
        }

        static private void InsertRemove(int index, int num)
        {
            foreach (var it in PSkill.data)
            {
                if (it.習得前提PスキルID >= index) { it.習得前提PスキルID += num; }
            }
            foreach (var it in Job.data)
            {
                InsertData.Check(ref it.習得Pスキル, index, num);

                for(int i=0;i<it.習得キースキル.Length;i++)
                {
                    if (it.習得キースキル[i] >= index) { it.習得キースキル[i] += num; }
                }
            }


            foreach (var it in Item.data)
            {
                if (it.Pスキル >= index) { it.Pスキル += num; }
            }
            foreach (var it in Accessory.data)
            {
                if (it.Pスキル >= index) { it.Pスキル += num; }
            }

            foreach (var it in Monster.data)
            {
                for (int i = 0; i < it.Pスキル.Length; i++)
                {
                    if (it.Pスキル[i] >= index) { it.Pスキル[i] += num; }
                }
            }
        }

    }
}
