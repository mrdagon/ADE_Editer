using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADE_Editer
{
    public class RecipeNumber
    {
        static public List<RecipeNumber> data = new List<RecipeNumber>(50);

        int[] 必要数 = new int[10];

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
            Eq.Set(form.num強化必要1, ref 必要数[0]);
            Eq.Set(form.num強化必要2, ref 必要数[1]);
            Eq.Set(form.num強化必要3, ref 必要数[2]);
            Eq.Set(form.num強化必要4, ref 必要数[3]);
            Eq.Set(form.num強化必要5, ref 必要数[4]);
            Eq.Set(form.num強化必要6, ref 必要数[5]);
            Eq.Set(form.num強化必要7, ref 必要数[6]);
            Eq.Set(form.num強化必要8, ref 必要数[7]);
            Eq.Set(form.num強化必要9, ref 必要数[8]);
            Eq.Set(form.num強化必要10, ref 必要数[9]);
        }

        static public void Save(string fileName)
        {
            var bw = new BinaryWriter(new StreamWriter(fileName + ".dat").BaseStream);

            //データ件数を保存した後データを保存

            bw.Write(data.Count());

            for (int i = 0; i < data.Count(); i++)
            {
                data[i].SaveData(bw);
            }

            bw.Close();
        }

        static public void Load(string fileName)
        {
            for (int i = 0; i < 50; i++)
            {
                data.Add( new RecipeNumber());
            }

            var br = new BinaryReader(new StreamReader(fileName + ".dat").BaseStream);

            int n = br.ReadInt32();

            for (int i = 0; i < n; i++)
            {
                data[i].LoadData(br);
            }

            br.Close();
        }

        private void SaveData(BinaryWriter bw_data)
        {
            //文字とそれ以外は別ファイルに保存
            for(int i=0;i<必要数.Length;i++)
            {
                RW.ReadWrite(bw_data, ref 必要数[i]);
            }

        }

        private void LoadData(BinaryReader br_data)
        {
            for (int i = 0; i < 必要数.Length; i++)
            {
                RW.ReadWrite(br_data, ref 必要数[i]);
            }
        }

    }

    class RecipeType
    {
        static public List<素材Combobox> コントロール = null;
        //とりあえず固定で最大20個まで保存
        static public List<RecipeType> data = new List<RecipeType>(20);

        int メイン素材;
        int サブ素材;

        static public void Set(MainForm form )
        {
            Eq.isSetMode = true;
            for ( int i=0 ; i < コントロール.Count ; i++ )
            {
                Eq.Set(コントロール[i].comboBoxMain, ref data[i].メイン素材);
                Eq.Set(コントロール[i].comboBoxSub, ref data[i].サブ素材);
            }
        }

        //コントロールの数値を取得
        static public void Save(string fileName)
        {
            var bw = new BinaryWriter(new StreamWriter(fileName + ".dat").BaseStream);

            //データ件数を保存した後データを保存

            bw.Write(data.Count());

            for (int i = 0; i < data.Count(); i++)
            {
                data[i].SaveData(bw);
            }

            bw.Close();
        }

        static public void Load(string fileName)
        {
            for (int i = 0; i < 20; i++)
            {
                data.Add( new RecipeType() );
            }

            var br = new BinaryReader(new StreamReader(fileName + ".dat").BaseStream);

            int n = br.ReadInt32();

            for (int i = 0; i < n; i++)
            {
                data[i].LoadData(br);
            }

            br.Close();
        }

        private void SaveData(BinaryWriter bw_data)
        {
            //文字とそれ以外は別ファイルに保存
            RW.ReadWrite(bw_data, ref メイン素材);
            RW.ReadWrite(bw_data, ref サブ素材);
        }

        private void LoadData(BinaryReader br_data)
        {
            RW.ReadWrite(br_data, ref メイン素材);
            RW.ReadWrite(br_data, ref サブ素材);
        }
    }
}