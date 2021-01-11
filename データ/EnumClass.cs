using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE_Editer.データ
{
    class EnumClass
    {
        public void Save(StreamWriter sw_str, BinaryWriter bw_data)
        {
            //文字とそれ以外は別ファイルに保存
            //sw_str.WriteLine(名前 + "," + 説明);
        }

        public void Load(StreamReader br_str, BinaryReader br_data)
        {
            var strS = br_str.ReadLine().Split(',');

        }
    }
}
