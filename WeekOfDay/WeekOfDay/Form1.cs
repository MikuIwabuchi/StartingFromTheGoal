using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeekOfDay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //初期化
            DateTime dt = DateTime.Now;
            textBoxYear.Text = (dt.Year).ToString("");
            numericUpDownMonth.Value = dt.Month;
            numericUpDownDay.Value = dt.Day;
            labelDayOfWeek.Text = "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            int Year;
            String Week;

            if (int.TryParse(textBoxYear.Text, out Year) == true)
            {
                int ValM = (int)numericUpDownMonth.Value;
                int ValD = (int)numericUpDownDay.Value;

                if (VaildityJudge(ValM, ValD, Year) == true)
                {
                    Week = WeekOfDayCalc(Year, ValM, ValD);

                    labelDayOfWeek.Text = Week + "です";
                }
                else
                    labelDayOfWeek.Text = "ありえない日付";
                
            }
            else
                labelDayOfWeek.Text = "西暦年エラー";
        }

        //日付妥当性チェック
        //(仮引数)ValM;月　ValD:日 Year:年
        //(返却値)判定結果
        private Boolean VaildityJudge(int ValM,int ValD,int Year)
        {
            Boolean Result = true;
            int[] arrayMonth30 = new int[4] {4,6,9,11};
            var list1 = new List<int>();
            list1.AddRange(arrayMonth30);

            int[] arrayMonth31 = new int[7] {1,3,5,7,8,10,12 };
            var list2 = new List<int>();
            list2.AddRange(arrayMonth31);



            if (29 <= ValD)
            {
                if (ValM == 2 && LeapYearJudge(Year) == true  && 29 == ValD)
                {
                    return Result;
                }
                else
                    if (list1.Contains(ValM) && 30 >= ValD)
                {
                    return Result;
                }
                else
                    if(list2.Contains(ValM) && 30 <= ValD)
                {
                    return Result;
                }
                else
                    Result = false;
                    return Result;
            }
            else
                return Result;
        }


        //閏年判定
        //(仮引数)Year:西暦年
        //(返却値)判定結果  true:閏年　false:閏年ではない
        private Boolean LeapYearJudge(int Year)
        {
            int calcResult4 = Year % 4;
            int calcResult100 = Year % 100;
            int calcResult400 = Year % 400;
            Boolean Result = false;

            if (calcResult4 == 0 && calcResult100 != 0 || calcResult400 == 0)

                Result = true;

            return Result;
        }


        //曜日算出
        //(仮引数)Year:西暦年　ValM:月　ValD:日
        //(返却値)曜日
        private String WeekOfDayCalc(int Year,int ValM,int ValD)
        {
            int w = 0;
            String WeekOfDay;

            //1,2月は前年の13月、14月として計算
            if (ValM == 1)
            {
                ValM = 13;
                Year -= 1;
            }
            if(ValM == 2)
            {
                ValM = 14;
                Year -= 1;
            }

            w = (5*Year/4-Year/100+Year/400+(26*ValM+16)/10+ValD)% 7;

            switch(w)
            {
                case 0:

                    WeekOfDay = "日曜日";
                    return WeekOfDay;

                case 1:

                    WeekOfDay = "月曜日";
                    return WeekOfDay;

                case 2:

                    WeekOfDay = "火曜日";
                    return WeekOfDay;

                case 3:

                    WeekOfDay = "水曜日";
                    return WeekOfDay;

                case 4:

                    WeekOfDay = "木曜日";
                    return WeekOfDay;

                case 5:

                    WeekOfDay = "金曜日";
                    return WeekOfDay;

                case 6:

                    WeekOfDay = "土曜日";
                    return WeekOfDay;

                default:

                    WeekOfDay = "ありえない日付";
                    return WeekOfDay;

            }
        }
    }
}
