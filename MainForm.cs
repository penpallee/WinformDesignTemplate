using Matrox.MatroxImagingLibrary;
using static Matrox.MatroxImagingLibrary.MIL;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using MIL_MODULE;

namespace WinformDesignTemplate
{
    public partial class MainForm : Form
    {
        /*
 MApplication
    |
    MSystem
        |
        |-- Align Page
        |    |
        |    |-- currentAlignModel (Align 데이터 저장 객체)
        |    |
        |    |-- Buffers
        |    |    |-- MBuffer_Align_Src (원본 이미지 Buffer)
        |    |    |-- MBuffer_Align_Display (처리된 이미지 Buffer)
        |    |
        |    |-- Display
        |    |    |-- MDisplay_Align (메인 이미지 Display)
        |    |
        |    |-- Graphiclist
        |         |-- MGraphiclist_Align (메인 이미지 Graphiclist)
        |    |
        |    |-- ROI
        |    |    |-- MILROI_Align_1 (1번 ROI)
        |    |    |-- MILROI_Align_2 (2번 ROI)
        |    |
        |    |-- Pattern
        |         |-- MILPattern_Align_1 (1번 패턴)
        |         |-- MILPattern_Align_2 (2번 패턴)
        |
        |-- LineScanning page
             |
             |-- currentLineScanModel (LineScanning 데이터 저장 객체)
             |
             |-- Buffers
             |    |-- MBuffer_LineScan_Left_Src (왼쪽 원본 이미지 Buffer)
             |    |-- MBuffer_LineScan_Left_Display (왼쪽 처리된 이미지 Buffer)
             |    |-- MBuffer_LineScan_Right_Src (오른쪽 원본 이미지 Buffer)
             |    |-- MBuffer_LineScan_Right_Display (오른쪽 처리된 이미지 Buffer)
             |
             |-- Display
             |    |-- MDisplay_LineScan_Left (왼쪽 이미지 Display)
             |    |-- MDisplay_LineScan_Right (오른쪽 이미지 Display)
             |
             |-- Graphiclist
             |    |-- MGraphiclist_LineScan_Left (왼쪽 이미지 Graphiclist)
             |    |-- MGraphiclist_LineScan_Right (오른쪽 이미지 Graphiclist)
             |
             |-- ROI
             |    |-- MILROI_LineScan_Left (왼쪽 이미지 ROI)
             |    |-- MILROI_LineScan_Right (오른쪽 이미지 ROI)
             |
             |-- Pattern
                  |-- MILPattern_LineScan_Left (왼쪽 패턴)
                  |-- MILPattern_LineScan_Right (오른쪽 패턴)
         */


        #region [Variable]
        // 공동 변수
        MIL_ID MApplication = M_NULL;               
        MIL_ID MSystem = M_NULL;                    

        // 카메라 2개 Align
        AlignModel currentAlignModel;                     // Align page 의 데이터 저장 객체
        MIL_ROI MILROI_Align_1;                           // Align page 의 1번 ROI
        MIL_ROI MILROI_Align_2;                           // Align page 의 2번 ROI
        MIL_PATTERN MILPattern_Align_1;                   // Align page 의 1번 패턴 객채
        MIL_PATTERN MILPattern_Align_2;                   // Align page 의 2번 패턴 객체

        MIL_ID MBuffer_Align_Src = M_NULL;                // Align page 의 original Buffer
        MIL_ID MBuffer_Align_Display = M_NULL;            // Align page 의 output Buffer , MBuffer_OneAlign_Src를 copy해서 processing 후 Display할 buffer

        MIL_ID MDisplay_Align = M_NULL;                   // Align page 의 Display

        MIL_ID MGraphiclist_Align = M_NULL;               // Align page 의 Graphiclist

        // LineScanning
        LineScanModel currentLineScanModel;               // LineScanning 데이터 저장 객체
        MIL_ROI MILROI_LineScan_Left;                     // 왼쪽 이미지 ROI
        MIL_ROI MILROI_LineScan_Right;                    // 오른쪽 이미지 ROI
        MIL_PATTERN MILPattern_LineScan_Left;             // 왼쪽 패턴 객체
        MIL_PATTERN MILPattern_LineScan_Right;            // 오른쪽 패턴 객체

        MIL_ID MBuffer_LineScan_Left_Src = M_NULL;        // 왼쪽 이미지 Buffer
        MIL_ID MBuffer_LineScan_Left_Display = M_NULL;    // 왼쪽 이미지 Buffer
        MIL_ID MBuffer_LineScan_Right_Src = M_NULL;       // 오른쪽 이미지 Buffer
        MIL_ID MBuffer_LineScan_Right_Display = M_NULL;   // 오른쪽 이미지 Buffer

        MIL_ID MDisplay_LineScan_Left = M_NULL;           // 왼쪽 이미지 Display
        MIL_ID MDisplay_LineScan_Right = M_NULL;          // 오른쪽 이미지 Display

        MIL_ID MGraphiclist_LineScan_Left = M_NULL;       // 왼쪽 이미지 Graphiclist
        MIL_ID MGraphiclist_LineScan_Right = M_NULL;      // 오른쪽 이미지 Graphiclist
        #endregion


        public MainForm()
        {
            InitializeComponent();

        }

        private void Btn_First_Click(object sender, EventArgs e)
        {
            TCon_Main.SelectedIndex = 0;
        }

        private void Btn_Second_Click(object sender, EventArgs e)
        {
            TCon_Main.SelectedIndex = 1;
        }

        private void Btn_Third_Click(object sender, EventArgs e)
        {
            TCon_Main.SelectedIndex = 2;
        }

        private void Btn_Fourth_Click(object sender, EventArgs e)
        {
            TCon_Main.SelectedIndex = 3;
        }

        private void Btn_Fifth_Click(object sender, EventArgs e)
        {
            TCon_Main.SelectedIndex = 4;
        }

        private void Btn_ShowROI1_Click(object sender, EventArgs e)
        {
        }

        private void Btn_ShowROI2_Click(object sender, EventArgs e)
        {
        }

        private void Btn_ExpandOrHide_Click(object sender, EventArgs e)
        {
            if (Btn_ExpandOrHide.Text == "<<")
            {
                splitContainer1.SplitterDistance = 30;
                for (int i = this.tableLayoutPanel2.RowStyles.Count ; i >= 1; i--)
                {
                    var control = this.tableLayoutPanel2.GetControlFromPosition(0, i);
                    if (control  != null )
                    {
                        control.Visible = false;
                    }
                }
                Btn_ExpandOrHide.Text = ">>";
                //Btn_First.Visible = false;
                //Btn_Second.Visible = false;
                //Btn_Thrid.Visible = false;
                //Btn_Fourth.Visible = false;
                //Btn_Fifth.Visible = false;

            }
            else
            {
                splitContainer1.SplitterDistance = 128;
                Btn_ExpandOrHide.Text = "<<";
                for (int i = this.tableLayoutPanel2.RowStyles.Count; i >= 1; i--)
                {
                    var control = this.tableLayoutPanel2.GetControlFromPosition(0, i);
                    if (control != null)
                    {
                        control.Visible = true;
                    }
                }
            }
        }
    }
}
