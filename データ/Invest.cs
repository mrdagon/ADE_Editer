using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE_Editer
{
    //投資
    public class Invest
    {
        static public List<Invest> data = new List<Invest>();

        public string 名前 = "";
        public string 説明 = "";

        public int 部門ID;
        public int ランク;
        public int 費用;

        public int[] 素材種 = new int[4];
        public int[] 素材数 = new int[4];
        public int[] 素材ランク = new int[4];

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

            Eq.Set(form.textBox投資名前, ref 名前);
            Eq.Set(form.textBox投資説明, ref 説明);

            Eq.Set(form.num投資部門ID, ref 部門ID);
            Eq.Set(form.trackbar投資ランク, ref ランク);
            Eq.Set(form.num投資必要数1, ref 費用);

            Eq.Set(form.comboBox投資費用素材種1, ref 素材種[0]);
            Eq.Set(form.num投資必要数1, ref 素材数[0]);
            Eq.Set(form.Trackbar投資素材ランク1, ref 素材ランク[0]);

            Eq.Set(form.comboBox投資費用素材種2, ref 素材種[1]);
            Eq.Set(form.num投資必要数2, ref 素材数[1]);
            Eq.Set(form.Trackbar投資素材ランク2, ref 素材ランク[1]);

            Eq.Set(form.comboBox投資費用素材種3, ref 素材種[2]);
            Eq.Set(form.num投資必要数3, ref 素材数[2]);
            Eq.Set(form.Trackbar投資素材ランク3, ref 素材ランク[2]);

            Eq.Set(form.comboBox投資費用素材種4, ref 素材種[3]);
            Eq.Set(form.num投資必要数4, ref 素材数[3]);
            Eq.Set(form.Trackbar投資素材ランク4, ref 素材ランク[3]);
        }

        private void Save(StreamWriter sw_str, BinaryWriter bw_data)
        {
            //文字とそれ以外は別ファイルに保存
            sw_str.WriteLine(名前 + CV.区切りSave + 説明.Replace("\r\n",CV.改行Save));

            RW.ReadWrite(bw_data, ref  部門ID);
            RW.ReadWrite(bw_data, ref  ランク);

            for(int i=0;i<素材種.Length;i++)
            {
                RW.ReadWrite(bw_data, ref 素材種[i]);
                RW.ReadWrite(bw_data, ref 素材数[i]);
                RW.ReadWrite(bw_data, ref 素材ランク[i]);
            }
        }

        private void Load(StreamReader br_str, BinaryReader br_data)
        {
            var strS = br_str.ReadLine().Split(CV.区切りLoad);
            名前 = strS[0];
            説明 = strS[1].Replace( CV.改行Load , "\r\n");

            RW.ReadWrite(br_data, ref 部門ID);
            RW.ReadWrite(br_data, ref ランク);

            for (int i = 0; i < 素材種.Length; i++)
            {
                RW.ReadWrite(br_data, ref 素材種[i]);
                RW.ReadWrite(br_data, ref 素材数[i]);
                RW.ReadWrite(br_data, ref 素材ランク[i]);
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
                data.Add(new Invest());
                data[i].Load(sr, br);
            }

            sr.Close();
            br.Close();
        }

        public Invest Clone()
        {
            var clone = (Invest)this.MemberwiseClone();

            clone.素材種 = new int[4];
            clone.素材数 = new int[4];
            clone.素材ランク = new int[4];

            for(int i=0;i<素材種.Length;i++)
            {
                clone.素材種[i] = 素材種[i];
                clone.素材数[i] = 素材数[i];
                clone.素材ランク[i] = 素材ランク[i];
            }

            return clone;
        }

        static public void Insert(int index)
        {
            data.Insert(index, new Invest());
        }

        static public void Remove(int index)
        {
            data.RemoveAt(index);
        }
    }
}
