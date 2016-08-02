namespace UI
{
    partial class FormDIshInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dchar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNameSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtChar = new System.Windows.Forms.TextBox();
            this.ddlTitle = new System.Windows.Forms.ComboBox();
            this.btnTitleSet = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.ddlTitleSearch = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 391);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "列表";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnShowAll);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtNameSearch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ddlTitleSearch);
            this.groupBox2.Location = new System.Drawing.Point(567, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(203, 111);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "搜索";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DId,
            this.DTitle,
            this.DTypeId,
            this.DPrice,
            this.Dchar});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(543, 371);
            this.dataGridView1.TabIndex = 0;
            // 
            // DId
            // 
            this.DId.DataPropertyName = "DId";
            this.DId.HeaderText = "编号";
            this.DId.Name = "DId";
            this.DId.ReadOnly = true;
            // 
            // DTitle
            // 
            this.DTitle.DataPropertyName = "DTitle";
            this.DTitle.HeaderText = "菜品";
            this.DTitle.Name = "DTitle";
            this.DTitle.ReadOnly = true;
            // 
            // DTypeId
            // 
            this.DTypeId.DataPropertyName = "DTypeId";
            this.DTypeId.HeaderText = "菜类";
            this.DTypeId.Name = "DTypeId";
            this.DTypeId.ReadOnly = true;
            // 
            // DPrice
            // 
            this.DPrice.DataPropertyName = "DPrice";
            this.DPrice.HeaderText = "价格";
            this.DPrice.Name = "DPrice";
            this.DPrice.ReadOnly = true;
            // 
            // Dchar
            // 
            this.Dchar.DataPropertyName = "Dchar";
            this.Dchar.HeaderText = "拼音";
            this.Dchar.Name = "Dchar";
            this.Dchar.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名 称：";
            // 
            // txtNameSearch
            // 
            this.txtNameSearch.Location = new System.Drawing.Point(52, 20);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(143, 21);
            this.txtNameSearch.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "分 类：";
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(7, 75);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(188, 23);
            this.btnShowAll.TabIndex = 2;
            this.btnShowAll.Text = "显示全部";
            this.btnShowAll.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnTitleSet);
            this.groupBox3.Controls.Add(this.ddlTitle);
            this.groupBox3.Controls.Add(this.txtChar);
            this.groupBox3.Controls.Add(this.txtName);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtPrice);
            this.groupBox3.Controls.Add(this.txtId);
            this.groupBox3.Location = new System.Drawing.Point(568, 130);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 274);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "添加\\修改";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "编 号：";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(51, 20);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(143, 21);
            this.txtId.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "名 称：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(51, 47);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(143, 21);
            this.txtName.TabIndex = 1;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(52, 130);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(143, 21);
            this.txtPrice.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "拼 音：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "价 格：";
            // 
            // txtChar
            // 
            this.txtChar.Location = new System.Drawing.Point(52, 157);
            this.txtChar.Name = "txtChar";
            this.txtChar.Size = new System.Drawing.Size(143, 21);
            this.txtChar.TabIndex = 1;
            // 
            // ddlTitle
            // 
            this.ddlTitle.FormattingEnabled = true;
            this.ddlTitle.Location = new System.Drawing.Point(52, 75);
            this.ddlTitle.Name = "ddlTitle";
            this.ddlTitle.Size = new System.Drawing.Size(142, 20);
            this.ddlTitle.TabIndex = 2;
            // 
            // btnTitleSet
            // 
            this.btnTitleSet.Location = new System.Drawing.Point(52, 101);
            this.btnTitleSet.Name = "btnTitleSet";
            this.btnTitleSet.Size = new System.Drawing.Size(142, 23);
            this.btnTitleSet.TabIndex = 2;
            this.btnTitleSet.Text = "菜品类型管理";
            this.btnTitleSet.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "分 类：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(7, 184);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "添加";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(106, 184);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(6, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "提示：双击表格项进行修改";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 245);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(188, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "删除选中行数据";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // ddlTitleSearch
            // 
            this.ddlTitleSearch.FormattingEnabled = true;
            this.ddlTitleSearch.Location = new System.Drawing.Point(52, 47);
            this.ddlTitleSearch.Name = "ddlTitleSearch";
            this.ddlTitleSearch.Size = new System.Drawing.Size(142, 20);
            this.ddlTitleSearch.TabIndex = 2;
            // 
            // FormDIshInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 409);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FormDIshInfo";
            this.Text = "菜品管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dchar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNameSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtChar;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox ddlTitleSearch;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTitleSet;
        private System.Windows.Forms.ComboBox ddlTitle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}