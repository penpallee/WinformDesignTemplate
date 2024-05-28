using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL_MODULE
{
    public class AlignModel
    {
        public string name;
        public string comment;
        public DateTime updateDate;
        public double cor1_X; 
        public double cor1_Y;
        public double cor2_X;
        public double cor2_Y;
        public double masterAngle;
        public double offsetX;
        public double offsetY;
        public double offsetAngle;
        public bool patternUse1;
        public bool patternUse2;

        public double roi1_X = 0;
        public double roi1_Y = 0;
        public double roi1_W = 0;
        public double roi1_H = 0;
        public double searchArea1_X = 0;
        public double searchArea1_Y = 0;
        public double searchArea1_W = 0;
        public double searchArea1_H = 0;

        public double roi2_X = 0;
        public double roi2_Y = 0;
        public double roi2_W = 0;
        public double roi2_H = 0;
        public double searchArea2_X = 0;
        public double searchArea2_Y = 0;
        public double searchArea2_W = 0;
        public double searchArea2_H = 0;

        // 카메라 1개일때
        public AlignModel(string name, string comment, DateTime updateDate, double corX, double corY, double masterAngle, double offsetX, double offsetY, double offsetAngle, bool patternUse, double roi1_X, double roi1_Y, double roi1_W, double roi1_H, double searchArea1_X, double searchArea1_Y, double searchArea1_W, double searchArea1_H, double roi2_X, double roi2_Y, double roi2_W, double roi2_H, double searchArea2_X, double searchArea2_Y, double searchArea2_W, double searchArea2_H)
        {
            this.name = name;
            this.comment = comment;
            this.updateDate = updateDate;
            this.cor1_X = corX;
            this.cor1_Y = corY;
            this.masterAngle = masterAngle;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            this.offsetAngle = offsetAngle;
            this.patternUse1 = patternUse;
            this.roi1_X = roi1_X;
            this.roi1_Y = roi1_Y;
            this.roi1_W = roi1_W;
            this.roi1_H = roi1_H;
            this.searchArea1_X = searchArea1_X;
            this.searchArea1_Y = searchArea1_Y;
            this.searchArea1_W = searchArea1_W;
            this.searchArea1_H = searchArea1_H;
            this.roi2_X = roi2_X;
            this.roi2_Y = roi2_Y;
            this.roi2_W = roi2_W;
            this.roi2_H = roi2_H;
            this.searchArea2_X = searchArea2_X;
            this.searchArea2_Y = searchArea2_Y;
            this.searchArea2_W = searchArea2_W;
            this.searchArea2_H = searchArea2_H;
        }

        // 카메라 2개일때
        public AlignModel(string name, string comment, DateTime updateDate, double cor1_X, double cor1_Y, double cor2_X, double cor2_Y, double masterAngle, double offsetX, double offsetY, double offsetAngle, bool patternUse1, bool patternUse2, double roi1_X, double roi1_Y, double roi1_W, double roi1_H, double searchArea1_X, double searchArea1_Y, double searchArea1_W, double searchArea1_H, double roi2_X, double roi2_Y, double roi2_W, double roi2_H, double searchArea2_X, double searchArea2_Y, double searchArea2_W, double searchArea2_H)
        {
            this.name = name;
            this.comment = comment;
            this.updateDate = updateDate;
            this.cor1_X = cor1_X;
            this.cor1_Y = cor1_Y;
            this.cor2_X = cor2_X;
            this.cor2_Y = cor2_Y;
            this.masterAngle = masterAngle;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            this.offsetAngle = offsetAngle;
            this.patternUse1 = patternUse1;
            this.patternUse2 = patternUse2;
            this.roi1_X = roi1_X;
            this.roi1_Y = roi1_Y;
            this.roi1_W = roi1_W;
            this.roi1_H = roi1_H;
            this.searchArea1_X = searchArea1_X;
            this.searchArea1_Y = searchArea1_Y;
            this.searchArea1_W = searchArea1_W;
            this.searchArea1_H = searchArea1_H;
            this.roi2_X = roi2_X;
            this.roi2_Y = roi2_Y;
            this.roi2_W = roi2_W;
            this.roi2_H = roi2_H;
            this.searchArea2_X = searchArea2_X;
            this.searchArea2_Y = searchArea2_Y;
            this.searchArea2_W = searchArea2_W;
            this.searchArea2_H = searchArea2_H;
        }
    }
}
