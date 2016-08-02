using Bll;
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
            //3、创建row，创建一个行 对象
            IRow row = sheet.CreateRow(0);
            //4、创建cell，创建一个单元格 对象
            ICell cell0 = row.CreateCell(0);
            //为新创建的 单元格对象赋值
            cell0.SetCellValue("管理员列表");
            //5、设置合并单元格
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 3));
            //6、设置单元格居中
            ICellStyle styleTitle = workbook.CreateCellStyle();
            styleTitle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;//居中
            cell0.CellStyle = styleTitle;

            //保存工作本
            using (FileStream stream = new FileStream(@"C:\Users\yangf\Desktop\ti.xlsx", FileMode.CreateNew))
            {
                workbook.Write(stream); 
            }
        }
    }
}
