using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADE_Editer
{
    static public class Eq
    {
        //Setはコントロールの数値に反映
        //Getはコントロールの数値をデータに反映
        static public bool isSetMode = true;

        static public void Set(TextBox a, ref string b)
        {
            if (isSetMode)
            {
                a.Text = b;
            }
            else
            {
                b = a.Text;
            }
        }

        static public void Set(NumericUpDown a , ref int b)
        {
            if (isSetMode)
            {
                a.Value = b;
            }
            else
            {
                b = (int)a.Value;
            }
        }

        static public void Set(UserTrackbar a, ref int b)
        {
            if (isSetMode)
            {
                a.Value = b;
            }
            else
            {
                b = a.Value;
            }
        }

        static public void Set(ComboBox a, ref int b)
        {
            if (isSetMode)
            {
                if( b >= a.Items.Count)
                {
                    b = a.Items.Count - 1;
                }

                a.SelectedIndex = b;
            }
            else
            {
                b = a.SelectedIndex;
            }
        }

        static public void Set(CheckBox a, ref bool b)
        {
            if (isSetMode)
            {
                a.Checked = b;
            }
            else
            {
                b = a.Checked;
            }
        }

        static public void Set(CheckedListBox a, ref bool[] b , int size)
        {
            if (isSetMode)
            {
                for(int i=0;i<size;i++)
                {
                    a.SetItemChecked(i, b[i]);
                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    b[i] = a.GetItemChecked(i);
                }
            }
        }


    }

    static public class RW
    {
        static public void ReadWrite(BinaryWriter a, ref int b)
        {
            a.Write(b);
        }

        static public void ReadWrite(BinaryWriter a, ref bool b)
        {
            a.Write(b);
        }

        static public void ReadWrite(BinaryWriter a, ref bool[] b, int size)
        {
            for(int i=0;i<size;i++)
            {
                a.Write(b[i]);
            }
        }

        static public void ReadWrite(BinaryReader a, ref int b)
        {
            b = a.ReadInt32();
        }

        static public void ReadWrite(BinaryReader a, ref bool b)
        {
            b = a.ReadBoolean();
        }

        static public void ReadWrite(BinaryReader a, ref bool[] b, int size)
        {
            for (int i = 0; i < size; i++)
            {
                b[i] = a.ReadBoolean();
            }
        }
    }

    static public class InsertData
    {
        static public void Check(ref bool[] bo , int index , int num)
        {
            if (num > 0)
            {
                //挿入
                bool pbb = bo[index];
                bo[index] = false;//新規追加したのはfalse
                for (int i = index+1; i < MyType.Max - 1; i++)
                {
                    bool pb = bo[i];
                    bo[i] = pbb;
                    pbb = pb;
                }
            }
            else
            {
                //削除
                for (int i = index; i < MyType.Max - 1; i++)
                {
                    bo[i] = bo[i + 1];
                }
            }
        }

        static public void Check(ref int value, int index, int num)
        {
            if (value >= index)
            {
                value += num;
            }
        }
    }


    public class ASkill
    {
        static public List<ASkill> data = new List<ASkill>();

        public string 名前 = "";
        public string 説明 = "";
        public int アイコンID;
        public int エフェクトID;
        public int 習得Lv;
        public int 前提スキルID;//Pスキルリスト
        public int 前提スキルLv;

        public bool[] スキルタグ = new bool[MyType.Max];//スキルタグ
        public int 基礎ダメージ;
        public int 反映率;
        public int 命中;
        public int 会心率;
        public int 会心倍率;
        public int クールタイム;
        public int 対象;
        public int 範囲;
        public int Hit数;
        public int 減衰率;

        public int 参照ステ;
        public int 隊列;
        public int 連続スキルID;//Aスキルリスト

        public int 追加効果1;
        public int 追加効果2;
        public int 追加効果3;
        public int 追加効果4;
        public int 追加効果5;

        public int レベル補正種1;
        public int レベル補正1Lv1;
        public int レベル補正1Lv2;
        public int レベル補正1Lv3;
        public int レベル補正1Lv4;
        public int レベル補正1Lv5;
        public int レベル補正1Lv6;
        public int レベル補正1Lv7;
        public int レベル補正1Lv8;
        public int レベル補正1Lv9;

        public int レベル補正種2;
        public int レベル補正2Lv1;
        public int レベル補正2Lv2;
        public int レベル補正2Lv3;
        public int レベル補正2Lv4;
        public int レベル補正2Lv5;
        public int レベル補正2Lv6;
        public int レベル補正2Lv7;
        public int レベル補正2Lv8;
        public int レベル補正2Lv9;

        public bool 自己バフ;

        public int バフ種類1;
        public int バフ固定値1;
        public int バフ反映率1;
        public int バフ発動率1;
        public int バフ持続1;

        public int バフ種類2;
        public int バフ固定値2;
        public int バフ反映率2;
        public int バフ発動率2;
        public int バフ持続2;

        public int バフ種類3;
        public int バフ固定値3;
        public int バフ反映率3;
        public int バフ発動率3;
        public int バフ持続3;

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

        private void SetGet(MainForm form , bool isSet)
        {
            Eq.isSetMode = isSet;

            Eq.Set(form.textBoxAスキル名前, ref 名前);
            Eq.Set(form.textBoxAスキル説明 , ref 説明);

            Eq.Set(form.numAスキルアイコンID , ref アイコンID);
            Eq.Set(form.numAスキルエフェクトID , ref エフェクトID);
            Eq.Set(form.trackbarAスキル習得レベル , ref 習得Lv);
            Eq.Set(form.comboBoxAスキル前提スキル , ref 前提スキルID);//Pスキルリスト
            Eq.Set(form.trackbarAスキル前提スキル , ref 前提スキルLv);
            Eq.Set(form.checkedListBoxAスキルスキルタグ , ref スキルタグ , MyType.スキル系統.Count);//スキルタグ

            Eq.Set(form.trackbarAスキル基礎ダメージ , ref 基礎ダメージ);
            Eq.Set(form.trackbarAスキル反映率 , ref 反映率);
            Eq.Set(form.trackbarAスキル命中 , ref 命中);
            Eq.Set(form.trackbarAスキル会心率 , ref 会心率);
            Eq.Set(form.trackbarAスキル会心倍率 , ref 会心倍率);
            Eq.Set(form.trackbarAスキルクールタイム , ref クールタイム);
            Eq.Set(form.comboBoxAスキル対象 , ref 対象);
            Eq.Set(form.trackbarAスキル範囲 , ref 範囲);
            Eq.Set(form.trackbarAスキルHit数 , ref Hit数);
            Eq.Set(form.trackbarAスキル減衰率 , ref 減衰率);

            Eq.Set(form.comboBoxAスキル参照ステ , ref 参照ステ);
            Eq.Set(form.comboBoxAスキル隊列 , ref 隊列);
            Eq.Set(form.comboBoxAスキル連続スキル , ref 連続スキルID);//Aスキルリスト

            Eq.Set(form.comboBoxAスキル追加効果1 , ref 追加効果1);
            Eq.Set(form.comboBoxAスキル追加効果2 , ref 追加効果2);
            Eq.Set(form.comboBoxAスキル追加効果3 , ref 追加効果3);
            Eq.Set(form.comboBoxAスキル追加効果4 , ref 追加効果4);
            Eq.Set(form.comboBoxAスキル追加効果5 , ref 追加効果5);

            Eq.Set(form.comboBoxAスキルレベル補正1 , ref レベル補正種1);
            Eq.Set(form.numAスキルレベル補正1Lv1 , ref レベル補正1Lv1);
            Eq.Set(form.numAスキルレベル補正1Lv2 , ref レベル補正1Lv2);
            Eq.Set(form.numAスキルレベル補正1Lv3 , ref レベル補正1Lv3);
            Eq.Set(form.numAスキルレベル補正1Lv4 , ref レベル補正1Lv4);
            Eq.Set(form.numAスキルレベル補正1Lv5 , ref レベル補正1Lv5);
            Eq.Set(form.numAスキルレベル補正1Lv6 , ref レベル補正1Lv6);
            Eq.Set(form.numAスキルレベル補正1Lv7 , ref レベル補正1Lv7);
            Eq.Set(form.numAスキルレベル補正1Lv8 , ref レベル補正1Lv8);
            Eq.Set(form.numAスキルレベル補正1Lv9 , ref レベル補正1Lv9);

            Eq.Set(form.comboBoxAスキルレベル補正2 , ref レベル補正種2);
            Eq.Set(form.numAスキルレベル補正2Lv1 , ref レベル補正2Lv1);
            Eq.Set(form.numAスキルレベル補正2Lv2 , ref レベル補正2Lv2);
            Eq.Set(form.numAスキルレベル補正2Lv3 , ref レベル補正2Lv3);
            Eq.Set(form.numAスキルレベル補正2Lv4 , ref レベル補正2Lv4);
            Eq.Set(form.numAスキルレベル補正2Lv5 , ref レベル補正2Lv5);
            Eq.Set(form.numAスキルレベル補正2Lv6 , ref レベル補正2Lv6);
            Eq.Set(form.numAスキルレベル補正2Lv7 , ref レベル補正2Lv7);
            Eq.Set(form.numAスキルレベル補正2Lv8 , ref レベル補正2Lv8);
            Eq.Set(form.numAスキルレベル補正2Lv9 , ref レベル補正2Lv9);

            Eq.Set(form.checkBoxAスキル自己バフ , ref 自己バフ);

            Eq.Set(form.comboBoxAスキルバフ1 , ref バフ種類1);
            Eq.Set(form.trackbarAスキルバフ固定値1 , ref バフ固定値1);
            Eq.Set(form.trackbarAスキルバフ反映率1 , ref バフ反映率1);
            Eq.Set(form.trackbarAスキルバフ発動率1 , ref バフ発動率1);
            Eq.Set(form.trackbarAスキルバフ持続1 , ref バフ持続1);

            Eq.Set(form.comboBoxAスキルバフ2 , ref バフ種類2);
            Eq.Set(form.trackbarAスキルバフ固定値2 , ref バフ固定値2);
            Eq.Set(form.trackbarAスキルバフ反映率2 , ref バフ反映率2);
            Eq.Set(form.trackbarAスキルバフ発動率2 , ref バフ発動率2);
            Eq.Set(form.trackbarAスキルバフ持続2 , ref バフ持続2);

            Eq.Set(form.comboBoxAスキルバフ3 , ref バフ種類3);
            Eq.Set(form.trackbarAスキルバフ固定値3 , ref バフ固定値3);
            Eq.Set(form.trackbarAスキルバフ反映率3 , ref バフ反映率3);
            Eq.Set(form.trackbarAスキルバフ発動率3 , ref バフ発動率3);
            Eq.Set(form.trackbarAスキルバフ持続3 , ref バフ持続3);
        }

        private void Save(StreamWriter sw_str , BinaryWriter bw_data )
        {
            //文字とそれ以外は別ファイルに保存
            sw_str.WriteLine(名前 + "," + 説明);

            RW.ReadWrite(bw_data, ref アイコンID);
            RW.ReadWrite(bw_data, ref エフェクトID);
            RW.ReadWrite(bw_data, ref 習得Lv);
            RW.ReadWrite(bw_data, ref 前提スキルID);//Pスキルリスト
            RW.ReadWrite(bw_data, ref 前提スキルLv);
            
            RW.ReadWrite(bw_data, ref スキルタグ , MyType.スキル系統.Count);
           
            RW.ReadWrite(bw_data, ref 基礎ダメージ);
            RW.ReadWrite(bw_data, ref 反映率);
            RW.ReadWrite(bw_data, ref 命中);
            RW.ReadWrite(bw_data, ref 会心率);
            RW.ReadWrite(bw_data, ref 会心倍率);
            RW.ReadWrite(bw_data, ref クールタイム);
            RW.ReadWrite(bw_data, ref 対象);
            RW.ReadWrite(bw_data, ref 範囲);
            RW.ReadWrite(bw_data, ref Hit数);
            RW.ReadWrite(bw_data, ref 減衰率);

            RW.ReadWrite(bw_data, ref 参照ステ);
            RW.ReadWrite(bw_data, ref 隊列);
            RW.ReadWrite(bw_data, ref 連続スキルID);//Aスキルリスト

            RW.ReadWrite(bw_data, ref 追加効果1);
            RW.ReadWrite(bw_data, ref 追加効果2);
            RW.ReadWrite(bw_data, ref 追加効果3);
            RW.ReadWrite(bw_data, ref 追加効果4);
            RW.ReadWrite(bw_data, ref 追加効果5);

            RW.ReadWrite(bw_data, ref レベル補正種1);
            RW.ReadWrite(bw_data, ref レベル補正1Lv1);
            RW.ReadWrite(bw_data, ref レベル補正1Lv2);
            RW.ReadWrite(bw_data, ref レベル補正1Lv3);
            RW.ReadWrite(bw_data, ref レベル補正1Lv4);
            RW.ReadWrite(bw_data, ref レベル補正1Lv5);
            RW.ReadWrite(bw_data, ref レベル補正1Lv6);
            RW.ReadWrite(bw_data, ref レベル補正1Lv7);
            RW.ReadWrite(bw_data, ref レベル補正1Lv8);
            RW.ReadWrite(bw_data, ref レベル補正1Lv9);

            RW.ReadWrite(bw_data, ref レベル補正種2);
            RW.ReadWrite(bw_data, ref レベル補正2Lv1);
            RW.ReadWrite(bw_data, ref レベル補正2Lv2);
            RW.ReadWrite(bw_data, ref レベル補正2Lv3);
            RW.ReadWrite(bw_data, ref レベル補正2Lv4);
            RW.ReadWrite(bw_data, ref レベル補正2Lv5);
            RW.ReadWrite(bw_data, ref レベル補正2Lv6);
            RW.ReadWrite(bw_data, ref レベル補正2Lv7);
            RW.ReadWrite(bw_data, ref レベル補正2Lv8);
            RW.ReadWrite(bw_data, ref レベル補正2Lv9);

            RW.ReadWrite(bw_data, ref 自己バフ);

            RW.ReadWrite(bw_data, ref バフ種類1);
            RW.ReadWrite(bw_data, ref バフ固定値1);
            RW.ReadWrite(bw_data, ref バフ反映率1);
            RW.ReadWrite(bw_data, ref バフ発動率1);
            RW.ReadWrite(bw_data, ref バフ持続1);

            RW.ReadWrite(bw_data, ref バフ種類2);
            RW.ReadWrite(bw_data, ref バフ固定値2);
            RW.ReadWrite(bw_data, ref バフ反映率2);
            RW.ReadWrite(bw_data, ref バフ発動率2);
            RW.ReadWrite(bw_data, ref バフ持続2);

            RW.ReadWrite(bw_data, ref バフ種類3);
            RW.ReadWrite(bw_data, ref バフ固定値3);
            RW.ReadWrite(bw_data, ref バフ反映率3);
            RW.ReadWrite(bw_data, ref バフ発動率3);
            RW.ReadWrite(bw_data, ref バフ持続3);
        }

        private void Load(StreamReader br_str , BinaryReader br_data)
        {
            var str = br_str.ReadLine();
            var strS = str.Split(',');

            名前 = strS[0];
            説明 = strS[1];

            RW.ReadWrite(br_data, ref アイコンID);
            RW.ReadWrite(br_data, ref エフェクトID);
            RW.ReadWrite(br_data, ref 習得Lv);
            RW.ReadWrite(br_data, ref 前提スキルID);//Pスキルリスト
            RW.ReadWrite(br_data, ref 前提スキルLv);

            RW.ReadWrite(br_data, ref スキルタグ, MyType.スキル系統.Count);

            RW.ReadWrite(br_data, ref 基礎ダメージ);
            RW.ReadWrite(br_data, ref 反映率);
            RW.ReadWrite(br_data, ref 命中);
            RW.ReadWrite(br_data, ref 会心率);
            RW.ReadWrite(br_data, ref 会心倍率);
            RW.ReadWrite(br_data, ref クールタイム);
            RW.ReadWrite(br_data, ref 対象);
            RW.ReadWrite(br_data, ref 範囲);
            RW.ReadWrite(br_data, ref Hit数);
            RW.ReadWrite(br_data, ref 減衰率);

            RW.ReadWrite(br_data, ref 参照ステ);
            RW.ReadWrite(br_data, ref 隊列);
            RW.ReadWrite(br_data, ref 連続スキルID);//Aスキルリスト

            RW.ReadWrite(br_data, ref 追加効果1);
            RW.ReadWrite(br_data, ref 追加効果2);
            RW.ReadWrite(br_data, ref 追加効果3);
            RW.ReadWrite(br_data, ref 追加効果4);
            RW.ReadWrite(br_data, ref 追加効果5);

            RW.ReadWrite(br_data, ref レベル補正種1);
            RW.ReadWrite(br_data, ref レベル補正1Lv1);
            RW.ReadWrite(br_data, ref レベル補正1Lv2);
            RW.ReadWrite(br_data, ref レベル補正1Lv3);
            RW.ReadWrite(br_data, ref レベル補正1Lv4);
            RW.ReadWrite(br_data, ref レベル補正1Lv5);
            RW.ReadWrite(br_data, ref レベル補正1Lv6);
            RW.ReadWrite(br_data, ref レベル補正1Lv7);
            RW.ReadWrite(br_data, ref レベル補正1Lv8);
            RW.ReadWrite(br_data, ref レベル補正1Lv9);

            RW.ReadWrite(br_data, ref レベル補正種2);
            RW.ReadWrite(br_data, ref レベル補正2Lv1);
            RW.ReadWrite(br_data, ref レベル補正2Lv2);
            RW.ReadWrite(br_data, ref レベル補正2Lv3);
            RW.ReadWrite(br_data, ref レベル補正2Lv4);
            RW.ReadWrite(br_data, ref レベル補正2Lv5);
            RW.ReadWrite(br_data, ref レベル補正2Lv6);
            RW.ReadWrite(br_data, ref レベル補正2Lv7);
            RW.ReadWrite(br_data, ref レベル補正2Lv8);
            RW.ReadWrite(br_data, ref レベル補正2Lv9);

            RW.ReadWrite(br_data, ref 自己バフ);

            RW.ReadWrite(br_data, ref バフ種類1);
            RW.ReadWrite(br_data, ref バフ固定値1);
            RW.ReadWrite(br_data, ref バフ反映率1);
            RW.ReadWrite(br_data, ref バフ発動率1);
            RW.ReadWrite(br_data, ref バフ持続1);

            RW.ReadWrite(br_data, ref バフ種類2);
            RW.ReadWrite(br_data, ref バフ固定値2);
            RW.ReadWrite(br_data, ref バフ反映率2);
            RW.ReadWrite(br_data, ref バフ発動率2);
            RW.ReadWrite(br_data, ref バフ持続2);

            RW.ReadWrite(br_data, ref バフ種類3);
            RW.ReadWrite(br_data, ref バフ固定値3);
            RW.ReadWrite(br_data, ref バフ反映率3);
            RW.ReadWrite(br_data, ref バフ発動率3);
            RW.ReadWrite(br_data, ref バフ持続3);
        }

        static public void Save(string fileName)
        {
            var sw = new StreamWriter(fileName + ".csv");
            var bw = new BinaryWriter(new StreamWriter(fileName + ".dat").BaseStream);

            //データ件数を保存した後データを保存

            bw.Write(data.Count());
            for(int i=0;i<data.Count();i++)
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
                data.Add( new ASkill());
                data[i].Load(sr, br);
            }

            sr.Close();
            br.Close();
        }

        public ASkill Clone()
        {
            ASkill clone = (ASkill)this.MemberwiseClone();

            clone.スキルタグ = new bool[MyType.Max];

            for( int i=0; i < スキルタグ.Count() ; i++)
            {
                clone.スキルタグ[i] = スキルタグ[i];
            }
                  
            return clone;
        }

        static public void Insert(int index)
        {
            data.Insert(index, new ASkill());
            InsertRemove(index, +1);
        }

        static public void Remove(int index)
        {
            data.RemoveAt(index);
            InsertRemove(index, -1);
        }

        static private void InsertRemove(int index, int num)
        {
            //Aスキル連続スキル
            //Aスキル前提スキル
            //ジョブAスキル
            //モンスターAスキル
            foreach (var it in ASkill.data)
            {
                if( it.連続スキルID >= index){ it.連続スキルID += num; }
            }
            foreach (var it in Job.data)
            {
                InsertData.Check(ref it.習得Aスキル, index, num);
            }
            foreach (var it in Monster.data)
            {
                InsertData.Check(ref it.習得Aスキル, index, num);
            }
        }
    }
}
