using Bll;
using Model;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
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

namespace UI.test
{
    public partial class NPOITest : Form
    {
        public NPOITest()
        {
            InitializeComponent();
        }

        private void NPOITest_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //查询数据显示到表格上
            ManagerInfoBll miBll = new ManagerInfoBll();
            var list = miBll.GetList();
            dataGridView1.DataSource = list;

            //进行excel生成创建操作
            //1、创建workbook，不指定参数-创建一个新工作本 对象
            IWorkbook workbook = new XSSFWorkbook();
            //2、创建sheet，创建一个名为“管理员”的表格 对象
            ISheet sheet = workbook.CreateSheet("管理员");
            //3、创建row，创建 行 对象
            IRow row0 = sheet.CreateRow(0);
            IRow row1 = sheet.CreateRow(1);
            //4、创建cell，创建 单元格 对象
            ICell cell0_0 = row0.CreateCell(0);
            ICell cell1_0 = row1.CreateCell(0);
            ICell cell1_1 = row1.CreateCell(1);
            ICell cell1_2 = row1.CreateCell(2);
            ICell cell1_3 = row1.CreateCell(3);
            //为新创建的 单元格对象赋值
            cell0_0.SetCellValue("管理员列表");
            cell1_0.SetCellValue("编号");
            cell1_1.SetCellValue("姓名");
            cell1_2.SetCellValue("密码");
            cell1_3.SetCellValue("类型");

            //5、设置合并单元格
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 3));
            //6、设置单元格居中
            //定义居中样式
            ICellStyle styleTitle = workbook.CreateCellStyle();
            styleTitle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            //将样式赋给单元格
            cell0_0.CellStyle = styleTitle;
            cell1_0.CellStyle = styleTitle;
            cell1_1.CellStyle = styleTitle;
            cell1_2.CellStyle = styleTitle;
            cell1_3.CellStyle = styleTitle;

            //7、遍历集合，创建正文数据
            int rowIndex = 2;
            foreach (var mi in list)
            {
                //创建行
                IRow rowData = sheet.CreateRow(rowIndex++);
                //创建数据单元格
                ICell cellData0 = rowData.CreateCell(0);
                cellData0.SetCellValue(mi.Mid);

                ICell cellData1 = rowData.CreateCell(1);
                cellData1.SetCellValue(mi.MName);

                ICell cellData2 = rowData.CreateCell(2);
                cellData2.SetCellValue(mi.MPwd);

                ICell cellData3 = rowData.CreateCell(3);
                cellData3.SetCellValue(mi.Mtype == 1 ? "经理" : "店员");

            }
            //保存工作本
            using (FileStream stream = new FileStream(@"C:\Users\yangf\Desktop\ti.xlsx", FileMode.Create))
            {
                workbook.Write(stream);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1、读取excel数据，存入list中
            List<ManagerInfo> list = new List<ManagerInfo>();
            using (FileStream stream = new FileStream(@"C:\Users\yangf\Desktop\ti.xlsx", FileMode.Open))
            {
                //创建工作簿
                IWorkbook workbook = new XSSFWorkbook(stream);
                //读取
                ISheet sheet = workbook.GetSheet("管理员");
                //读取正文数据，0、1行为标题，直接跳过
                int rowIndex = 2;
                while (sheet.GetRow(rowIndex) != null)
                {
                    IRow rowData = sheet.GetRow(rowIndex++);
                    list.Add(new ManagerInfo()
                    {
                        Mid =(int)rowData.GetCell(0).NumericCellValue,
                        MName = rowData.GetCell(1).StringCellValue,
                        MPwd = rowData.GetCell(2).StringCellValue,
                        Mtype = rowData.GetCell(3).StringCellValue == "经理" ? 1 : 0
                    });
                }
                //将list赋值给datagridview
                dataGridView1.DataSource = list;
            }
        }
    }
}
