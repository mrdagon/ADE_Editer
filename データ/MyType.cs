using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE_Editer
{
    public static class MyType
    {
        public readonly static int Max = 200;

        public static List<string> スキル系統 = new List<string>();
        public static List<string> Pスキルタイミング = new List<string>();
        public static List<string> Pスキル条件 = new List<string>();
        public static List<string> Pスキル対象 = new List<string>();
        public static List<string> Pスキル効果 = new List<string>();
        public static List<string> スキル追加効果種 = new List<string>();
        public static List<string> バフ効果 = new List<string>();
        public static List<string> 装備種 = new List<string>();
        public static List<string> クエスト種 = new List<string>();
        public static List<string> 素材種 = new List<string>();

        //固定タグ
        //Aスキル対象
        //隊列 前-後-両
        //参照ステ 筋力、技力、知力
        //Aスキル補正種
        //Pスキル補正種

        static public void Save(string fileName)
        {
            var sw = new StreamWriter(fileName + ".csv");
            Save(スキル系統, sw);
            Save(Pスキルタイミング,sw);
            Save(Pスキル条件,sw);
            Save(Pスキル対象,sw);
            Save(Pスキル効果,sw);
            Save(スキル追加効果種,sw);
            Save(バフ効果,sw);
            Save(装備種,sw);
            Save(クエスト種,sw);
            Save(素材種,sw);

            sw.Close();
        }

        static public void Load(string fileName)
        {
            var sr = new StreamReader(fileName + ".csv");

            Load(スキル系統, sr);
            Load( Pスキルタイミング,sr);
            Load( Pスキル条件, sr);
            Load( Pスキル対象, sr);
            Load( Pスキル効果, sr);
            Load( スキル追加効果種, sr);
            Load( バフ効果, sr);
            Load( 装備種, sr);
            Load( クエスト種, sr);
            Load( 素材種, sr);

            sr.Close();
        }

        static public void Set(string newName, int comboIndex, int itemIndex)
        {
            switch (comboIndex)
            {
                case 0: スキル系統[itemIndex] = newName;break;
                case 1: Pスキルタイミング[itemIndex] = newName; break;
                case 2: Pスキル条件[itemIndex] = newName; break;
                case 3: Pスキル対象[itemIndex] = newName; break;
                case 4: Pスキル効果[itemIndex] = newName; break;
                case 5: スキル追加効果種[itemIndex] = newName; break;
                case 6: バフ効果[itemIndex] = newName; break;
                case 7: 装備種[itemIndex] = newName; break;
                case 8: クエスト種[itemIndex] = newName; break;
                case 9: 素材種[itemIndex] = newName; break;
            }
        }

        static private void Save( List<string> list , StreamWriter sw)
        {
            //データ数
            if( list.Count() == 0)
            {
                sw.Write(Environment.NewLine);
                return;
            }

            sw.Write(list[0]);

            for( int i=1; i < list.Count(); i++)
            {
                sw.Write("," + list[i]);
            }

            sw.Write(Environment.NewLine);
        }
        static private void Load( List<string> list, StreamReader sr)
        {
            //データ数
            var newList = sr.ReadLine().Split(',');

            for(int i=0; i < newList.Count(); i++)
            {
                list.Add(newList[i]);
            }

        }

        public static void Delete( int comboIndex , int listIndex)
        {
            switch (comboIndex)
            {
                case 0:
                    スキル系統.RemoveAt(listIndex);
                    break;
                case 1:
                    Pスキルタイミング.RemoveAt(listIndex);
                    break;
                case 2:
                    Pスキル条件.RemoveAt(listIndex);
                    break;
                case 3:
                    Pスキル対象.RemoveAt(listIndex);
                    break;
                case 4:
                    Pスキル効果.RemoveAt(listIndex);
                    break;
                case 5:
                    スキル追加効果種.RemoveAt(listIndex);
                    break;
                case 6:
                    バフ効果.RemoveAt(listIndex);
                    break;
                case 7:
                    装備種.RemoveAt(listIndex);
                    break;
                case 8:
                    クエスト種.RemoveAt(listIndex);
                    break;
                case 9:
                    素材種.RemoveAt(listIndex);
                    break;
            }
            InsertRemove(comboIndex, listIndex, -1);
        }
        public static void Insert(int comboIndex, int listIndex)
        {
            if(listIndex < 0)
            {
                listIndex = 0;
            }

            switch (comboIndex)
            {
                case 0:
                    スキル系統.Insert(listIndex,"new");
                    break;
                case 1:
                    Pスキルタイミング.Insert(listIndex, "new");
                    break;
                case 2:
                    Pスキル条件.Insert(listIndex, "new");
                    break;
                case 3:
                    Pスキル対象.Insert(listIndex, "new");
                    break;
                case 4:
                    Pスキル効果.Insert(listIndex, "new");
                    break;
                case 5:
                    スキル追加効果種.Insert(listIndex, "new");
                    break;
                case 6:
                    バフ効果.Insert(listIndex, "new");
                    break;
                case 7:
                    装備種.Insert(listIndex, "new");
                    break;
                case 8:
                    クエスト種.Insert(listIndex, "new");
                    break;
                case 9:
                    素材種.Insert(listIndex, "new");
                    break;
            }
            InsertRemove(comboIndex, listIndex, +1);
        }

        static private void InsertRemove(int comboIndex , int index, int num)
        {
            switch (comboIndex)
            {
                case 0://スキル系統
                    foreach (var it in ASkill.data)
                    {
                        InsertData.Check(ref it.スキルタグ, index, num);
                    }
                    foreach (var it in PSkill.data)
                    {
                        InsertData.Check(ref it.スキルタグ, index, num);                    
                    }
                    break;
                case 1://Pスキルタイミング
                    foreach (var it in PSkill.data)
                    {
                        InsertData.Check(ref it.タイミング, index, num);
                    }
                    break;
                case 2://Pスキル条件
                    foreach (var it in PSkill.data)
                    {
                        InsertData.Check(ref it.条件, index, num);
                    }
                    break;
                case 3://Pスキル対象
                    foreach (var it in PSkill.data)
                    {
                        InsertData.Check(ref it.対象, index, num);
                    }
                    break;
                case 4://Pスキル効果
                    foreach (var it in PSkill.data)
                    {
                        InsertData.Check(ref it.効果, index, num);
                    }
                    break;
                case 5://スキル追加効果種
                    foreach (var it in ASkill.data)
                    {
                        InsertData.Check(ref it.追加効果1, index, num);
                        InsertData.Check(ref it.追加効果2, index, num);
                        InsertData.Check(ref it.追加効果3, index, num);
                        InsertData.Check(ref it.追加効果4, index, num);
                        InsertData.Check(ref it.追加効果5, index, num);
                    }
                    break;
                case 6://バフ効果種
                    foreach (var it in ASkill.data)
                    {
                        InsertData.Check(ref it.バフ種類1, index, num);
                        InsertData.Check(ref it.バフ種類2, index, num);
                        InsertData.Check(ref it.バフ種類3, index, num);
                    }
                    break;
                case 7://装備種
                    foreach (var it in Job.data)
                    {
                        InsertData.Check(ref it.武器種, index, num);
                        InsertData.Check(ref it.防具種, index, num);
                    }
                    foreach (var it in Item.data)
                    {
                        InsertData.Check(ref it.装備種, index, num);
                    }
                    break;
                case 8://クエスト種
                    foreach (var it in Quest.data)
                    {
                        InsertData.Check(ref it.種類, index, num);
                    }
                    break;
                case 9://素材種
                    foreach (var it in Material.data)
                    {
                        InsertData.Check(ref it.種類, index, num);
                    }
                    break;
            }
        }
    }
}
