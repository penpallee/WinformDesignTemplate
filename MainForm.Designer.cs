namespace WinformDesignTemplate
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_ExpandOrHide = new System.Windows.Forms.Button();
            this.Btn_Fifth = new System.Windows.Forms.Button();
            this.Btn_Fourth = new System.Windows.Forms.Button();
            this.Btn_First = new System.Windows.Forms.Button();
            this.Btn_Second = new System.Windows.Forms.Button();
            this.Btn_Thrid = new System.Windows.Forms.Button();
            this.TCon_Main = new System.Windows.Forms.TabControl();
            this.TPage_1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_ShowROI2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_ShowROI1 = new System.Windows.Forms.Button();
            this.TPage_2 = new System.Windows.Forms.TabPage();
            this.TPage_3 = new System.Windows.Forms.TabPage();
            this.TPage_4 = new System.Windows.Forms.TabPage();
            this.TPage_5 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.PicBox_Logo = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.TCon_Main.SuspendLayout();
            this.TPage_1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1380, 718);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TCon_Main);
            this.splitContainer1.Size = new System.Drawing.Size(1374, 676);
            this.splitContainer1.SplitterDistance = 128;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.Btn_ExpandOrHide, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Btn_Fifth, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.Btn_Fourth, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.Btn_First, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.Btn_Second, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.Btn_Thrid, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 12;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(128, 676);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // Btn_ExpandOrHide
            // 
            this.Btn_ExpandOrHide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn_ExpandOrHide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_ExpandOrHide.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Btn_ExpandOrHide.FlatAppearance.BorderSize = 3;
            this.Btn_ExpandOrHide.Font = new System.Drawing.Font("Snap ITC", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ExpandOrHide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.Btn_ExpandOrHide.Location = new System.Drawing.Point(3, 3);
            this.Btn_ExpandOrHide.Name = "Btn_ExpandOrHide";
            this.Btn_ExpandOrHide.Size = new System.Drawing.Size(122, 27);
            this.Btn_ExpandOrHide.TabIndex = 7;
            this.Btn_ExpandOrHide.Text = "<<";
            this.Btn_ExpandOrHide.UseVisualStyleBackColor = false;
            this.Btn_ExpandOrHide.Click += new System.EventHandler(this.Btn_ExpandOrHide_Click);
            // 
            // Btn_Fifth
            // 
            this.Btn_Fifth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn_Fifth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Fifth.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Btn_Fifth.FlatAppearance.BorderSize = 2;
            this.Btn_Fifth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Fifth.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Btn_Fifth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.Btn_Fifth.Location = new System.Drawing.Point(3, 472);
            this.Btn_Fifth.Name = "Btn_Fifth";
            this.Btn_Fifth.Size = new System.Drawing.Size(122, 27);
            this.Btn_Fifth.TabIndex = 6;
            this.Btn_Fifth.Text = "Setting";
            this.Btn_Fifth.UseVisualStyleBackColor = false;
            this.Btn_Fifth.Click += new System.EventHandler(this.Btn_Fifth_Click);
            // 
            // Btn_Fourth
            // 
            this.Btn_Fourth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn_Fourth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Fourth.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Btn_Fourth.FlatAppearance.BorderSize = 2;
            this.Btn_Fourth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Fourth.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Btn_Fourth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.Btn_Fourth.Location = new System.Drawing.Point(3, 439);
            this.Btn_Fourth.Name = "Btn_Fourth";
            this.Btn_Fourth.Size = new System.Drawing.Size(122, 27);
            this.Btn_Fourth.TabIndex = 5;
            this.Btn_Fourth.Text = "Result";
            this.Btn_Fourth.UseVisualStyleBackColor = false;
            this.Btn_Fourth.Click += new System.EventHandler(this.Btn_Fourth_Click);
            // 
            // Btn_First
            // 
            this.Btn_First.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn_First.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_First.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Btn_First.FlatAppearance.BorderSize = 3;
            this.Btn_First.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_First.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_First.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.Btn_First.Location = new System.Drawing.Point(3, 340);
            this.Btn_First.Name = "Btn_First";
            this.Btn_First.Size = new System.Drawing.Size(122, 27);
            this.Btn_First.TabIndex = 3;
            this.Btn_First.Text = "Initialize";
            this.Btn_First.UseVisualStyleBackColor = false;
            this.Btn_First.Click += new System.EventHandler(this.Btn_First_Click);
            // 
            // Btn_Second
            // 
            this.Btn_Second.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn_Second.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Second.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Btn_Second.FlatAppearance.BorderSize = 2;
            this.Btn_Second.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Second.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Btn_Second.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.Btn_Second.Location = new System.Drawing.Point(3, 373);
            this.Btn_Second.Name = "Btn_Second";
            this.Btn_Second.Size = new System.Drawing.Size(122, 27);
            this.Btn_Second.TabIndex = 0;
            this.Btn_Second.Text = "Align";
            this.Btn_Second.UseVisualStyleBackColor = false;
            this.Btn_Second.Click += new System.EventHandler(this.Btn_Second_Click);
            // 
            // Btn_Thrid
            // 
            this.Btn_Thrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn_Thrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Thrid.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Btn_Thrid.FlatAppearance.BorderSize = 2;
            this.Btn_Thrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Thrid.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Btn_Thrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.Btn_Thrid.Location = new System.Drawing.Point(3, 406);
            this.Btn_Thrid.Name = "Btn_Thrid";
            this.Btn_Thrid.Size = new System.Drawing.Size(122, 27);
            this.Btn_Thrid.TabIndex = 1;
            this.Btn_Thrid.Text = "Scanning";
            this.Btn_Thrid.UseVisualStyleBackColor = false;
            this.Btn_Thrid.Click += new System.EventHandler(this.Btn_Third_Click);
            // 
            // TCon_Main
            // 
            this.TCon_Main.Controls.Add(this.TPage_1);
            this.TCon_Main.Controls.Add(this.TPage_2);
            this.TCon_Main.Controls.Add(this.TPage_3);
            this.TCon_Main.Controls.Add(this.TPage_4);
            this.TCon_Main.Controls.Add(this.TPage_5);
            this.TCon_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCon_Main.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.TCon_Main.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TCon_Main.ItemSize = new System.Drawing.Size(0, 1);
            this.TCon_Main.Location = new System.Drawing.Point(0, 0);
            this.TCon_Main.Name = "TCon_Main";
            this.TCon_Main.Padding = new System.Drawing.Point(3, 3);
            this.TCon_Main.SelectedIndex = 0;
            this.TCon_Main.Size = new System.Drawing.Size(1242, 676);
            this.TCon_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TCon_Main.TabIndex = 0;
            // 
            // TPage_1
            // 
            this.TPage_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.TPage_1.Controls.Add(this.tableLayoutPanel3);
            this.TPage_1.Location = new System.Drawing.Point(4, 5);
            this.TPage_1.Name = "TPage_1";
            this.TPage_1.Padding = new System.Windows.Forms.Padding(3);
            this.TPage_1.Size = new System.Drawing.Size(1234, 667);
            this.TPage_1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1228, 661);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Controls.Add(this.Btn_ShowROI2, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(614, 528);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(614, 133);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // Btn_ShowROI2
            // 
            this.Btn_ShowROI2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn_ShowROI2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_ShowROI2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Btn_ShowROI2.FlatAppearance.BorderSize = 3;
            this.Btn_ShowROI2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Btn_ShowROI2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ShowROI2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.Btn_ShowROI2.Location = new System.Drawing.Point(2, 2);
            this.Btn_ShowROI2.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_ShowROI2.Name = "Btn_ShowROI2";
            this.Btn_ShowROI2.Size = new System.Drawing.Size(200, 40);
            this.Btn_ShowROI2.TabIndex = 5;
            this.Btn_ShowROI2.Text = "Show_ROI";
            this.Btn_ShowROI2.UseVisualStyleBackColor = false;
            this.Btn_ShowROI2.Click += new System.EventHandler(this.Btn_ShowROI2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(608, 522);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(617, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(608, 522);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.Btn_ShowROI1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 528);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(614, 133);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // Btn_ShowROI1
            // 
            this.Btn_ShowROI1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn_ShowROI1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_ShowROI1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Btn_ShowROI1.FlatAppearance.BorderSize = 3;
            this.Btn_ShowROI1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Btn_ShowROI1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ShowROI1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.Btn_ShowROI1.Location = new System.Drawing.Point(2, 2);
            this.Btn_ShowROI1.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_ShowROI1.Name = "Btn_ShowROI1";
            this.Btn_ShowROI1.Size = new System.Drawing.Size(200, 40);
            this.Btn_ShowROI1.TabIndex = 4;
            this.Btn_ShowROI1.Text = "Show_ROI";
            this.Btn_ShowROI1.UseVisualStyleBackColor = false;
            this.Btn_ShowROI1.Click += new System.EventHandler(this.Btn_ShowROI1_Click);
            // 
            // TPage_2
            // 
            this.TPage_2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.TPage_2.Location = new System.Drawing.Point(4, 5);
            this.TPage_2.Name = "TPage_2";
            this.TPage_2.Padding = new System.Windows.Forms.Padding(3);
            this.TPage_2.Size = new System.Drawing.Size(1234, 667);
            this.TPage_2.TabIndex = 1;
            this.TPage_2.Text = "tabPage2";
            // 
            // TPage_3
            // 
            this.TPage_3.Location = new System.Drawing.Point(4, 5);
            this.TPage_3.Name = "TPage_3";
            this.TPage_3.Size = new System.Drawing.Size(1234, 667);
            this.TPage_3.TabIndex = 2;
            this.TPage_3.Text = "tabPage1";
            this.TPage_3.UseVisualStyleBackColor = true;
            // 
            // TPage_4
            // 
            this.TPage_4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TPage_4.Location = new System.Drawing.Point(4, 5);
            this.TPage_4.Name = "TPage_4";
            this.TPage_4.Size = new System.Drawing.Size(1234, 667);
            this.TPage_4.TabIndex = 3;
            this.TPage_4.Text = "tabPage3";
            // 
            // TPage_5
            // 
            this.TPage_5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.TPage_5.Location = new System.Drawing.Point(4, 5);
            this.TPage_5.Name = "TPage_5";
            this.TPage_5.Size = new System.Drawing.Size(1234, 667);
            this.TPage_5.TabIndex = 4;
            this.TPage_5.Text = "tabPage1";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel6.Controls.Add(this.PicBox_Logo, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 683);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1380, 35);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // PicBox_Logo
            // 
            this.PicBox_Logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBox_Logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicBox_Logo.Image = ((System.Drawing.Image)(resources.GetObject("PicBox_Logo.Image")));
            this.PicBox_Logo.InitialImage = ((System.Drawing.Image)(resources.GetObject("PicBox_Logo.InitialImage")));
            this.PicBox_Logo.Location = new System.Drawing.Point(3, 3);
            this.PicBox_Logo.Name = "PicBox_Logo";
            this.PicBox_Logo.Size = new System.Drawing.Size(147, 29);
            this.PicBox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBox_Logo.TabIndex = 9;
            this.PicBox_Logo.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1380, 718);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Set Title";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.TCon_Main.ResumeLayout(false);
            this.TPage_1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl TCon_Main;
        private System.Windows.Forms.TabPage TPage_1;
        private System.Windows.Forms.TabPage TPage_2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Btn_Second;
        private System.Windows.Forms.Button Btn_Thrid;
        private System.Windows.Forms.TabPage TPage_3;
        private System.Windows.Forms.TabPage TPage_4;
        private System.Windows.Forms.Button Btn_First;
        private System.Windows.Forms.Button Btn_Fifth;
        private System.Windows.Forms.Button Btn_Fourth;
        private System.Windows.Forms.TabPage TPage_5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button Btn_ShowROI1;
        private System.Windows.Forms.Button Btn_ExpandOrHide;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.PictureBox PicBox_Logo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button Btn_ShowROI2;
    }
}

