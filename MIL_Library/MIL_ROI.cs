using Matrox.MatroxImagingLibrary;
using static Matrox.MatroxImagingLibrary.MIL;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MIL_MODULE
{
    public class ROIParam
    {
        public MIL_ID MGraphiclist = M_NULL;
        public MIL_INT MROIIndex = M_NULL;
        public MIL_INT MROIVIndex = M_NULL;
        public MIL_INT MROIHIndex = M_NULL;
        public MIL_INT MROILIndex = M_NULL;
        public MIL_INT MSearchAreaIndex = M_NULL;
        public MIL_INT MSearchAreaLIndex = M_NULL;
        public bool useCrossline;
        public bool useSearchArea;
    }

    public class MIL_ROI
    {
        private bool useCrossline;
        private bool useSearchArea;
        private double roiX;
        private double roiY;
        private double roiW;
        private double roiH;
        private double searchAreaX;
        private double searchAreaY;
        private double searchAreaW;
        private double searchAreaH;
        private string roiLabel = string.Empty;
        private string searchareaLabel = string.Empty;
        private int labelOffsetValue;
        private int roiColor = M_COLOR_BLUE;
        private int roiLabelColor = M_COLOR_BLUE;
        private int roiLabelBackColor = 0;
        private int searchAreaColor = M_COLOR_DARK_RED;
        private int searchAreaLabelColor = M_COLOR_DARK_RED;
        private int searchAreaLabelBackColor = 0; 
        private MIL_ID MROIContext = M_NULL;
        private MIL_ID MROICrossContext = M_NULL;
        private MIL_ID MSearchareaContext = M_NULL;
        private MIL_ID MROILContext = M_NULL;
        private MIL_ID MSearchareaLContext = M_NULL;
        public MIL_INT MROIIndex = M_NULL;
        private MIL_INT MROIVIndex = M_NULL;
        private MIL_INT MROIHIndex = M_NULL;
        private MIL_INT MROILIndex = M_NULL;
        public MIL_INT MSearchAreaIndex = M_NULL;
        private MIL_INT MSearchAreaLIndex = M_NULL;
        MIL_GRA_HOOK_FUNCTION_PTR HookHandlerDelegate;

        public MIL_ROI()
        {
        }

        // 기본 생성자
        public MIL_ROI(bool useCrossline, bool useSearchArea, int labelOffsetValue, string roiLabel, double roiX, double roiY, double roiW, double roiH, string searchareaLabel = "", double searchAreaX = 0, double searchAreaY = 0, double searchAreaW = 0, double searchAreaH = 0)
        {
            this.useCrossline = useCrossline;
            this.useSearchArea = useSearchArea;
            this.labelOffsetValue = labelOffsetValue;
            this.roiLabel = roiLabel;
            this.roiX = roiX;
            this.roiY = roiY;
            this.roiW = roiW;
            this.roiH = roiH;
            this.searchareaLabel = searchareaLabel;
            this.searchAreaX = searchAreaX;
            this.searchAreaY = searchAreaY;
            this.searchAreaW = searchAreaW;
            this.searchAreaH = searchAreaH;
        }

        // 생성
        public void Create(MIL_ID MsysId, MIL_ID MGraphiclistId)
        {
            // ROI
            MgraAlloc(MsysId, ref MROIContext);
            MgraColor(MROIContext, roiColor);
            MgraControl(MROIContext, M_ROTATABLE, M_DISABLE);
            MgraRect(MROIContext, MGraphiclistId, roiX, roiY, roiX + roiW, roiY + roiH);
            MgraInquireList(MGraphiclistId, M_LIST, M_DEFAULT, M_LAST_LABEL, ref MROIIndex);

            // ROI Crossline
            MgraAlloc(MsysId, ref MROICrossContext);
            MgraColor(MROICrossContext, roiColor);
            MgraControl(MROICrossContext, M_ROTATABLE, M_DISABLE);
            MgraControl(MROICrossContext, M_SELECTABLE, M_DISABLE);
            if (useCrossline)
            {
                MgraLine(MROICrossContext, MGraphiclistId, roiX, roiY + (roiH / 2), roiX + roiW, roiY + (roiH / 2));
                MgraInquireList(MGraphiclistId, M_LIST, M_DEFAULT, M_LAST_LABEL, ref MROIHIndex);
                MgraLine(MROICrossContext, MGraphiclistId, roiX + (roiW / 2), roiY, roiX + (roiW / 2), roiY + roiH);
                MgraInquireList(MGraphiclistId, M_LIST, M_DEFAULT, M_LAST_LABEL, ref MROIVIndex);
            }

            // ROI Label
            MgraAlloc(MsysId, ref MROILContext);
            MgraColor(MROILContext, roiLabelColor);
            MgraControl(MROILContext, M_ROTATABLE, M_DISABLE);
            if (roiLabelBackColor == 0)
                MgraControl(MROILContext, M_BACKGROUND_MODE, M_TRANSPARENT);
            else
                MgraBackColor(MROILContext, roiLabelBackColor);
            MgraControl(MROILContext, M_SELECTABLE, M_DISABLE);
            MgraFontScale(MROILContext, 1.0, 1.0);
            MgraText(MROILContext, MGraphiclistId, roiX, roiY - labelOffsetValue, roiLabel);
            MgraInquireList(MGraphiclistId, M_LIST, M_DEFAULT, M_LAST_LABEL, ref MROILIndex);

            // SearchArea
            if (useSearchArea)
            {
                MgraAlloc(MsysId, ref MSearchareaContext);
                MgraColor(MSearchareaContext, searchAreaColor);
                MgraControl(MSearchareaContext, M_ROTATABLE, M_DISABLE);
                MgraRect(MSearchareaContext, MGraphiclistId, searchAreaX, searchAreaY, searchAreaX + searchAreaW, searchAreaY + searchAreaH);
                MgraInquireList(MGraphiclistId, M_LIST, M_DEFAULT, M_LAST_LABEL, ref MSearchAreaIndex);

                // SearchArea Label
                MgraAlloc(MsysId, ref MSearchareaLContext);
                MgraColor(MSearchareaLContext, searchAreaLabelColor);
                MgraControl(MSearchareaLContext, M_ROTATABLE, M_DISABLE);
                if (searchAreaLabelBackColor == 0)
                    MgraControl(MSearchareaLContext, M_BACKGROUND_MODE, M_TRANSPARENT);
                else
                    MgraBackColor(MSearchareaLContext, searchAreaLabelBackColor);
                MgraControl(MSearchareaLContext, M_SELECTABLE, M_DISABLE);
                MgraFontScale(MSearchareaLContext, 1.0, 1.0);
                MgraText(MSearchareaLContext, MGraphiclistId, searchAreaX, searchAreaY - labelOffsetValue, searchareaLabel);
                MgraInquireList(MGraphiclistId, M_LIST, M_DEFAULT, M_LAST_LABEL, ref MSearchAreaLIndex);
            }

            // Hook
            ROIParam DataStructure = new ROIParam();
            DataStructure.MGraphiclist = MGraphiclistId;
            DataStructure.MROIIndex = MROIIndex;
            DataStructure.MROIVIndex = MROIVIndex;
            DataStructure.MROIHIndex = MROIHIndex;
            DataStructure.MROILIndex = MROILIndex;
            DataStructure.MSearchAreaIndex = MSearchAreaIndex;
            DataStructure.MSearchAreaLIndex = MSearchAreaLIndex;
            DataStructure.useCrossline = this.useCrossline;
            DataStructure.useSearchArea = this.useSearchArea;

            GCHandle DataStructureHandle = GCHandle.Alloc(DataStructure);
            HookHandlerDelegate = new MIL_GRA_HOOK_FUNCTION_PTR(HookFunction);
            MgraHookFunction(MGraphiclistId, M_GRAPHIC_MODIFIED, HookHandlerDelegate, GCHandle.ToIntPtr(DataStructureHandle));
        }

        // Graphiclist 훅 기능
        private static MIL_INT HookFunction(MIL_INT HookType, MIL_ID EventId, IntPtr UserDataPtr)
        {
            double x1 = 0;
            double y1 = 0;
            double w1 = 0;
            double h1 = 0;
            double x2 = 0;
            double y2 = 0;
            double w2 = 0;
            double h2 = 0;

            // 빈깡통 클래스를 생성해서 GC가 델리게이트를 비관리 코드로 넘기는걸 방지
            var myClass = new MIL_ROI();

            if (!IntPtr.Zero.Equals(UserDataPtr))
            {
                GCHandle hUserData = GCHandle.FromIntPtr(UserDataPtr);

                ROIParam roiParameters = hUserData.Target as ROIParam;

                MgraInquireList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MROIIndex), M_DEFAULT, M_POSITION_X, ref x1);
                MgraInquireList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MROIIndex), M_DEFAULT, M_POSITION_Y, ref y1);
                MgraInquireList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MROIIndex), M_DEFAULT, M_RECTANGLE_WIDTH, ref w1);
                MgraInquireList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MROIIndex), M_DEFAULT, M_RECTANGLE_HEIGHT, ref h1);
                                
                MgraControlList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MROILIndex), M_DEFAULT, M_POSITION_X, x1);
                MgraControlList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MROILIndex), M_DEFAULT, M_POSITION_Y, y1 - 15);

                if (roiParameters.useCrossline)
                {
                    MgraControlList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MROIVIndex), 0, M_POSITION_X, x1 + (w1 / 2));
                    MgraControlList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MROIVIndex), 0, M_POSITION_Y, y1);
                    MgraControlList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MROIVIndex), 1, M_POSITION_X, x1 + (w1 / 2));
                    MgraControlList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MROIVIndex), 1, M_POSITION_Y, y1 + h1);
                                
                    MgraControlList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MROIHIndex), 0, M_POSITION_X, x1);
                    MgraControlList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MROIHIndex), 0, M_POSITION_Y, y1 + (h1 / 2));
                    MgraControlList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MROIHIndex), 1, M_POSITION_X, x1 + w1);
                    MgraControlList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MROIHIndex), 1, M_POSITION_Y, y1 + (h1 / 2));
                }

                if (roiParameters.useSearchArea)
                {
                    MgraInquireList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MSearchAreaIndex), M_DEFAULT, M_POSITION_X, ref x2);
                    MgraInquireList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MSearchAreaIndex), M_DEFAULT, M_POSITION_Y, ref y2);
                    MgraInquireList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MSearchAreaIndex), M_DEFAULT, M_RECTANGLE_WIDTH, ref w2);
                    MgraInquireList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MSearchAreaIndex), M_DEFAULT, M_RECTANGLE_HEIGHT, ref h2);

                    MgraControlList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MSearchAreaLIndex), M_DEFAULT, M_POSITION_X, x2);
                    MgraControlList(roiParameters.MGraphiclist, M_GRAPHIC_LABEL(roiParameters.MSearchAreaLIndex), M_DEFAULT, M_POSITION_Y, y2 - 15);
                }
            }

            return M_NULL;
        }

        // ROI 박스 위치 값 반환
        public (double x, double y, double w, double h) GetROIPosition(MIL_ID MGraphiclistId)
        {
            double x = 0;
            double y = 0;
            double w = 0;
            double h = 0;
            MgraInquireList(MGraphiclistId, M_GRAPHIC_LABEL(MROIIndex), M_DEFAULT, M_POSITION_X, ref x);
            MgraInquireList(MGraphiclistId, M_GRAPHIC_LABEL(MROIIndex), M_DEFAULT, M_POSITION_Y, ref y);
            MgraInquireList(MGraphiclistId, M_GRAPHIC_LABEL(MROIIndex), M_DEFAULT, M_RECTANGLE_WIDTH, ref w);
            MgraInquireList(MGraphiclistId, M_GRAPHIC_LABEL(MROIIndex), M_DEFAULT, M_RECTANGLE_HEIGHT, ref h);
            return (x, y, w, h);
        }

        // 검색영역 박스 위치 값 반환
        public (double x, double y, double w, double h) GetSearchAreaPosition(MIL_ID MGraphiclistId)
        {
            double x = 0;
            double y = 0;
            double w = 0;
            double h = 0;
            if (useSearchArea)
            {
                MgraInquireList(MGraphiclistId, M_GRAPHIC_LABEL(MSearchAreaIndex), M_DEFAULT, M_POSITION_X, ref x);
                MgraInquireList(MGraphiclistId, M_GRAPHIC_LABEL(MSearchAreaIndex), M_DEFAULT, M_POSITION_Y, ref y);
                MgraInquireList(MGraphiclistId, M_GRAPHIC_LABEL(MSearchAreaIndex), M_DEFAULT, M_RECTANGLE_WIDTH, ref w);
                MgraInquireList(MGraphiclistId, M_GRAPHIC_LABEL(MSearchAreaIndex), M_DEFAULT, M_RECTANGLE_HEIGHT, ref h);
            }
            return (x, y, w, h);
        }

        // Visible 상태 변경
        public void Visible(MIL_ID MGraphiclistId, bool isVisible)
        {
            int visible = isVisible == true ? 1 : 0;

            MgraControlList(MGraphiclistId, M_GRAPHIC_LABEL(MROIIndex), M_DEFAULT, M_VISIBLE, visible);
            MgraControlList(MGraphiclistId, M_GRAPHIC_LABEL(MROILIndex), M_DEFAULT, M_VISIBLE, visible);

            if (useCrossline)
            {
                MgraControlList(MGraphiclistId, M_GRAPHIC_LABEL(MROIVIndex), M_DEFAULT, M_VISIBLE, visible);
                MgraControlList(MGraphiclistId, M_GRAPHIC_LABEL(MROIHIndex), M_DEFAULT, M_VISIBLE, visible);
            }

            if (useSearchArea)
            {
                MgraControlList(MGraphiclistId, M_GRAPHIC_LABEL(MSearchAreaIndex), M_DEFAULT, M_VISIBLE, visible);
                MgraControlList(MGraphiclistId, M_GRAPHIC_LABEL(MSearchAreaLIndex), M_DEFAULT, M_VISIBLE, visible);
            }
        }     

        // Visible 상태 반환
        public bool Visible_Status(MIL_ID MGraphiclistId)
        {
            int result = 0;
            MgraInquireList(MGraphiclistId, M_GRAPHIC_LABEL(MROIIndex), M_DEFAULT, M_VISIBLE, ref result);

            return (result == 1 ? true : false);
        }

        // 색상변경
        public void SetColor(int roi = M_COLOR_BLUE, int roiLabel = M_COLOR_BLUE,  int roiBack = 0, int searchArea = M_COLOR_DARK_RED, int searchAreaLabel = M_COLOR_DARK_RED, int searchAreaBack = 0)
        {
            this.roiColor = roi;
            this.roiLabelColor = roiLabel;
            this.roiLabelBackColor = roiBack;
            this.searchAreaColor = searchArea;
            this.searchAreaLabelColor = searchAreaLabel;
            this.searchAreaLabelBackColor = searchAreaBack; 
        }

        // Free, Clear
        public void Free()
        {
            if (MROIContext != M_NULL) { MgraFree(MROIContext); MROIContext = M_NULL; }
            if (MROICrossContext != M_NULL) { MgraFree(MROICrossContext); MROICrossContext = M_NULL; }
            if (MROILContext != M_NULL) { MgraFree(MROILContext); MROILContext = M_NULL; }
            if (MSearchareaContext != M_NULL) { MgraFree(MSearchareaContext); MSearchareaContext = M_NULL; }
            if (MSearchareaLContext != M_NULL) { MgraFree(MSearchareaLContext); MSearchareaLContext = M_NULL; }
        }
    }
}
