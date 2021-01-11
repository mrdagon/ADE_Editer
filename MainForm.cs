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

        int copyTabIndex = -1;
        int copyItemIndex = -1;


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

        }

        //タブ切り替え処理
        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = MainTabControl.SelectedIndex;
            //タブの切り替え処理-起動時には呼ばれない
            //コンボボックスの中身を更新してから処理

            //切り替え前のタブの数値を内部データに代入する
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
                    Item.data[listBoxモンスター.SelectedIndex].Get(this);
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

            UpdateComboCheck();
            nowTab = n;

            //コンボボックスの数値などを入れ直したので再Set
            switch (nowTab)
            {
                case 0:
                    ASkill.data[listBoxAスキル.SelectedIndex].Set(this);
                    break;
                case 1:
                    PSkill.data[listBoxPスキル.SelectedIndex].Set(this);
                    break;
                case 2:
                    Job.data[listBoxジョブ.SelectedIndex].Set(this);
                    break;
                case 3:
                    Monster.data[listBoxモンスター.SelectedIndex].Set(this);
                    break;
                case 4:
                    Dungeon.data[listBoxダンジョン.SelectedIndex].Set(this);
                    break;
                case 5:
                    Item.data[listBoxモンスター.SelectedIndex].Set(this);
                    break;
                case 6:
                    Material.data[listBox素材.SelectedIndex].Set(this);
                    break;
                case 7:
                    Accessory.data[listBoxアクセサリー.SelectedIndex].Set(this);
                    break;
                case 8:
                    Quest.data[listBoxクエスト.SelectedIndex].Set(this);
                    break;
                case 9:
                    Invest.data[listBox投資.SelectedIndex].Set(this);
                    break;
                case 10:
                    //列挙型
                    break;
                default:
                    break;
            }
        }

        //ボタンクリック処理
        private void buttonコピー_Click(object sender, EventArgs e)
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

        private void button挿入_Click(object sender, EventArgs e)
        {
            //関連する数値を更新する

            switch (nowTab)
            {
                case 0:
                    ASkill.Insert(listBoxAスキル.SelectedIndex);
                    UpdateComboCheck();
                    listBoxAスキル.Items.Insert(listBoxAスキル.SelectedIndex, "New");
                    textBoxAスキル名前.Text = "New";
                    listBoxAスキル.SelectedIndex--;
                    break;
                case 1:
                    PSkill.Insert(listBoxPスキル.SelectedIndex);
                    UpdateComboCheck();
                    listBoxPスキル.Items.Insert(listBoxPスキル.SelectedIndex, "New");
                    textBoxPスキル名前.Text = "New";
                    listBoxPスキル.SelectedIndex--;
                    break;
                case 2:
                    Job.Insert(listBoxジョブ.SelectedIndex);
                    UpdateComboCheck();
                    listBoxジョブ.Items.Insert(listBoxジョブ.SelectedIndex, "New");
                    textBoxジョブ名前.Text = "New";
                    listBoxジョブ.SelectedIndex--;
                    break;
                case 3:
                    Monster.Insert(listBoxモンスター.SelectedIndex);
                    UpdateComboCheck();
                    listBoxモンスター.Items.Insert(listBoxモンスター.SelectedIndex, "New");
                    textBoxモンスター名前.Text = "New";
                    listBoxモンスター.SelectedIndex--;
                    break;
                case 4:
                    Dungeon.Insert(listBoxダンジョン.SelectedIndex);
                    UpdateComboCheck();
                    listBoxダンジョン.Items.Insert(listBoxダンジョン.SelectedIndex, "New");
                    textBoxダンジョン名前.Text = "New";
                    listBoxダンジョン.SelectedIndex--;
                    break;
                case 5:
                    Item.Insert(listBox装備品.SelectedIndex);
                    UpdateComboCheck();
                    listBox装備品.Items.Insert(listBox装備品.SelectedIndex, "New");
                    textBox装備品名前.Text = "New";
                    listBox装備品.SelectedIndex--;
                    break;
                case 6:
                    Material.Insert(listBox素材.SelectedIndex);
                    UpdateComboCheck();
                    listBox素材.Items.Insert(listBox素材.SelectedIndex, "New");
                    textBox素材名前.Text = "New";
                    listBox素材.SelectedIndex--;
                    break;
                case 7:
                    Accessory.Insert(listBoxアクセサリー.SelectedIndex);
                    UpdateComboCheck();
                    listBoxアクセサリー.Items.Insert(listBoxアクセサリー.SelectedIndex, "New");
                    textBoxアクセサリー名前.Text = "New";
                    listBoxアクセサリー.SelectedIndex--;
                    break;
                case 8:
                    Quest.Insert(listBoxクエスト.SelectedIndex);
                    UpdateComboCheck();
                    listBoxクエスト.Items.Insert(listBoxクエスト.SelectedIndex, "New");
                    textBoxクエスト名前.Text = "New";
                    listBoxクエスト.SelectedIndex--;
                    break;
                case 9:
                    Invest.Insert(listBox投資.SelectedIndex);
                    UpdateComboCheck();
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

        private void button貼り付け_Click(object sender, EventArgs e)
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

        private void button削除_Click(object sender, EventArgs e)
        {
            //残り一個は削除不可

            switch (nowTab)
            {
                case 0:
                    if (listBoxAスキル.Items.Count <= 1) { break; }

                    ASkill.Remove(nowAスキル);
                    listBoxAスキル.SelectedIndexChanged -= listBoxAスキル_SelectedIndexChanged;
                    listBoxAスキル.Items.RemoveAt(nowAスキル);
                    UpdateComboCheck();
                    nowAスキル = 0;
                    listBoxAスキル.SelectedIndex = 0;
                    listBoxAスキル.SelectedIndexChanged += listBoxAスキル_SelectedIndexChanged;
                    ASkill.data[0].Set(this);
                    break;
                case 1:
                    if (listBoxPスキル.Items.Count <= 1) { break; }

                    PSkill.Remove(nowPスキル);
                    listBoxPスキル.SelectedIndexChanged -= listBoxPスキル_SelectedIndexChanged;
                    listBoxPスキル.Items.RemoveAt(nowPスキル);
                    UpdateComboCheck();
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
                    UpdateComboCheck();
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
                    UpdateComboCheck();
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
                    UpdateComboCheck();
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
                    UpdateComboCheck();
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
                    UpdateComboCheck();
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
                    UpdateComboCheck();
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
                    UpdateComboCheck();
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
                    UpdateComboCheck();
                    now投資 = 0;
                    listBox投資.SelectedIndex = 0;
                    listBox投資.SelectedIndexChanged += listBox投資_SelectedIndexChanged;
                    Invest.data[0].Set(this);
                    break;
                case 10:
                    if (listBox列挙型.SelectedIndex< 0 || listBox列挙型.Items.Count <= 1) { break; }

                    MyType.Delete(comboBox列挙型.SelectedIndex, listBox列挙型.SelectedIndex);
                    listBox列挙型.SelectedIndexChanged -= listBox列挙型_SelectedIndexChanged;
                    listBox列挙型.Items.RemoveAt(listBox列挙型.SelectedIndex);
                    listBox列挙型.SelectedIndexChanged += listBox列挙型_SelectedIndexChanged;
                    listBox列挙型.SelectedIndex = 0;
                    break;
            }





        }

        private void button保存_Click(object sender, EventArgs e)
        {
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
            listBox列挙型.SelectedIndexChanged -= listBox列挙型_SelectedIndexChanged;
            listBox列挙型.Items[listBox列挙型.SelectedIndex] = textBox列挙型名前.Text;

            MyType.Set(textBox列挙型名前.Text, comboBox列挙型.SelectedIndex, listBox列挙型.SelectedIndex);

            listBox列挙型.SelectedIndexChanged += listBox列挙型_SelectedIndexChanged;
        }

        //全チェックボックスとコンボボックスの更新
        private void UpdateComboCheck()
        {
            checkedListBoxAスキルスキルタグ.Items.Clear();//スキル系統
            comboBoxAスキルバフ1.Items.Clear();//バフ効果
            comboBoxAスキルバフ2.Items.Clear();//バフ効果
            comboBoxAスキルバフ3.Items.Clear();//バフ効果
            comboBoxAスキル連続スキル.Items.Clear();//ASkill
            comboBoxAスキル前提スキル.Items.Clear();//ASkill
            comboBoxAスキル追加効果1.Items.Clear();//スキル追加効果種
            comboBoxAスキル追加効果2.Items.Clear();//スキル追加効果種
            comboBoxAスキル追加効果3.Items.Clear();//スキル追加効果種
            comboBoxAスキル追加効果4.Items.Clear();//スキル追加効果種
            comboBoxAスキル追加効果5.Items.Clear();//スキル追加効果種

            checkedListBoxPスキルスキルタグ.Items.Clear();//スキル系統

            comboBoxPスキル条件.Items.Clear();//Pスキル条件
            comboBoxPスキルタイミング.Items.Clear();//Pスキルタイミング
            comboBoxPスキル対象.Items.Clear();//Pスキル対象
            comboBoxPスキル効果.Items.Clear();//Pスキル効果
            comboBoxPスキル習得前提Pスキル.Items.Clear();//PSkill

            comboBoxジョブ武器種.Items.Clear();//装備種
            comboBoxジョブ防具種.Items.Clear();//装備種
            checkedListBoxジョブAスキル.Items.Clear();//ASkill
            checkedListBoxジョブPスキル.Items.Clear();//PSkill

            comboBoxモンスターボスドロップ.Items.Clear();//Accessory
            comboBoxモンスター素材種.Items.Clear();//素材種
            checkedListBoxtrackbarモンスターAスキル.Items.Clear();//ASkill
            checkedListBoxtrackbarモンスターPスキル.Items.Clear();//PSkill

            comboBoxダンジョンボス.Items.Clear();//Monster
            comboBoxダンジョンザコ1.Items.Clear();//Monster
            comboBoxダンジョンザコ2.Items.Clear();//Monster
            comboBoxダンジョンザコ3.Items.Clear();//Monster
            comboBoxダンジョンザコ4.Items.Clear();//Monster
            comboBoxダンジョンザコ5.Items.Clear();//Monster

            comboBoxダンジョン遺物1.Items.Clear();//Accessory
            comboBoxダンジョン遺物2.Items.Clear();//Accessory
            comboBoxダンジョン遺物3.Items.Clear();//Accessory
            comboBoxダンジョン遺物4.Items.Clear();//Accessory
            comboBoxダンジョン遺物5.Items.Clear();//Accessory

            comboBox装備品装備種.Items.Clear();//装備種
            comboBox装備品Pスキル.Items.Clear();//PSkill

            comboBox素材種類.Items.Clear();//素材種
            comboBoxアクセサリーPスキル.Items.Clear();//PSkill

            comboBoxクエスト種類.Items.Clear();//クエスト種
            comboBox開放クエスト.Items.Clear();//Quest

            //ASkill
            for (int i = 0; i < ASkill.data.Count; i++)
            {
                comboBoxAスキル連続スキル.Items.Add(ASkill.data[i].名前);
                comboBoxAスキル前提スキル.Items.Add(ASkill.data[i].名前);
                checkedListBoxジョブAスキル.Items.Add(ASkill.data[i].名前);
                checkedListBoxtrackbarモンスターAスキル.Items.Add(ASkill.data[i].名前);
            }

            //PSkill
            for (int i = 0; i < PSkill.data.Count; i++)
            {
                comboBoxPスキル習得前提Pスキル.Items.Add(PSkill.data[i].名前);//PSkill
                checkedListBoxジョブPスキル.Items.Add(PSkill.data[i].名前);//PSkill
                checkedListBoxtrackbarモンスターPスキル.Items.Add(PSkill.data[i].名前);//PSkill
                comboBoxアクセサリーPスキル.Items.Add(PSkill.data[i].名前);//PSkill
                comboBox装備品Pスキル.Items.Add(PSkill.data[i].名前);//PSkill
            }

            //Monster
            for (int i = 0; i < Monster.data.Count; i++)
            {
                comboBoxダンジョンボス.Items.Add(Monster.data[i].名前);//Monster
                comboBoxダンジョンザコ1.Items.Add(Monster.data[i].名前);//Monster
                comboBoxダンジョンザコ2.Items.Add(Monster.data[i].名前);//Monster
                comboBoxダンジョンザコ3.Items.Add(Monster.data[i].名前);//Monster
                comboBoxダンジョンザコ4.Items.Add(Monster.data[i].名前);//Monster
                comboBoxダンジョンザコ5.Items.Add(Monster.data[i].名前);//Monster
            }

            //Accessory
            for ( int i=0 ; i<Accessory.data.Count ; i++)
            {
                comboBoxモンスターボスドロップ.Items.Add(Accessory.data[i].名前);//Accessory
                comboBoxダンジョン遺物1.Items.Add(Accessory.data[i].名前);//Accessory
                comboBoxダンジョン遺物2.Items.Add(Accessory.data[i].名前);//Accessory
                comboBoxダンジョン遺物3.Items.Add(Accessory.data[i].名前);//Accessory
                comboBoxダンジョン遺物4.Items.Add(Accessory.data[i].名前);//Accessory
                comboBoxダンジョン遺物5.Items.Add(Accessory.data[i].名前);//Accessory
            }

            //Quest
            for (int i = 0; i < Quest.data.Count; i++)
            {
                comboBox開放クエスト.Items.Add(Quest.data[i].名前);//Quest
            }

            //MyType系
            for(int i=0;i< MyType.スキル系統.Count;i++)
            {
                checkedListBoxAスキルスキルタグ.Items.Add(MyType.スキル系統[i]);//スキル系統
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
                comboBoxPスキル効果.Items.Add(MyType.Pスキル効果[i]);//Pスキル効果
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

            for (int i = 0; i < MyType.装備種.Count; i++)
            {
                comboBoxジョブ武器種.Items.Add(MyType.装備種[i]);//装備種
                comboBoxジョブ防具種.Items.Add(MyType.装備種[i]);//装備種
                comboBox装備品装備種.Items.Add(MyType.装備種[i]);//装備種
            }

            for (int i = 0; i < MyType.クエスト種.Count; i++)
            {
                comboBoxクエスト種類.Items.Add(MyType.クエスト種[i]);//クエスト種
            }

            for (int i = 0; i < MyType.素材種.Count; i++)
            {
                comboBox素材種類.Items.Add(MyType.素材種[i]);//素材種
            }
        }

        private void Tab列挙型_Click(object sender, EventArgs e)
        {

        }

        private void TabPスキル_Click(object sender, EventArgs e)
        {

        }
    }
}
