using System;
using System.Windows.Forms;
using static Matrox.MatroxImagingLibrary.MIL;
using Matrox.MatroxImagingLibrary;

namespace MIL_MODULE
{
    public class MIL_PATTERN
    {
        private int speed;
        private int accuracy;
        private int searchAngleMode;
        private int searchAngleDeltaNEG;
        private int searchAngleDeltaPOS;
        private int searchAngleAccuracy;
        private int searchAngleInterpolation;
        private MIL_ID MPatternContext = MIL.M_NULL;
        private MIL_ID MPatternBuffer = MIL.M_NULL;
        private MIL_ID MPatternDisplay = MIL.M_NULL;
        private MIL_ID MPatternResult = MIL.M_NULL;
        private MIL_ID MPatternResultNum = MIL.M_NULL;
        private MIL_ID MOriginBuffer = MIL.M_NULL;
        private MIL_ID MMasterCrossPointContext = MIL.M_NULL;
        private MIL_ID MPatternColor = MIL.M_DEFAULT;
        public double cX = 0;
        public double cY = 0;
        public double findScore = 0;
        public double roiX = 0;
        public double roiY = 0;
        public double roiW = 0;
        public double roiH = 0;
        public double searchAreaX = 0;
        public double searchAreaY = 0;
        public double searchAreaW = 0;
        public double searchAreaH = 0;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="savePath"> 경로만 </param>
        /// <param name="saveName"> 파일이름 </param>
        /// <param name="speed"> 기본 MIL.M_HIGH </param>
        /// <param name="accuracy"> 기본 MIL.M_HIGH </param>
        /// <param name="searchAngleMode"> 기본 MIL.M_DISABLE </param>
        /// <param name="searchAngleDeltaNEG"> 기본 180 </param>
        /// <param name="searchAngleDeltaPOS"> 기본 180 </param>
        /// <param name="searchAngleAccuracy"> 기본 5 </param>
        /// <param name="searchAngleInterpolationMode"> 기본 MIL.M_BILINEAR </param>
        public MIL_PATTERN(int speed = MIL.M_HIGH, int accuracy = MIL.M_HIGH, int searchAngleMode = MIL.M_ENABLE,
            int searchAngleDeltaNEG = 180, int searchAngleDeltaPOS = 180, int searchAngleAccuracy = 5, int searchAngleInterpolationMode = MIL.M_BILINEAR)
        {
            this.speed = speed;
            this.accuracy = accuracy;
            this.searchAngleMode = searchAngleMode;
            this.searchAngleDeltaNEG = searchAngleDeltaNEG;
            this.searchAngleDeltaPOS = searchAngleDeltaPOS;
            this.searchAngleAccuracy = searchAngleAccuracy;
            this.searchAngleInterpolation = searchAngleInterpolationMode;

            
        }

        /// <summary>
        /// 패턴 검색
        /// </summary>
        /// <param name="MsysId"></param>
        /// <param name="MsrcBufferId"></param>
        /// <param name="MsrcDisplayId"></param>
        /// <param name="MgraphiclistId"></param>
        /// <param name="imageSmoothCount"></param>
        /// <param name="IsDrawPattern"></param>
        /// <returns></returns>
        public (bool IsFind, double x, double y, double score) Find_Pattern(MIL_ID MsysId, MIL_ID MsrcBufferId, MIL_ID MsrcDisplayId, MIL_ID MgraphiclistId, int imageSmoothCount=0, bool IsDrawPattern = false)
        {
            // Smooth용 이미지
            MIL_INT tempImageSizeX = 0;
            MIL_INT tempImageSizeY = 0;
            MIL_ID MTempBuffer = M_NULL;
            if (imageSmoothCount > 0)
            {
                MbufInquire(MsrcBufferId, M_SIZE_X, ref tempImageSizeX);
                MbufInquire(MsrcBufferId, M_SIZE_Y, ref tempImageSizeY);
                MbufAlloc2d(MsysId, tempImageSizeX, tempImageSizeY, 8 + M_UNSIGNED, M_IMAGE + M_DISP + M_PROC, ref MTempBuffer);
                MbufCopy(MsrcBufferId, MTempBuffer);
            }

            double findX = 0.0;
            double findY = 0.0;
            double score = 0.0;

            // TEST 0922
            //double testx = 0;
            //double testy = 0;
            //double testz = 0;
            //MIL.MpatInquire(MPatternContext, MIL.M_DEFAULT, MIL.M_ACCEPTANCE, ref testx);
            //MIL.MpatInquire(MPatternContext, MIL.M_DEFAULT, MIL.M_FIRST_LEVEL, ref testx);
            //MIL.MpatInquire(MPatternContext, MIL.M_DEFAULT, MIL.M_LAST_LEVEL, ref testx);
            //Console.WriteLine($"ACCEPTANCE : {testx}\r\nFIRST LEVEL : {testy}\r\nLAST LEVEL : {testz}");

            if (MMasterCrossPointContext != MIL.M_NULL) { MIL.MgraFree(MMasterCrossPointContext); MMasterCrossPointContext = MIL.M_NULL; }
            MIL.MgraAlloc(MsysId, ref MMasterCrossPointContext);
            MIL.MgraColor(MMasterCrossPointContext, MIL.M_COLOR_YELLOW);
            MIL.MgraControl(MMasterCrossPointContext, MIL.M_SELECTABLE, MIL.M_DISABLE);

            if (MPatternResult != MIL.M_NULL) { MIL.MpatFree(MPatternResult); }
            MIL.MpatPreprocess(MPatternContext, MIL.M_DEFAULT, MsrcBufferId);
            MIL.MpatAllocResult(MsysId, MIL.M_DEFAULT, ref MPatternResult);
            
            if(imageSmoothCount > 0)
            {
                for (int i = 0; i < imageSmoothCount; i++)
                {
                    MIL.MimConvolve(MTempBuffer, MTempBuffer, MIL.M_SMOOTH);
                }

                MIL.MpatFind(MPatternContext, MTempBuffer, MPatternResult);

                MbufFree(MTempBuffer);
            }
            else
            {
                MIL.MpatFind(MPatternContext, MsrcBufferId, MPatternResult);
            }


            MIL.MpatGetResult(MPatternResult, MIL.M_GENERAL, MIL.M_NUMBER + MIL.M_TYPE_MIL_INT, ref MPatternResultNum);
            if (MPatternResultNum == 1)
            {
                MIL.MpatGetResult(MPatternResult, MIL.M_DEFAULT, MIL.M_POSITION_X, ref findX);
                MIL.MpatGetResult(MPatternResult, MIL.M_DEFAULT, MIL.M_POSITION_Y, ref findY);
                MIL.MpatGetResult(MPatternResult, MIL.M_DEFAULT, MIL.M_SCORE, ref score);

                if (IsDrawPattern)
                {
                    MIL.MgraColor(MPatternColor, MIL.M_COLOR_GREEN);
                    MIL.MpatDraw(MPatternColor, MPatternResult, MgraphiclistId, MIL.M_DRAW_BOX + MIL.M_DRAW_POSITION, MIL.M_DEFAULT, MIL.M_DEFAULT);
                }

                // 결과 OK
                return (true, findX, findY, score);
            }

            // 중심 크로스라인 그리기
            /*MIL.MgraLine(MMasterCrossPointContext, MgraphiclistId, _mainForm._alignModel.FL_Master_Pattern_Center_x - (_mainForm._alignModel.FL_ROI_Width / 5), _mainForm._alignModel.FL_Master_Pattern_Center_y, _mainForm._alignModel.FL_Master_Pattern_Center_x + (_mainForm._alignModel.FL_ROI_Width / 5), _mainForm._alignModel.FL_Master_Pattern_Center_y);
            MIL.MgraLine(MMasterCrossPointContext, MgraphiclistId, _mainForm._alignModel.FL_Master_Pattern_Center_x, _mainForm._alignModel.FL_Master_Pattern_Center_y - (_mainForm._alignModel.FL_ROI_Height / 5), _mainForm._alignModel.FL_Master_Pattern_Center_x, _mainForm._alignModel.FL_Master_Pattern_Center_y + (_mainForm._alignModel.FL_ROI_Height / 5));*/

            return (false, 0, 0, 0);
        }

        /// <summary>
        /// 패턴 설정
        /// </summary>
        /// <param name="MsysId"></param>
        /// <param name="MsrcBufferId"></param>
        /// <param name="MroiGraphiclistId"></param>
        /// <param name="MroiIndexId"></param>
        /// <param name="MsearchareaIndexId"></param>
        /// <param name="patternPanel"></param>
        /// <param name="imageSmoothCount"></param>
        /// <returns></returns>
        public (double cx, double cy, double score) Set_Pattern(MIL_ID MsysId, MIL_ID MsrcBufferId, MIL_ID MroiGraphiclistId, MIL_INT MroiIndexId, MIL_INT MsearchareaIndexId, Panel patternPanel, int imageSmoothCount = 0)
        {
            try
            {
                // 1. ROI, SearchArea x,y,w,h값 가져오기
                MIL.MgraInquireList(MroiGraphiclistId, MIL.M_GRAPHIC_LABEL(MroiIndexId), MIL.M_DEFAULT, MIL.M_POSITION_X, ref roiX);
                MIL.MgraInquireList(MroiGraphiclistId, MIL.M_GRAPHIC_LABEL(MroiIndexId), MIL.M_DEFAULT, MIL.M_POSITION_Y, ref roiY);
                MIL.MgraInquireList(MroiGraphiclistId, MIL.M_GRAPHIC_LABEL(MroiIndexId), MIL.M_DEFAULT, MIL.M_RECTANGLE_WIDTH, ref roiW);
                MIL.MgraInquireList(MroiGraphiclistId, MIL.M_GRAPHIC_LABEL(MroiIndexId), MIL.M_DEFAULT, MIL.M_RECTANGLE_HEIGHT, ref roiH);

                if (MsearchareaIndexId != MIL.M_NULL)
                {
                    MIL.MgraInquireList(MroiGraphiclistId, MIL.M_GRAPHIC_LABEL(MsearchareaIndexId), MIL.M_DEFAULT, MIL.M_POSITION_X, ref searchAreaX);
                    MIL.MgraInquireList(MroiGraphiclistId, MIL.M_GRAPHIC_LABEL(MsearchareaIndexId), MIL.M_DEFAULT, MIL.M_POSITION_Y, ref searchAreaY);
                    MIL.MgraInquireList(MroiGraphiclistId, MIL.M_GRAPHIC_LABEL(MsearchareaIndexId), MIL.M_DEFAULT, MIL.M_RECTANGLE_WIDTH, ref searchAreaW);
                    MIL.MgraInquireList(MroiGraphiclistId, MIL.M_GRAPHIC_LABEL(MsearchareaIndexId), MIL.M_DEFAULT, MIL.M_RECTANGLE_HEIGHT, ref searchAreaH);
                }

                // 2. 패턴 Context
                Set_PatternContext(MsysId, MsrcBufferId, roiX, roiY, roiW, roiH, searchAreaX, searchAreaY, searchAreaW, searchAreaH, 0, 0, imageSmoothCount);
                

                // 4. 패턴 이미지, 디스플레이 free, alloc
                Set_PatternImage(MsysId, MsrcBufferId);
                Show_PatternImage(MsysId, patternPanel);

                // 5. 패턴 결과 free, alloc
                if (MPatternResult != MIL.M_NULL) { MIL.MpatFree(MPatternResult); MPatternResult = MIL.M_NULL; }
                MIL.MpatPreprocess(MPatternContext, MIL.M_DEFAULT, MsrcBufferId);
                MIL.MpatAllocResult(MsysId, MIL.M_DEFAULT, ref MPatternResult);

                // 6. 패턴 찾기 for cx,cy
                MIL.MpatFind(MPatternContext, MsrcBufferId, MPatternResult);

                // 7. 패턴 결과 가져오기
                MIL.MpatGetResult(MPatternResult, MIL.M_GENERAL, MIL.M_NUMBER + MIL.M_TYPE_MIL_INT, ref MPatternResultNum);

                // 8. 패턴 찾은 결과로 패턴 컨텍스트 다시 디파인 및 roi x,y,width,height 업데이트
                if (MPatternResultNum == 1)
                {
                    MIL.MpatGetResult(MPatternResult, MIL.M_DEFAULT, MIL.M_POSITION_X, ref cX);
                    MIL.MpatGetResult(MPatternResult, MIL.M_DEFAULT, MIL.M_POSITION_Y, ref cY);
                    MIL.MpatGetResult(MPatternResult, MIL.M_DEFAULT, MIL.M_SCORE, ref findScore);
                }

                return (cX, cY, findScore);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Set_Pattern] {ex.Message}");
                return (0, 0, 0);
            }
        }

        /// <summary>
        /// 찾은 패턴 그리기
        /// </summary>
        /// <param name="MgraphiclistId"></param>
        public void Draw_Pattern(MIL_ID MgraphiclistId)
        {
            if (MPatternResult != MIL.M_NULL && MPatternResultNum > 0)
            {
                
                MIL.MpatDraw(MIL.M_DEFAULT, MPatternResult, MgraphiclistId, MIL.M_DRAW_BOX + MIL.M_DRAW_POSITION, MIL.M_DEFAULT, MIL.M_DEFAULT);
            }
        }

        /// <summary>
        /// Pattern Context의 검색 영역 변경
        /// </summary>
        /// <param name="x"> x position </param>
        /// <param name="y"> y position </param>
        /// <param name="w"> width size </param>
        /// <param name="h"> height size </param>
        public void Set_SearchArea(double x, double y, double w, double h)
        {
            MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_SEARCH_OFFSET_X, x); // 패턴모델 검색영역 설정
            MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_SEARCH_OFFSET_Y, y);
            MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_SEARCH_SIZE_X, w);
            MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_SEARCH_SIZE_Y, h);
        }

        /// <summary>
        /// Pattern Context 설정
        /// </summary>
        /// <param name="MsysId"> MIL System ID</param>
        /// <param name="MsrcBufferId"> 패턴을 추출하기 위한 원본 이미지 버퍼 </param>
        /// <param name="roix"> 패턴 x position </param>
        /// <param name="roiy"> 패턴 y position </param>
        /// <param name="roiw"> 패턴 width size </param>
        /// <param name="roih"> 패턴 height size </param>
        /// <param name="searchareax"> 검색영역 x position </param>
        /// <param name="searchareay"> 검색영역 y position </param>
        /// <param name="searchareaw"> 검색영역 width size </param>
        /// <param name="searchareah"> 검색영역 height size </param>
        /// <param name="cx"> 패턴의 중심 x position </param>
        /// <param name="cy"> 패턴의 중심 y position </param>
        /// <param name="imageSmoothCount"></param>
        public void Set_PatternContext(MIL_ID MsysId, MIL_ID MsrcBufferId, double roix, double roiy, double roiw, double roih, double searchareax, double searchareay, double searchareaw, double searchareah, double cx, double cy, int imageSmoothCount = 0)
        {
            // Smooth용 이미지
            MIL_INT tempImageSizeX = 0;
            MIL_INT tempImageSizeY = 0;
            MIL_ID MTempBuffer = M_NULL;
            if(imageSmoothCount > 0)
            {
                MbufInquire(MsrcBufferId, M_SIZE_X, ref tempImageSizeX);
                MbufInquire(MsrcBufferId, M_SIZE_Y, ref tempImageSizeY);
                MbufAlloc2d(MsysId, tempImageSizeX, tempImageSizeY, 8 + M_UNSIGNED, M_IMAGE + M_DISP + M_PROC, ref MTempBuffer);
                MbufCopy(MsrcBufferId, MTempBuffer);
            }

            // 원본 이미지 저장
            MIL_INT tempX = 0;
            MIL_INT tempY = 0;
            MIL.MbufInquire(MsrcBufferId, MIL.M_SIZE_X, ref tempX);
            MIL.MbufInquire(MsrcBufferId, MIL.M_SIZE_Y, ref tempY);
            if (MOriginBuffer != MIL.M_NULL) { MIL.MbufFree(MOriginBuffer); MOriginBuffer = MIL.M_NULL; }
            MIL.MbufAlloc2d(MsysId, tempX, tempY, 8 + MIL.M_UNSIGNED, MIL.M_IMAGE + MIL.M_DISP + MIL.M_PROC, ref MOriginBuffer);
            MIL.MbufCopy(MsrcBufferId, MOriginBuffer);

            // 패턴 컨텍스트 설정
            if (MPatternContext != MIL.M_NULL) { MIL.MpatFree(MPatternContext); MPatternContext = MIL.M_NULL; }
            MIL.MpatAlloc(MsysId, MIL.M_NORMALIZED, MIL.M_DEFAULT, ref MPatternContext);

            for (int i = 0; i < imageSmoothCount; i++)
            {
                MIL.MimConvolve(MTempBuffer, MTempBuffer, MIL.M_SMOOTH);
            }

            if(imageSmoothCount > 0)
            {
                MIL.MpatDefine(MPatternContext, MIL.M_REGULAR_MODEL + MIL.M_CIRCULAR_OVERSCAN, MTempBuffer, roix, roiy, roiw, roih, MIL.M_DEFAULT);
            }
            else
            {
                MIL.MpatDefine(MPatternContext, MIL.M_REGULAR_MODEL + MIL.M_CIRCULAR_OVERSCAN, MsrcBufferId, roix, roiy, roiw, roih, MIL.M_DEFAULT);
            }

            MbufFree(MTempBuffer);

            MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_SPEED, speed); // 패턴매칭 속도 설정
            MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_ACCURACY, accuracy); // 패턴매칭 정확도 설정
            MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_SEARCH_ANGLE_MODE, searchAngleMode); // Activate the search model angle mode.
            MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_SEARCH_ANGLE_DELTA_NEG, searchAngleDeltaNEG); // Set the search model range angle.
            MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_SEARCH_ANGLE_DELTA_POS, searchAngleDeltaPOS);
            MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_SEARCH_ANGLE_ACCURACY, searchAngleAccuracy); // Set the search model angle accuracy.
            MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_SEARCH_ANGLE_INTERPOLATION_MODE, searchAngleInterpolation); // Set the search model angle interpolation mode to bilinear.

            // TEST 0922
            //MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_ACCEPTANCE, searchAngleInterpolation);
            //MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_FIRST_LEVEL, 3);
            //MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_LAST_LEVEL, 3);

            if (searchareaw != 0 && searchareah != 0)
            {
                MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_SEARCH_OFFSET_X, searchareax); // 패턴모델 검색영역 설정
                MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_SEARCH_OFFSET_Y, searchareay);
                MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_SEARCH_SIZE_X, searchareaw);
                MIL.MpatControl(MPatternContext, MIL.M_DEFAULT, MIL.M_SEARCH_SIZE_Y, searchareah);
            }

            // roi, searcharea 값 저장
            if (this.roiX == 0)
                this.roiX = roix;
            if (this.roiY == 0)
                this.roiY = roiy;
            if (this.roiW == 0)
                this.roiW = roiw;
            if (this.roiH == 0)
                this.roiH = roih;
            if (this.searchAreaX == 0)
                this.searchAreaX = searchareax;
            if (this.searchAreaY == 0)
                this.searchAreaY = searchareay;
            if (this.searchAreaW == 0)
                this.searchAreaW = searchareaw;
            if (this.searchAreaH == 0)
                this.searchAreaH = searchareah;
            if (this.cX == 0)
                this.cX = cx;
            if (this.cY == 0)
                this.cY = cy;
        }

        /// <summary>
        /// 원본 이미지에서 패턴 이미지 추출
        /// </summary>
        /// <param name="MsysId"></param>
        /// <param name="MscrBufferId"></param>
        public void Set_PatternImage(MIL_ID MsysId, MIL_ID MscrBufferId)
        {
            if (MPatternBuffer != MIL.M_NULL) { MIL.MbufFree(MPatternBuffer); MPatternBuffer = MIL.M_NULL; }
            MIL.MbufAlloc2d(MsysId, (MIL_INT)roiW, (MIL_INT)roiH, 8 + MIL.M_UNSIGNED, MIL.M_IMAGE + MIL.M_DISP + MIL.M_PROC, ref MPatternBuffer);
            MIL.MbufCopyColor2d(MscrBufferId, MPatternBuffer, MIL.M_ALL_BANDS, (MIL_INT)roiX, (MIL_INT)roiY, MIL.M_ALL_BANDS, 0, 0, (MIL_INT)roiW, (MIL_INT)roiH);
        }

        /// <summary>
        /// 패턴 이미지 화면 디스플레이에 출력
        /// </summary>
        /// <param name="MsysId"></param>
        /// <param name="panel"></param>
        public void Show_PatternImage(MIL_ID MsysId, Panel panel)
        {
            if (MPatternDisplay != MIL.M_NULL) { MIL.MdispFree(MPatternDisplay); MPatternDisplay = MIL.M_NULL; }
            MIL.MdispAlloc(MsysId, MIL.M_DEFAULT, "M_DEFAULT", MIL.M_DEFAULT, ref MPatternDisplay);
            MIL.MdispControl(MPatternDisplay, MIL.M_FILL_DISPLAY, MIL.M_ENABLE);
            MIL.MdispControl(MPatternDisplay, MIL.M_CENTER_DISPLAY, MIL.M_ENABLE);
            MIL.MdispControl(MPatternDisplay, MIL.M_SCALE_DISPLAY, MIL.M_ENABLE);
            MIL.MdispControl(MPatternDisplay, MIL.M_MOUSE_USE, MIL.M_ENABLE);
            MIL.MdispSelectWindow(MPatternDisplay, MPatternBuffer, panel.Handle);
        }

        /// <summary>
        /// 패턴 관련 MIL ID 모두 해제
        /// </summary>
        public void Free()
        {
            if (MMasterCrossPointContext != MIL.M_NULL) { MIL.MgraFree(MMasterCrossPointContext); MMasterCrossPointContext = MIL.M_NULL; }
            if (MPatternContext != MIL.M_NULL) { MIL.MpatFree(MPatternContext); MPatternContext = MIL.M_NULL; }
            if (MPatternBuffer != MIL.M_NULL) { MIL.MbufFree(MPatternBuffer); MPatternBuffer = MIL.M_NULL; }
            if (MPatternDisplay != MIL.M_NULL) { MIL.MdispFree(MPatternDisplay); MPatternDisplay = MIL.M_NULL; }
            if (MPatternResult != MIL.M_NULL) { MIL.MpatFree(MPatternResult); MPatternResult = MIL.M_NULL; }
            if (MOriginBuffer != MIL.M_NULL) { MIL.MbufFree(MOriginBuffer); MOriginBuffer = MIL.M_NULL; }
        }
    }
}
