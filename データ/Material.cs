using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE_Editer
{
    public class Material
    {
        static public List<Material> data = new List<Material>();

        public string 名前 = "";
        public string 説明 = "";

        public int 種類;
        public int ランク;
        public int 値段;
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

            Eq.Set(form.textBox素材名前, ref 名前);
            Eq.Set(form.textBox素材説明, ref 説明);

            Eq.Set(form.comboBox素材種類, ref 種類);
            Eq.Set(form.trackbar素材ランク, ref ランク);
            Eq.Set(form.num素材値段, ref 値段);
        }

        private void Save(StreamWriter sw_str, BinaryWriter bw_data)
        {
            //文字とそれ以外は別ファイルに保存
            sw_str.WriteLine(名前 + "," + 説明);

            RW.ReadWrite(bw_data, ref 種類);
            RW.ReadWrite(bw_data, ref ランク);
            RW.ReadWrite(bw_data, ref 値段);
        }


        private void Load(StreamReader br_str, BinaryReader br_data)
        {
            var strS = br_str.ReadLine().Split(',');
            名前 = strS[0];
            説明 = strS[1];

            RW.ReadWrite(br_data, ref 種類);
            RW.ReadWrite(br_data, ref ランク);
            RW.ReadWrite(br_data, ref 値段);
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
                data.Add(new Material());
                data[i].Load(sr, br);
            }

            sr.Close();
            br.Close();
        }

        public Material Clone()
        {
            return (Material)this.MemberwiseClone();
        }

        static public void Insert(int index)
        {
            data.Insert(index, new Material());
        }

        static public void Remove(int index)
        {
            data.RemoveAt(index);
        }

    }
}
