using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADE_Editer
{
    public partial class MainForm : Form
    {
        static public MainForm mainForm;

        //現在のタブ
        //現在の各種選択アイテムインデックス

        //各種データ

        static int nowTab = 0;

        static int nowAスキル = 0;
        static int nowPスキル = 0;
        static int nowアクセサリー = 0;
        static int nowダンジョン= 0;
        static int now投資= 0;
        static int now装備品= 0;
        static int nowジョブ= 0;
        static int now素材= 0;
        static int nowモンスター= 0;
        static int nowクエスト = 0;
        static int now強化数 = 0;

        int copyTabIndex = -1;
        int copyItemIndex = -1;

        private void UpdateData(bool isControlUpdate)
        {
            switch (nowTab)
            {
                case 0:
                    ASkill.data[listBoxAスキル.SelectedIndex].Get(this);
                    break;
                case 1:
                    PSkill.data[listBoxPスキル.SelectedIndex].Get(this);
                    break;
                case 2:
                    Job.data[listBoxジョブ.SelectedIndex].Get(this);
                    break;
                case 3:
                    Monster.data[listBoxモンスター.SelectedIndex].Get(this);
                    break;
                case 4:
                    Dungeon.data[listBoxダンジョン.SelectedIndex].Get(this);
                    break;
                case 5:
                    Item.data[listBox装備品.SelectedIndex].Get(this);
                    break;
                case 6:
                    Material.data[listBox素材.SelectedIndex].Get(this);
                    break;
                case 7:
                    Accessory.data[listBoxアクセサリー.SelectedIndex].Get(this);
                    break;
                case 8:
                    Quest.data[listBoxクエスト.SelectedIndex].Get(this);
                    break;
                case 9:
                    Invest.data[listBox投資.SelectedIndex].Get(this);
                    break;
                case 10:
                    //列挙型
                    break;
                default:
                    break;
            }

            if (isControlUpdate) { UpdateComboCheck(); }
        }

        //コンボボックスとリストボックス項目の更新
        private void UpdateComboCheck()
        {
            switch (nowTab)
            {
                case 0:
                    checkedListBoxAスキルスキルタグ.Items.Clear();//スキル系統
                    comboBoxAスキルバフ1.Items.Clear();//バフ効果
                    comboBoxAスキルバフ2.Items.Clear();//バフ効果
                    comboBoxAスキルバフ3.Items.Clear();//バフ効果
                    comboBoxAスキル連続スキル.Items.Clear();//ASkill
                    comboBoxAスキルレアリティ.Items.Clear();//ASkill
                    comboBoxAスキル追加効果1.Items.Clear();//スキル追加効果種
                    comboBoxAスキル追加効果2.Items.Clear();//スキル追加効果種
                    comboBoxAスキル追加効果3.Items.Clear();//スキル追加効果種
                    comboBoxAスキル追加効果4.Items.Clear();//スキル追加効果種
                    comboBoxAスキル追加効果5.Items.Clear();//スキル追加効果種

                    for (int i = 0; i < ASkill.data.Count; i++)
                    {
                        comboBoxAスキル連続スキル.Items.Add(ASkill.data[i].名前);
                    }

                    for (int i = 0; i < MyType.スキル系統.Count; i++)
                    {
                        checkedListBoxAスキルスキルタグ.Items.Add(MyType.スキル系統[i]);//スキル系統
                    }

                    for (int i = 0; i < MyType.スキル追加効果種.Count; i++)
                    {
                        comboBoxAスキル追加効果1.Items.Add(MyType.スキル追加効果種[i]);//スキル追加効果種
                        comboBoxAスキル追加効果2.Items.Add(MyType.スキル追加効果種[i]);//スキル追加効果種
                        comboBoxAスキル追加効果3.Items.Add(MyType.スキル追加効果種[i]);//スキル追加効果種
                        comboBoxAスキル追加効果4.Items.Add(MyType.スキル追加効果種[i]);//スキル追加効果種
                        comboBoxAスキル追加効果5.Items.Add(MyType.スキル追加効果種[i]);//スキル追加効果種
                    }

                    for (int i = 0; i < MyType.バフ効果.Count; i++)
                    {
                        comboBoxAスキルバフ1.Items.Add(MyType.バフ効果[i]);//バフ効果
                        comboBoxAスキルバフ2.Items.Add(MyType.バフ効果[i]);//バフ効果
                        comboBoxAスキルバフ3.Items.Add(MyType.バフ効果[i]);//バフ効果
                    }

                    break;
                case 1:
                    checkedListBoxPスキルスキルタグ.Items.Clear();//スキル系統

                    comboBoxPスキル条件.Items.Clear();//Pスキル条件
                    comboBoxPスキルタイミング.Items.Clear();//Pスキルタイミング
                    comboBoxPスキル対象.Items.Clear();//Pスキル対象
                    comboBoxPスキル効果A.Items.Clear();//Pスキル効果
                    comboBoxPスキル効果B.Items.Clear();//Pスキル効果

                    for (int i = 0; i < MyType.スキル系統.Count; i++)
                    {
                        checkedListBoxPスキルスキルタグ.Items.Add(MyType.スキル系統[i]);//スキル系統
                    }

                    for (int i = 0; i < MyType.Pスキルタイミング.Count; i++)
                    {
                        comboBoxPスキルタイミング.Items.Add(MyType.Pスキルタイミング[i]);//Pスキルタイミング

                    }
                    for (int i = 0; i < MyType.Pスキル条件.Count; i++)
                    {
                        comboBoxPスキル条件.Items.Add(MyType.Pスキル条件[i]);//Pスキル条件
                    }

                    for (int i = 0; i < MyType.Pスキル対象.Count; i++)
                    {
                        comboBoxPスキル対象.Items.Add(MyType.Pスキル対象[i]);//Pスキル対象
                    }

                    for (int i = 0; i < MyType.Pスキル効果.Count; i++)
                    {
                        comboBoxPスキル効果A.Items.Add(MyType.Pスキル効果[i]);//Pスキル効果
                        comboBoxPスキル効果B.Items.Add(MyType.Pスキル効果[i]);//Pスキル効果
                    }
                    break;
                case 2:
                    comboBoxジョブ武器種.Items.Clear();//装備種
                    comboBoxジョブ防具種.Items.Clear();//装備種
                    checkedListBoxジョブAスキル.Items.Clear();//ASkill
                    checkedListBoxジョブPスキル.Items.Clear();//PSkill
                    comboBoxジョブキースキル1.Items.Clear();
                    comboBoxジョブキースキル2.Items.Clear();
                    comboBoxジョブキースキル3.Items.Clear();


                    for (int i = 0; i < PSkill.data.Count; i++)
                    {
                        checkedListBoxジョブPスキル.Items.Add(PSkill.data[i].名前);//PSkill
                        comboBoxジョブキースキル1.Items.Add(PSkill.data[i].名前);
                        comboBoxジョブキースキル2.Items.Add(PSkill.data[i].名前);
                        comboBoxジョブキースキル3.Items.Add(PSkill.data[i].名前);
                    }

                    for (int i = 0; i < ASkill.data.Count; i++)
                    {
                        checkedListBoxジョブAスキル.Items.Add(ASkill.data[i].名前);
                    }
                    for (int i = 0; i < MyType.装備種.Count; i++)
                    {
                        comboBoxジョブ武器種.Items.Add(MyType.装備種[i]);//装備種
                        comboBoxジョブ防具種.Items.Add(MyType.装備種[i]);//装備種
                    }
                    break;
                case 3:
                    comboBoxモンスターボスドロップA.Items.Clear();//Accessory
                    comboBoxモンスターボスドロップB.Items.Clear();//Accessory
                    comboBoxモンスター素材種.Items.Clear();//素材種
                    comboBoxモンスターPスキル1.Items.Clear();
                    comboBoxモンスターPスキル2.Items.Clear();
                    comboBoxモンスターPスキル3.Items.Clear();
                    comboBoxモンスターPスキル4.Items.Clear();
                    comboBoxモンスターPスキル5.Items.Clear();
                    comboBoxモンスターPスキル6.Items.Clear();
                    comboBoxモンスターPスキル7.Items.Clear();
                    comboBoxモンスターPスキル8.Items.Clear();
                    comboBoxモンスターAスキル1.Items.Clear();
                    comboBoxモンスターAスキル2.Items.Clear();
                    comboBoxモンスターAスキル3.Items.Clear();
                    comboBoxモンスターAスキル4.Items.Clear();
                    comboBoxモンスターAスキル5.Items.Clear();
                    comboBoxモンスターAスキル6.Items.Clear();
                    comboBoxモンスターAスキル7.Items.Clear();
                    comboBoxモンスターAスキル8.Items.Clear();
                    
                    for (int i = 0; i < Accessory.data.Count; i++)
                    {
                        comboBoxモンスターボスドロップA.Items.Add(Accessory.data[i].名前);//Accessory
                        comboBoxモンスターボスドロップB.Items.Add(Accessory.data[i].名前);//Accessory
                    }

                    for (int i = 0; i < PSkill.data.Count; i++)
                    {
                        comboBoxモンスターPスキル1.Items.Add(PSkill.data[i].名前);
                        comboBoxモンスターPスキル2.Items.Add(PSkill.data[i].名前);
                        comboBoxモンスターPスキル3.Items.Add(PSkill.data[i].名前);
                        comboBoxモンスターPスキル4.Items.Add(PSkill.data[i].名前);
                        comboBoxモンスターPスキル5.Items.Add(PSkill.data[i].名前);
                        comboBoxモンスターPスキル6.Items.Add(PSkill.data[i].名前);
                        comboBoxモンスターPスキル7.Items.Add(PSkill.data[i].名前);
                        comboBoxモンスターPスキル8.Items.Add(PSkill.data[i].名前);
                    }

                    for (int i = 0; i < ASkill.data.Count; i++)
                    {
                        comboBoxモンスターAスキル1.Items.Add(ASkill.data[i].名前);
                        comboBoxモンスターAスキル2.Items.Add(ASkill.data[i].名前);
                        comboBoxモンスターAスキル3.Items.Add(ASkill.data[i].名前);
                        comboBoxモンスターAスキル4.Items.Add(ASkill.data[i].名前);
                        comboBoxモンスターAスキル5.Items.Add(ASkill.data[i].名前);
                        comboBoxモンスターAスキル6.Items.Add(ASkill.data[i].名前);
                        comboBoxモンスターAスキル7.Items.Add(ASkill.data[i].名前);
                        comboBoxモンスターAスキル8.Items.Add(ASkill.data[i].名前);
                    }

                    for (int i = 0; i < MyType.素材種.Count; i++)
                    {
                        comboBoxモンスター素材種.Items.Add(MyType.素材種[i]);
                    }
                    break;
                case 4:
                    comboBoxダンジョンボス1.Items.Clear();//Monster
                    comboBoxダンジョンボス2.Items.Clear();//Monster
                    comboBoxダンジョンボス3.Items.Clear();//Monster
                    comboBoxダンジョンボス4.Items.Clear();//Monster
                    comboBoxダンジョンボス5.Items.Clear();//Monster
                    comboBoxダンジョンボス6.Items.Clear();//Monster

                    comboBoxダンジョンザコ1.Items.Clear();//Monster
                    comboBoxダンジョンザコ2.Items.Clear();//Monster
                    comboBoxダンジョンザコ3.Items.Clear();//Monster
                    comboBoxダンジョンザコ4.Items.Clear();//Monster
                    comboBoxダンジョンザコ5.Items.Clear();//Monster
                    comboBoxダンジョンザコ6.Items.Clear();//Monster

                    comboBoxダンジョン遺物1.Items.Clear();//Accessory
                    comboBoxダンジョン遺物2.Items.Clear();//Accessory
                    comboBoxダンジョン遺物3.Items.Clear();//Accessory
                    comboBoxダンジョン遺物4.Items.Clear();//Accessory
                    comboBoxダンジョン遺物5.Items.Clear();//Accessory
                    comboBoxダンジョン遺物6.Items.Clear();//Accessory
                    for (int i = 0; i < Accessory.data.Count; i++)
                    {
                        comboBoxダンジョン遺物1.Items.Add(Accessory.data[i].名前);//Accessory
                        comboBoxダンジョン遺物2.Items.Add(Accessory.data[i].名前);//Accessory
                        comboBoxダンジョン遺物3.Items.Add(Accessory.data[i].名前);//Accessory
                        comboBoxダンジョン遺物4.Items.Add(Accessory.data[i].名前);//Accessory
                        comboBoxダンジョン遺物5.Items.Add(Accessory.data[i].名前);//Accessory
                        comboBoxダンジョン遺物6.Items.Add(Accessory.data[i].名前);//Accessory
                    }

                    for (int i = 0; i < Monster.data.Count; i++)
                    {
                        comboBoxダンジョンボス1.Items.Add(Monster.data[i].名前);//Monster
                        comboBoxダンジョンボス2.Items.Add(Monster.data[i].名前);//Monster
                        comboBoxダンジョンボス3.Items.Add(Monster.data[i].名前);//Monster
                        comboBoxダンジョンボス4.Items.Add(Monster.data[i].名前);//Monster
                        comboBoxダンジョンボス5.Items.Add(Monster.data[i].名前);//Monster
                        comboBoxダンジョンボス6.Items.Add(Monster.data[i].名前);//Monster
                        comboBoxダンジョンザコ1.Items.Add(Monster.data[i].名前);//Monster
                        comboBoxダンジョンザコ2.Items.Add(Monster.data[i].名前);//Monster
                        comboBoxダンジョンザコ3.Items.Add(Monster.data[i].名前);//Monster
                        comboBoxダンジョンザコ4.Items.Add(Monster.data[i].名前);//Monster
                        comboBoxダンジョンザコ5.Items.Add(Monster.data[i].名前);//Monster
                        comboBoxダンジョンザコ6.Items.Add(Monster.data[i].名前);//Monster
                    }
                    break;
                case 5://装備品
                    comboBox装備品装備種.Items.Clear();//装備種
                    comboBox装備品Pスキル.Items.Clear();//PSkill
                    for (int i = 0; i < MyType.装備種.Count; i++)
                    {
                        comboBox装備品装備種.Items.Add(MyType.装備種[i]);//装備種
                    }
                    for (int i = 0; i < PSkill.data.Count; i++)
                    {
                        comboBox装備品Pスキル.Items.Add(PSkill.data[i].名前);//PSkill
                    }
                    break;
                case 6://素材
                    comboBox素材種類.Items.Clear();//素材種
                    for (int i = 0; i < MyType.素材種.Count; i++)
                    {
                        comboBox素材種類.Items.Add(MyType.素材種[i]);//素材種
                    }
                    break;
                case 7://アクセサリー
                    comboBoxアクセサリーPスキル.Items.Clear();//PSkill
                    for (int i = 0; i < PSkill.data.Count; i++)
                    {
                        comboBoxアクセサリーPスキル.Items.Add(PSkill.data[i].名前);//PSkill
                    }
                    break;
                case 8://クエスト
                    comboBoxクエスト種類.Items.Clear();//クエスト種
                    comboBox開放クエスト.Items.Clear();//Quest
                    comboBoxクエストアクセサリ.Items.Clear();
                    //Quest
                    for (int i = 0; i < MyType.クエスト種.Count; i++)
                    {
                        comboBoxクエスト種類.Items.Add(MyType.クエスト種[i]);//クエスト種
                    }
                    for (int i = 0; i < Quest.data.Count; i++)
                    {
                        comboBox開放クエスト.Items.Add(Quest.data[i].名前);//Quest
                    }
                    for (int i = 0; i < Accessory.data.Count; i++)
                    {
                        comboBoxクエストアクセサリ.Items.Add(Accessory.data[i].名前);
                    }
                    break;
                case 9://投資
                    comboBox投資費用素材種1.Items.Clear();
                    comboBox投資費用素材種2.Items.Clear();
                    comboBox投資費用素材種3.Items.Clear();
                    comboBox投資費用素材種4.Items.Clear();
                    for (int i = 0; i < MyType.素材種.Count; i++)
                    {
                        comboBox投資費用素材種1.Items.Add(MyType.素材種[i]);//素材種
                        comboBox投資費用素材種2.Items.Add(MyType.素材種[i]);//素材種
                        comboBox投資費用素材種3.Items.Add(MyType.素材種[i]);//素材種
                        comboBox投資費用素材種4.Items.Add(MyType.素材種[i]);//素材種
                    }
                    break;
                case 10:
                    //列挙型
                    break;
                case 11:
                    //ここの初期化

                    if(RecipeType.コントロール == null )
                    {
                        RecipeType.コントロール = new List<素材Combobox>();

                        int y = label142.Top;

                        foreach (var itA in MyType.装備種)
                        {
                            y += 30;
                            var cont = new 素材Combobox();

                            RecipeType.コントロール.Add(cont);
                            cont.label1.Text = itA;
                            cont.Left = label142.Location.X - 50;
                            cont.Top = y;
                            this.MainTabControl.TabPages[11].Controls.Add(cont);

                            foreach (var itB in MyType.素材種)
                            {
                                cont.comboBoxMain.Items.Add(itB);
                                cont.comboBoxSub.Items.Add(itB);
                            }
                        }

                        RecipeType.Set(this);
                    }

                    
                    break;
                default:
                    break;
            }

            //ASkill

            //MyType系





        }
        private void コピー()
        {
            copyTabIndex = nowTab;

            switch (nowTab)
            {
                case 0: copyItemIndex = listBoxAスキル.SelectedIndex; break;
                case 1: copyItemIndex = listBoxPスキル.SelectedIndex; break;
                case 2: copyItemIndex = listBoxジョブ.SelectedIndex; break;
                case 3: copyItemIndex = listBoxモンスター.SelectedIndex; break;
                case 4: copyItemIndex = listBoxダンジョン.SelectedIndex; break;
                case 5: copyItemIndex = listBox装備品.SelectedIndex; break;
                case 6: copyItemIndex = listBox素材.SelectedIndex; break;
                case 7: copyItemIndex = listBoxアクセサリー.SelectedIndex; break;
                case 8: copyItemIndex = listBoxクエスト.SelectedIndex; break;
                case 9: copyItemIndex = listBox投資.SelectedIndex; break;
            }
        }

        private void 挿入(bool isUpdate)
        {
            //関連する数値を更新する

            switch (nowTab)
            {
                case 0:
                    ASkill.Insert(listBoxAスキル.SelectedIndex);
                    if (isUpdate) { UpdateComboCheck(); }
                    listBoxAスキル.Items.Insert(listBoxAスキル.SelectedIndex, "New");
                    textBoxAスキル名前.Text = "New";
                    listBoxAスキル.SelectedIndex--;
                    break;
                case 1:
                    PSkill.Insert(listBoxPスキル.SelectedIndex);
                    if (isUpdate) { UpdateComboCheck(); }
                    listBoxPスキル.Items.Insert(listBoxPスキル.SelectedIndex, "New");
                    textBoxPスキル名前.Text = "New";
                    listBoxPスキル.SelectedIndex--;
                    break;
                case 2:
                    Job.Insert(listBoxジョブ.SelectedIndex);
                    if (isUpdate) { UpdateComboCheck(); }
                    listBoxジョブ.Items.Insert(listBoxジョブ.SelectedIndex, "New");
                    textBoxジョブ名前.Text = "New";
                    listBoxジョブ.SelectedIndex--;
                    break;
                case 3:
                    Monster.Insert(listBoxモンスター.SelectedIndex);
                    if (isUpdate) { UpdateComboCheck(); }
                    listBoxモンスター.Items.Insert(listBoxモンスター.SelectedIndex, "New");
                    textBoxモンスター名前.Text = "New";
                    listBoxモンスター.SelectedIndex--;
                    break;
                case 4:
                    Dungeon.Insert(listBoxダンジョン.SelectedIndex);
                    if (isUpdate) { UpdateComboCheck(); }
                    listBoxダンジョン.Items.Insert(listBoxダンジョン.SelectedIndex, "New");
                    textBoxダンジョン名前.Text = "New";
                    listBoxダンジョン.SelectedIndex--;
                    break;
                case 5:
                    Item.Insert(listBox装備品.SelectedIndex);
                    if (isUpdate) { UpdateComboCheck(); }
                    listBox装備品.Items.Insert(listBox装備品.SelectedIndex, "New");
                    textBox装備品名前.Text = "New";
                    listBox装備品.SelectedIndex--;
                    break;
                case 6:
                    Material.Insert(listBox素材.SelectedIndex);
                    if (isUpdate) { UpdateComboCheck(); }
                    listBox素材.Items.Insert(listBox素材.SelectedIndex, "New");
                    textBox素材名前.Text = "New";
                    listBox素材.SelectedIndex--;
                    break;
                case 7:
                    Accessory.Insert(listBoxアクセサリー.SelectedIndex);
                    if (isUpdate) { UpdateComboCheck(); }
                    listBoxアクセサリー.Items.Insert(listBoxアクセサリー.SelectedIndex, "New");
                    textBoxアクセサリー名前.Text = "New";
                    listBoxアクセサリー.SelectedIndex--;
                    break;
                case 8:
                    Quest.Insert(listBoxクエスト.SelectedIndex);
                    if (isUpdate) { UpdateComboCheck(); }
                    listBoxクエスト.Items.Insert(listBoxクエスト.SelectedIndex, "New");
                    textBoxクエスト名前.Text = "New";
                    listBoxクエスト.SelectedIndex--;
                    break;
                case 9:
                    Invest.Insert(listBox投資.SelectedIndex);
                    if (isUpdate) { UpdateComboCheck(); }
                    listBox投資.Items.Insert(listBox投資.SelectedIndex, "New");
                    textBox投資名前.Text = "New";
                    listBox投資.SelectedIndex--;
                    break;
                case 10:
                    listBox列挙型.SelectedIndexChanged -= listBox列挙型_SelectedIndexChanged;

                    if (listBox列挙型.SelectedIndex >= 0)
                    {
                        MyType.Insert(comboBox列挙型.SelectedIndex, listBox列挙型.SelectedIndex);
                        listBox列挙型.Items.Insert(listBox列挙型.SelectedIndex, "New");
                    }
                    else
                    {
                        listBox列挙型.Items.Add("New");
                        listBox列挙型.SelectedIndex = 0;
                        MyType.Insert(comboBox列挙型.SelectedIndex, listBox列挙型.SelectedIndex);
                    }

                    listBox列挙型.SelectedIndexChanged += listBox列挙型_SelectedIndexChanged;
                    break;
            }
        }

        private void 貼り付け()
        {
            if (copyTabIndex != nowTab) { return; }

            //ListBoxの名前を更新して、
            switch (nowTab)
            {
                case 0:
                    listBoxAスキル.SelectedIndexChanged -= listBoxAスキル_SelectedIndexChanged;
                    listBoxAスキル.Items[listBoxAスキル.SelectedIndex] = ASkill.data[copyItemIndex].名前;
                    ASkill.data[nowAスキル] = ASkill.data[copyItemIndex].Clone();
                    ASkill.data[nowAスキル].Set(this);
                    listBoxAスキル.SelectedIndexChanged += listBoxAスキル_SelectedIndexChanged;
                    break;
                case 1:
                    listBoxPスキル.SelectedIndexChanged -= listBoxPスキル_SelectedIndexChanged;
                    listBoxPスキル.Items[listBoxPスキル.SelectedIndex] = PSkill.data[copyItemIndex].名前;
                    PSkill.data[nowPスキル] = PSkill.data[copyItemIndex].Clone();
                    PSkill.data[nowPスキル].Set(this);
                    listBoxPスキル.SelectedIndexChanged += listBoxPスキル_SelectedIndexChanged;
                    break;
                case 2:
                    listBoxジョブ.SelectedIndexChanged -= listBoxジョブ_SelectedIndexChanged;
                    listBoxジョブ.Items[listBoxジョブ.SelectedIndex] = Job.data[copyItemIndex].名前;
                    Job.data[nowジョブ] = Job.data[copyItemIndex].Clone();
                    Job.data[nowジョブ].Set(this);
                    listBoxジョブ.SelectedIndexChanged += listBoxジョブ_SelectedIndexChanged;
                    break;
                case 3:
                    listBoxモンスター.SelectedIndexChanged -= listBoxモンスター_SelectedIndexChanged;
                    listBoxモンスター.Items[listBoxモンスター.SelectedIndex] = Monster.data[copyItemIndex].名前;
                    Monster.data[nowモンスター] = Monster.data[copyItemIndex].Clone();
                    Monster.data[nowモンスター].Set(this);
                    listBoxモンスター.SelectedIndexChanged += listBoxモンスター_SelectedIndexChanged;
                    break;
                case 4:
                    listBoxダンジョン.SelectedIndexChanged -= listBoxダンジョン_SelectedIndexChanged;
                    listBoxダンジョン.Items[listBoxダンジョン.SelectedIndex] = Dungeon.data[copyItemIndex].名前;
                    Dungeon.data[nowダンジョン] = Dungeon.data[copyItemIndex].Clone();
                    Dungeon.data[nowダンジョン].Set(this);
                    listBoxダンジョン.SelectedIndexChanged += listBoxダンジョン_SelectedIndexChanged;
                    break;
                case 5:
                    listBox装備品.SelectedIndexChanged -= listBox装備品_SelectedIndexChanged;
                    listBox装備品.Items[listBox装備品.SelectedIndex] = Item.data[copyItemIndex].名前;
                    Item.data[now装備品] = Item.data[copyItemIndex].Clone();
                    Item.data[now装備品].Set(this);
                    listBox装備品.SelectedIndexChanged += listBox装備品_SelectedIndexChanged;
                    break;
                case 6:
                    listBox素材.SelectedIndexChanged -= listBox素材_SelectedIndexChanged;
                    listBox素材.Items[listBox素材.SelectedIndex] = Material.data[copyItemIndex].名前;
                    Material.data[now素材] = Material.data[copyItemIndex].Clone();
                    Material.data[now素材].Set(this);
                    listBox素材.SelectedIndexChanged += listBox素材_SelectedIndexChanged;
                    break;
                case 7:
                    listBoxアクセサリー.SelectedIndexChanged -= listBoxアクセサリー_SelectedIndexChanged;
                    listBoxアクセサリー.Items[listBoxアクセサリー.SelectedIndex] = Accessory.data[copyItemIndex].名前;
                    Accessory.data[nowアクセサリー] = Accessory.data[copyItemIndex].Clone();
                    Accessory.data[nowアクセサリー].Set(this);
                    listBoxアクセサリー.SelectedIndexChanged += listBoxアクセサリー_SelectedIndexChanged;
                    break;
                case 8:
                    listBoxクエスト.SelectedIndexChanged -= listBoxクエスト_SelectedIndexChanged;
                    listBoxクエスト.Items[listBoxクエスト.SelectedIndex] = Quest.data[copyItemIndex].名前;
                    Quest.data[nowクエスト] = Quest.data[copyItemIndex].Clone();
                    Quest.data[nowクエスト].Set(this);
                    listBoxクエスト.SelectedIndexChanged += listBoxクエスト_SelectedIndexChanged;
                    break;
                case 9:
                    listBox投資.SelectedIndexChanged -= listBox投資_SelectedIndexChanged;
                    listBox投資.Items[listBox投資.SelectedIndex] = Invest.data[copyItemIndex].名前;
                    Invest.data[now投資] = Invest.data[copyItemIndex].Clone();
                    Invest.data[now投資].Set(this);
                    listBox投資.SelectedIndexChanged += listBox投資_SelectedIndexChanged;
                    break;
                case 10:
                    break;
            }
        }

        private void 削除(bool isUpdate)
        {
            switch (nowTab)
            {
                case 0:
                    if (listBoxAスキル.Items.Count <= 1) { break; }

                    ASkill.Remove(nowAスキル);
                    listBoxAスキル.SelectedIndexChanged -= listBoxAスキル_SelectedIndexChanged;
                    listBoxAスキル.Items.RemoveAt(nowAスキル);
                    if (isUpdate) { UpdateComboCheck(); }
                    nowAスキル = Math.Max(0,nowAスキル-1);
                    listBoxAスキル.SelectedIndex = nowAスキル;
                    listBoxAスキル.SelectedIndexChanged += listBoxAスキル_SelectedIndexChanged;
                    ASkill.data[listBoxAスキル.SelectedIndex].Set(this);
                    break;
                case 1:
                    if (listBoxPスキル.Items.Count <= 1) { break; }

                    PSkill.Remove(nowPスキル);
                    listBoxPスキル.SelectedIndexChanged -= listBoxPスキル_SelectedIndexChanged;
                    listBoxPスキル.Items.RemoveAt(nowPスキル);
                    if (isUpdate) { UpdateComboCheck(); }
                    nowPスキル = 0;
                    listBoxPスキル.SelectedIndex = 0;
                    listBoxPスキル.SelectedIndexChanged += listBoxPスキル_SelectedIndexChanged;
                    PSkill.data[0].Set(this);
                    break;
                case 2:
                    if (listBoxジョブ.Items.Count <= 1) { break; }

                    Job.Remove(nowジョブ);
                    listBoxジョブ.SelectedIndexChanged -= listBoxジョブ_SelectedIndexChanged;
                    listBoxジョブ.Items.RemoveAt(nowジョブ);
                    if (isUpdate) { UpdateComboCheck(); }
                    nowジョブ = 0;
                    listBoxジョブ.SelectedIndex = 0;
                    listBoxジョブ.SelectedIndexChanged += listBoxジョブ_SelectedIndexChanged;
                    Job.data[0].Set(this);
                    break;
                case 3:
                    if (listBoxモンスター.Items.Count <= 1) { break; }

                    Monster.Remove(nowモンスター);
                    listBoxモンスター.SelectedIndexChanged -= listBoxモンスター_SelectedIndexChanged;
                    listBoxモンスター.Items.RemoveAt(nowモンスター);
                    if (isUpdate) { UpdateComboCheck(); }
                    nowモンスター = 0;
                    listBoxモンスター.SelectedIndex = 0;
                    listBoxモンスター.SelectedIndexChanged += listBoxモンスター_SelectedIndexChanged;
                    Monster.data[0].Set(this);
                    break;
                case 4:
                    if (listBoxダンジョン.Items.Count <= 1) { break; }

                    Dungeon.Remove(nowダンジョン);
                    listBoxダンジョン.SelectedIndexChanged -= listBoxダンジョン_SelectedIndexChanged;
                    listBoxダンジョン.Items.RemoveAt(nowダンジョン);
                    if (isUpdate) { UpdateComboCheck(); }
                    nowダンジョン = 0;
                    listBoxダンジョン.SelectedIndex = 0;
                    listBoxダンジョン.SelectedIndexChanged += listBoxダンジョン_SelectedIndexChanged;
                    Dungeon.data[0].Set(this);
                    break;
                case 5:
                    if (listBox装備品.Items.Count <= 1) { break; }

                    Item.Remove(now装備品);
                    listBox装備品.SelectedIndexChanged -= listBox装備品_SelectedIndexChanged;
                    listBox装備品.Items.RemoveAt(now装備品);
                    if (isUpdate) { UpdateComboCheck(); }
                    now装備品 = 0;
                    listBox装備品.SelectedIndex = 0;
                    listBox装備品.SelectedIndexChanged += listBox装備品_SelectedIndexChanged;
                    Item.data[0].Set(this);
                    break;
                case 6:
                    if (listBox素材.Items.Count <= 1) { break; }

                    Material.Remove(now素材);
                    listBox素材.SelectedIndexChanged -= listBox素材_SelectedIndexChanged;
                    listBox素材.Items.RemoveAt(now素材);
                    if (isUpdate) { UpdateComboCheck(); }
                    now素材 = 0;
                    listBox素材.SelectedIndex = 0;
                    listBox素材.SelectedIndexChanged += listBox素材_SelectedIndexChanged;
                    Material.data[0].Set(this);
                    break;
                case 7:
                    if (listBoxアクセサリー.Items.Count <= 1) { break; }

                    Accessory.Remove(nowアクセサリー);
                    listBoxアクセサリー.SelectedIndexChanged -= listBoxアクセサリー_SelectedIndexChanged;
                    listBoxアクセサリー.Items.RemoveAt(nowアクセサリー);
                    if (isUpdate) { UpdateComboCheck(); }
                    nowアクセサリー = 0;
                    listBoxアクセサリー.SelectedIndex = 0;
                    listBoxアクセサリー.SelectedIndexChanged += listBoxアクセサリー_SelectedIndexChanged;
                    Accessory.data[0].Set(this);
                    break;
                case 8:
                    if (listBoxクエスト.Items.Count <= 1) { break; }

                    Quest.Remove(nowクエスト);
                    listBoxクエスト.SelectedIndexChanged -= listBoxクエスト_SelectedIndexChanged;
                    listBoxクエスト.Items.RemoveAt(nowクエスト);
                    if (isUpdate) { UpdateComboCheck(); }
                    nowクエスト = 0;
                    listBoxクエスト.SelectedIndex = 0;
                    listBoxクエスト.SelectedIndexChanged += listBoxクエスト_SelectedIndexChanged;
                    Quest.data[0].Set(this);
                    break;
                case 9:
                    if (listBox投資.Items.Count <= 1) { break; }

                    Invest.Remove(now投資);
                    listBox投資.SelectedIndexChanged -= listBox投資_SelectedIndexChanged;
                    listBox投資.Items.RemoveAt(now投資);
                    if (isUpdate) { UpdateComboCheck(); }
                    now投資 = 0;
                    listBox投資.SelectedIndex = 0;
                    listBox投資.SelectedIndexChanged += listBox投資_SelectedIndexChanged;
                    Invest.data[0].Set(this);
                    break;
                case 10:
                    if (listBox列挙型.SelectedIndex < 0 || listBox列挙型.Items.Count <= 1) { break; }

                    MyType.Delete(comboBox列挙型.SelectedIndex, listBox列挙型.SelectedIndex);
                    listBox列挙型.SelectedIndexChanged -= listBox列挙型_SelectedIndexChanged;
                    listBox列挙型.Items.RemoveAt(listBox列挙型.SelectedIndex);
                    listBox列挙型.SelectedIndexChanged += listBox列挙型_SelectedIndexChanged;
                    listBox列挙型.SelectedIndex = 0;
                    break;
            }

        }

        private void listBoxShortCut(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Control == true)
            {
                //クリップボードからテキスト取得
                貼り付け();
            }
            if (e.KeyCode == Keys.C && e.Control == true)
            {
                //クリップボードからテキスト取得
                コピー();
            }
            if (e.KeyCode == Keys.D && e.Control == true)
            {
                //クリップボードからテキスト取得
                削除(false);
            }
            if (e.KeyCode == Keys.I && e.Control == true)
            {
                //クリップボードからテキスト取得
                挿入(false);
            }
        }


        //●自動生成関数
        public MainForm()
        {
            InitializeComponent();
            mainForm = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //サイズを固定にする
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //起動時のロード処理
            //ダミーデータ一つづつ作成
            if (false)
            {
                var cd = System.Environment.CurrentDirectory + "/data/";

                MyType.Load(cd + "type");

                ASkill.data.Add(new ASkill());
                PSkill.data.Add(new PSkill());
                Accessory.data.Add(new Accessory());
                Dungeon.data.Add(new Dungeon());
                Invest.data.Add(new Invest());
                Item.data.Add(new Item());
                Job.data.Add(new Job());
                Material.data.Add(new Material());
                Monster.data.Add(new Monster());
                Quest.data.Add(new Quest());

                listBoxAスキル.Items.Add("ダミー");
                listBoxPスキル.Items.Add("ダミー");
                listBoxアクセサリー.Items.Add("ダミー");
                listBoxクエスト.Items.Add("ダミー");
                listBoxジョブ.Items.Add("ダミー");
                listBoxダンジョン.Items.Add("ダミー");
                listBoxモンスター.Items.Add("ダミー");
                listBox投資.Items.Add("ダミー");
                listBox素材.Items.Add("ダミー");
                listBox装備品.Items.Add("ダミー");

                listBoxAスキル.SelectedIndex = 0;
                listBoxPスキル.SelectedIndex = 0;
                listBoxアクセサリー.SelectedIndex = 0;
                listBoxクエスト.SelectedIndex = 0;
                listBoxジョブ.SelectedIndex = 0;
                listBoxダンジョン.SelectedIndex = 0;
                listBoxモンスター.SelectedIndex = 0;
                listBox投資.SelectedIndex = 0;
                listBox素材.SelectedIndex = 0;
                listBox装備品.SelectedIndex = 0;

                comboBox列挙型.SelectedIndex = 0;

                UpdateComboCheck();
                return;
            }

            LoadData();

            for (int i = 0; i < ASkill.data.Count; i++) { listBoxAスキル.Items.Add(ASkill.data[i].名前); }
            for(int i = 0; i < PSkill.data.Count; i++) { listBoxPスキル.Items.Add(PSkill.data[i].名前); }
            for(int i = 0; i < Accessory.data.Count; i++) { listBoxアクセサリー.Items.Add(Accessory.data[i].名前); }
            for(int i = 0; i < Quest.data.Count; i++) { listBoxクエスト.Items.Add(Quest.data[i].名前); }
            for(int i = 0; i < Job.data.Count; i++) { listBoxジョブ.Items.Add(Job.data[i].名前); }
            for(int i = 0; i < Dungeon.data.Count; i++) { listBoxダンジョン.Items.Add(Dungeon.data[i].名前); }
            for(int i = 0; i < Monster.data.Count; i++) { listBoxモンスター.Items.Add(Monster.data[i].名前); }
            for(int i = 0; i < Invest.data.Count; i++) { listBox投資.Items.Add(Invest.data[i].名前); }
            for(int i = 0; i < Material.data.Count; i++) { listBox素材.Items.Add(Material.data[i].名前); }
            for(int i = 0; i < Item.data.Count; i++) { listBox装備品.Items.Add(Item.data[i].名前); }

            UpdateComboCheck();
            ASkill.data[0].Set(this);
            //PSkill.data[0].Set(this);
            //Accessory.data[0].Set(this);
            //Quest.data[0].Set(this);
            //Job.data[0].Set(this);
            //Dungeon.data[0].Set(this);
            //Monster.data[0].Set(this);
            //Invest.data[0].Set(this);
            //Material.data[0].Set(this);
            //Item.data[0].Set(this);

            listBoxAスキル.SelectedIndex = 0;
            //listBoxPスキル.SelectedIndex = 0;
            //listBoxアクセサリー.SelectedIndex = 0;
            //listBoxクエスト.SelectedIndex = 0;
            //listBoxジョブ.SelectedIndex = 0;
            //listBoxダンジョン.SelectedIndex = 0;
            //listBoxモンスター.SelectedIndex = 0;
            //listBox投資.SelectedIndex = 0;
            //listBox素材.SelectedIndex = 0;
            //listBox装備品.SelectedIndex = 0;

            //comboBox列挙型.SelectedIndex = 0;

        }

        //タブ切り替え処理
        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = MainTabControl.SelectedIndex;
            //タブの切り替え処理-起動時には呼ばれない
            //コンボボックスの中身を更新してから処理

            //切り替え前のタブの数値を内部データに代入する
            UpdateData(true);

            nowTab = n;

            UpdateComboCheck();


            //コンボボックスの数値などを入れ直したので再Set
            switch (nowTab)
            {
                case 0:
                    ASkill.data[listBoxAスキル.SelectedIndex].Set(this);
                    break;
                case 1:
                    if (listBoxPスキル.SelectedIndex == -1)
                    {
                        PSkill.data[0].Set(this);
                        listBoxPスキル.SelectedIndex = 0;
                    }
                    PSkill.data[listBoxPスキル.SelectedIndex].Set(this);
                    break;
                case 2:
                    if (listBoxジョブ.SelectedIndex == -1)
                    {
                        Job.data[0].Set(this);
                        listBoxジョブ.SelectedIndex = 0;
                    }
                    Job.data[listBoxジョブ.SelectedIndex].Set(this);
                    break;
                case 3:
                    if (listBoxモンスター.SelectedIndex == -1)
                    {
                        Monster.data[0].Set(this);
                        listBoxモンスター.SelectedIndex = 0;
                    }
                    Monster.data[listBoxモンスター.SelectedIndex].Set(this);
                    break;
                case 4:
                    if (listBoxダンジョン.SelectedIndex == -1)
                    {
                        Dungeon.data[0].Set(this);
                        listBoxダンジョン.SelectedIndex = 0;
                    }
                    Dungeon.data[listBoxダンジョン.SelectedIndex].Set(this);
                    break;
                case 5://装備品
                    if (listBox装備品.SelectedIndex == -1)
                    {
                        Item.data[0].Set(this);
                        listBox装備品.SelectedIndex = 0;
                    }
                    Item.data[listBox装備品.SelectedIndex].Set(this);
                    break;
                case 6:
                    if (listBox素材.SelectedIndex == -1)
                    {
                        Material.data[0].Set(this);
                        listBox素材.SelectedIndex = 0;
                    }
                    Material.data[listBox素材.SelectedIndex].Set(this);
                    break;
                case 7:
                    if (listBoxアクセサリー.SelectedIndex == -1)
                    {
                        Accessory.data[0].Set(this);
                        listBoxアクセサリー.SelectedIndex = 0;
                    }
                    Accessory.data[listBoxアクセサリー.SelectedIndex].Set(this);
                    break;
                case 8:
                    if (listBoxクエスト.SelectedIndex == -1)
                    {
                        Quest.data[0].Set(this);
                        listBoxクエスト.SelectedIndex = 0;
                    }
                    Quest.data[listBoxクエスト.SelectedIndex].Set(this);
                    break;
                case 9:
                    if (listBox投資.SelectedIndex == -1)
                    {
                        Invest.data[0].Set(this);
                        listBox投資.SelectedIndex = 0;
                    }
                    Invest.data[listBox投資.SelectedIndex].Set(this);
                    break;
                case 10:
                    //列挙型
                    break;
                case 11:
                    //強化要求                    
                    if (listBox強化要求素材数.SelectedIndex == -1)
                    {
                        RecipeNumber.data[0].Set(this);
                        listBox強化要求素材数.SelectedIndex = 0;
                    }
                    RecipeNumber.data[listBox強化要求素材数.SelectedIndex].Set(this);
                    break;
                default:
                    break;
            }
        }

        //ボタンクリック処理
        private void buttonコピー_Click(object sender, EventArgs e)
        {
            コピー();
        }

        private void button挿入_Click(object sender, EventArgs e)
        {
            挿入(false);
        }

        private void button貼り付け_Click(object sender, EventArgs e)
        {
            貼り付け();
        }

        private void button削除_Click(object sender, EventArgs e)
        {
            //残り一個は削除不可
            削除(false);
        }

        private void button保存_Click(object sender, EventArgs e)
        {
            UpdateData(false);
            var cd = System.Environment.CurrentDirectory + "/data/";

            //保存処理
            MyType.Save(cd + "type");

            ASkill.Save(cd + "askill");
            PSkill.Save(cd + "pskill");
            Accessory.Save(cd + "accessory");
            Dungeon.Save(cd + "dungeon");
            Invest.Save(cd + "invest");
            Item.Save(cd + "item");
            Job.Save(cd + "job");
            Material.Save(cd + "material");
            Monster.Save(cd + "monster");
            Quest.Save(cd + "quest");

            RecipeNumber.Save(cd + "request_number");
            RecipeType.Save(cd + "request_type");

            //日付時間分のフォルダ作成してバックアップも保存
            DateTime dt = DateTime.Now;
            string ntStr = dt.ToString("yyyyMMddHHmm");

            cd += ntStr;
            Directory.CreateDirectory(cd);
            cd += "/";
            MyType.Save(cd + "type");

            ASkill.Save(cd + "askill");
            PSkill.Save(cd + "pskill");
            Accessory.Save(cd + "accessory");
            Dungeon.Save(cd + "dungeon");
            Invest.Save(cd + "invest");
            Item.Save(cd + "item");
            Job.Save(cd + "job");
            Material.Save(cd + "material");
            Monster.Save(cd + "monster");
            Quest.Save(cd + "quest");

            RecipeNumber.Save(cd + "request_number");
            RecipeType.Save(cd + "request_type");
        }

        private void LoadData()
        {
            var cd = System.Environment.CurrentDirectory + "/data/";

            MyType.Load(cd + "type");//スキル系統が必要なので先ロード

            ASkill.Load(cd + "askill");//MonsterJobより先にロード
            PSkill.Load(cd + "pskill");
            Accessory.Load(cd + "accessory");
            Dungeon.Load(cd + "dungeon");
            Invest.Load(cd + "invest");
            Item.Load(cd + "item");
            Job.Load(cd + "job");
            Material.Load(cd + "material");
            Monster.Load(cd + "monster");
            Quest.Load(cd + "quest");


            RecipeNumber.Load(cd + "request_number");
            RecipeType.Load(cd + "request_type");

        }

        //リストボックス変更処理
        private void listBoxAスキル_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = listBoxAスキル.SelectedIndex;

            if( n == -1)
            {
                listBoxAスキル.SelectedIndex = 0;
                return;
            }

            //一旦変更イベントを止めてリストを更新
            listBoxAスキル.SelectedIndexChanged -= listBoxAスキル_SelectedIndexChanged;
            listBoxAスキル.Items[nowAスキル] = textBoxAスキル名前.Text;
            listBoxAスキル.SelectedIndexChanged += listBoxAスキル_SelectedIndexChanged;

            ASkill.data[nowAスキル].Get(this);
            ASkill.data[n].Set(this);

            nowAスキル = n;
        }

        private void listBoxPスキル_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = listBoxPスキル.SelectedIndex;

            if( n == -1)
            {
                listBoxPスキル.SelectedIndex = 0;
            }

            listBoxPスキル.SelectedIndexChanged -= listBoxPスキル_SelectedIndexChanged;
            listBoxPスキル.Items[nowPスキル] = textBoxPスキル名前.Text;
            listBoxPスキル.SelectedIndexChanged += listBoxPスキル_SelectedIndexChanged;

            PSkill.data[nowPスキル].Get(this);
            PSkill.data[n].Set(this);

            nowPスキル = n;
        }

        private void listBoxジョブ_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = listBoxジョブ.SelectedIndex;

            if (n == -1)
            {
                listBoxジョブ.SelectedIndex = 0;
            }

            listBoxジョブ.SelectedIndexChanged -= listBoxジョブ_SelectedIndexChanged;
            listBoxジョブ.Items[nowジョブ] = textBoxジョブ名前.Text;
            listBoxジョブ.SelectedIndexChanged += listBoxジョブ_SelectedIndexChanged;

            Job.data[nowジョブ].Get(this);
            Job.data[n].Set(this);

            nowジョブ = n;
        }

        private void listBoxモンスター_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = listBoxモンスター.SelectedIndex;

            if (n == -1)
            {
                listBoxモンスター.SelectedIndex = 0;
            }

            listBoxモンスター.SelectedIndexChanged -= listBoxモンスター_SelectedIndexChanged;
            listBoxモンスター.Items[nowモンスター] = textBoxモンスター名前.Text;
            listBoxモンスター.SelectedIndexChanged += listBoxモンスター_SelectedIndexChanged;

            Monster.data[nowモンスター].Get(this);
            Monster.data[n].Set(this);

            nowモンスター = n;
        }

        private void listBoxダンジョン_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = listBoxダンジョン.SelectedIndex;

            if (n == -1)
            {
                listBoxダンジョン.SelectedIndex = 0;
            }

            listBoxダンジョン.SelectedIndexChanged -= listBoxダンジョン_SelectedIndexChanged;
            listBoxダンジョン.Items[nowダンジョン] = textBoxダンジョン名前.Text;
            listBoxダンジョン.SelectedIndexChanged += listBoxダンジョン_SelectedIndexChanged;

            Dungeon.data[nowダンジョン].Get(this);
            Dungeon.data[n].Set(this);

            nowダンジョン = n;
        }

        private void listBox装備品_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = listBox装備品.SelectedIndex;

            if (n == -1)
            {
                listBox装備品.SelectedIndex = 0;
            }

            listBox装備品.SelectedIndexChanged -= listBox装備品_SelectedIndexChanged;
            listBox装備品.Items[now装備品] = textBox装備品名前.Text;
            listBox装備品.SelectedIndexChanged += listBox装備品_SelectedIndexChanged;

            Item.data[now装備品].Get(this);
            Item.data[n].Set(this);

            now装備品 = n;
        }

        private void listBox素材_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = listBox素材.SelectedIndex;

            if (n == -1)
            {
                listBox素材.SelectedIndex = 0;
            }

            listBox素材.SelectedIndexChanged -= listBox素材_SelectedIndexChanged;
            listBox素材.Items[now素材] = textBox素材名前.Text;
            listBox素材.SelectedIndexChanged += listBox素材_SelectedIndexChanged;

            Material.data[now素材].Get(this);
            Material.data[n].Set(this);

            now素材 = n;
        }

        private void listBoxアクセサリー_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = listBoxアクセサリー.SelectedIndex;

            if (n == -1)
            {
                listBoxアクセサリー.SelectedIndex = 0;
            }

            listBoxアクセサリー.SelectedIndexChanged -= listBoxアクセサリー_SelectedIndexChanged;
            listBoxアクセサリー.Items[nowアクセサリー] = textBoxアクセサリー名前.Text;
            listBoxアクセサリー.SelectedIndexChanged += listBoxアクセサリー_SelectedIndexChanged;

            Accessory.data[nowアクセサリー].Get(this);
            Accessory.data[n].Set(this);

            nowアクセサリー = n;
        }

        private void listBoxクエスト_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = listBoxクエスト.SelectedIndex;

            if (n == -1)
            {
                listBoxクエスト.SelectedIndex = 0;
            }

            listBoxクエスト.SelectedIndexChanged -= listBoxクエスト_SelectedIndexChanged;
            listBoxクエスト.Items[nowクエスト] = textBoxクエスト名前.Text;
            listBoxクエスト.SelectedIndexChanged += listBoxクエスト_SelectedIndexChanged;

            Quest.data[nowクエスト].Get(this);
            Quest.data[n].Set(this);

            nowクエスト = n;
        }

        private void listBox投資_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = listBox投資.SelectedIndex;

            if (n == -1)
            {
                listBox投資.SelectedIndex = 0;
            }

            listBox投資.SelectedIndexChanged -= listBox投資_SelectedIndexChanged;
            listBox投資.Items[now投資] = textBox投資名前.Text;
            listBox投資.SelectedIndexChanged += listBox投資_SelectedIndexChanged;

            Invest.data[now投資].Get(this);
            Invest.data[n].Set(this);

            now投資 = n;
        }

        //列挙型
        private void listBox列挙型_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox列挙型名前.TextChanged -= textBox列挙型名前_TextChanged;
            textBox列挙型名前.Text = listBox列挙型.SelectedItem.ToString();
            textBox列挙型名前.TextChanged += textBox列挙型名前_TextChanged;
        }

        private void comboBox列挙型_SelectedIndexChanged(object sender, EventArgs e)
        {
            //UIの更新
            listBox列挙型.SelectedIndexChanged -= listBox列挙型_SelectedIndexChanged;
            listBox列挙型.Items.Clear();

            List<string> list = null;

            switch (comboBox列挙型.SelectedIndex)
            {
                case 0:list = MyType.スキル系統; break;
                case 1: list = MyType.Pスキルタイミング; break;
                case 2: list = MyType.Pスキル条件; break;
                case 3: list = MyType.Pスキル対象; break;
                case 4: list = MyType.Pスキル効果; break;
                case 5: list = MyType.スキル追加効果種; break;
                case 6: list = MyType.バフ効果; break;
                case 7: list = MyType.装備種; break;
                case 8: list = MyType.クエスト種; break;
                case 9: list = MyType.素材種; break;
                default:
                    return;
            }

            for(int i=0; i < list.Count(); i++)
            {
                listBox列挙型.Items.Add(list[i]);
            }


            listBox列挙型.SelectedIndexChanged += listBox列挙型_SelectedIndexChanged;
        }

        private void textBox列挙型名前_TextChanged(object sender, EventArgs e)
        {
            if(listBox列挙型.SelectedIndex < 0) { return; }

            listBox列挙型.SelectedIndexChanged -= listBox列挙型_SelectedIndexChanged;
            listBox列挙型.Items[listBox列挙型.SelectedIndex] = textBox列挙型名前.Text;

            MyType.Set(textBox列挙型名前.Text, comboBox列挙型.SelectedIndex, listBox列挙型.SelectedIndex);

            listBox列挙型.SelectedIndexChanged += listBox列挙型_SelectedIndexChanged;
        }

        //全チェックボックスとコンボボックスの更新

        private void Tab列挙型_Click(object sender, EventArgs e)
        {

        }

        private void TabPスキル_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void MainTabControl_KeyDown(object sender, KeyEventArgs e)
        {
            //listBoxShortCut(sender, e);
        }

        private void listBoxAスキル_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxAスキル説明.Focused ) { return; }
            if (textBoxAスキル名前.Focused ) { return; }

            listBoxShortCut(sender, e);
        }


        private void listBoxPスキル_KeyDown(object sender, KeyEventArgs e)
        {
            if( textBoxPスキル名前.Focused) { return; }
            if( textBoxPスキル説明.Focused) { return; }

            listBoxShortCut(sender, e);
        }
        private void listBoxジョブ_KeyDown(object sender, KeyEventArgs e)
        {
            if( textBoxジョブ名前.Focused ) { return; }
            if( textBoxジョブ説明.Focused ) { return; }

            listBoxShortCut(sender, e);
        }

        private void listBoxモンスター_KeyDown(object sender, KeyEventArgs e)
        {
            if(textBoxモンスター名前.Focused) { return; }
            if (textBoxモンスター説明.Focused) { return; }

            listBoxShortCut(sender, e);
        }

        private void listBoxダンジョン_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxダンジョン名前.Focused) { return; }
            if (textBoxダンジョン説明.Focused) { return; }

            listBoxShortCut(sender, e);
        }

        private void listBoxアクセサリー_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxアクセサリー名前.Focused) { return; }
            if (textBoxアクセサリー説明.Focused) { return; }

            listBoxShortCut(sender, e);
        }

        private void listBox装備品_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox装備品名前.Focused) { return; }
            if (textBox装備品説明.Focused) { return; }

            if (listBox装備品.Focused)
            {
                listBoxShortCut(sender, e);
            }
        }

        private void listBox素材_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox素材名前.Focused) { return; }
            if (textBox素材説明.Focused) { return; }



            listBoxShortCut(sender, e);
        }

        private void listBoxクエスト_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxクエスト名前.Focused) { return; }
            if (textBoxクエスト説明.Focused) { return; }
            listBoxShortCut(sender, e);
        }

        private void listBox投資_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox投資名前.Focused) { return; }
            if (textBox投資説明.Focused) { return; }
            listBoxShortCut(sender, e);
        }

        private void listBox強化要求素材数_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = listBox強化要求素材数.SelectedIndex;

            if (n == -1)
            {
                listBox強化要求素材数.SelectedIndex = 0;
            }

            RecipeNumber.data[now強化数].Get(this);
            RecipeNumber.data[n].Set(this);

            now強化数 = n;
        }
    }
}
