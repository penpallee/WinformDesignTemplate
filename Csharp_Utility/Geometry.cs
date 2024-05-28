using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL_MODULE.Utilities
{
    public static class Geometry
    {
        /// <summary>
        /// 두 점이 이루는 각도 구하기
        /// </summary>
        public static double VectorAngle(double x1, double y1, double x2, double y2)
        {
            double distanceX = x2 - x1;
            double distanceY = y2 - y1;

            double gradient = distanceY / distanceX;
            double angle = RadianToDegree(Math.Atan(gradient));

            return angle;
        }

        /// <summary>
        /// 2점과 각도로 회전의 중심 계산
        /// </summary>
        /// <param name="masterX"></param>
        /// <param name="masterY"></param>
        /// <param name="findX"></param>
        /// <param name="findY"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static (double corX, double corY, double radius) FindCenterOfRotation(double masterX, double masterY, double findX, double findY, double angle)
        {
            //angle = -angle;

            Console.WriteLine($"M : {masterX}, {masterY}\r\nF : {findX}, {findY}\r\nA : {angle}");

            double radian = DegreeToRadian(angle);
            double tempCos = Math.Cos(radian);
            double tempSin = Math.Sin(radian);

            double corX = (masterX * ((tempCos - 1) * tempCos + tempSin * tempSin) + masterY * ((-tempSin) * (tempCos - 1) + tempSin * tempCos) - findX * (tempCos - 1) - findY * (tempSin)) / (2 * (1 - tempCos));
            double corY = (masterX * ((-tempSin) * tempCos + tempSin * (tempCos - 1)) + masterY * (tempSin * tempSin + tempCos * (tempCos - 1)) + findX * (tempSin) - findY * (tempCos - 1)) / (2 * (1 - tempCos));
            double radius = Math.Sqrt(Math.Pow((findX - corX), 2) + Math.Pow((findY - corY), 2));

            Console.WriteLine($"corX : {corX}\r\ncorY : {corY}\r\nradius : {radius}");

            return (corX, corY, radius);
        }

        /// <summary>
        /// 3점으로 회전의 중심 계산
        /// </summary>
        /// <param name="masterX"></param>
        /// <param name="masterY"></param>
        /// <param name="leftX"></param>
        /// <param name="leftY"></param>
        /// <param name="rightX"></param>
        /// <param name="rightY"></param>
        /// <returns></returns>
        public static Dictionary<string, double> FindCenterOfRotation_3dot(double masterX, double masterY, double leftX, double leftY, double rightX, double rightY)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();

            double rd1 = ((masterY - leftY) / (masterX - leftX));
            double rd2 = (rightY - masterY) / (rightX - masterX);

            // 기울기의 역수 구하기
            rd1 = 1 / rd1;
            rd2 = 1 / rd2;

            // 회전의 중심 X
            double cx = ((rightY - leftY) + ((masterX + rightX) * rd2) - ((leftX + masterX) * rd1)) / (2 * (rd2 - rd1));

            // 회전의 중심 Y
            double cy = (-rd1 * (cx - ((leftX + masterX) / 2))) + ((leftY + masterY) / 2);

            // 반지름
            double radius = Math.Sqrt(Math.Pow((leftX - cx), 2) + Math.Pow((leftY - cy), 2));

            result.Add("cx", cx);
            result.Add("cy", cy);
            result.Add("radius", radius);

            return result;
        }

        /// <summary>
        /// 라디안 to 각도
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static double RadianToDegree(double radian)
        {
            return (radian * 180) / Math.PI;
        }

        /// <summary>
        /// 각도 to 라디안
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static double DegreeToRadian(double degree)
        {
            return (degree * Math.PI) / 180;
        }

        /// <summary>
        /// 1차 연립방정식의 해 계산 
        /// a1x + b1y = c1, a2x + b2y = c2를 받아서 x값과 y값을 반환한다.
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="b1"></param>
        /// <param name="c1"></param>
        /// <param name="a2"></param>
        /// <param name="b2"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static Dictionary<string, double> SolveLinearEquations(double a1, double b1, double c1, double a2, double b2, double c2)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();

            // 1차 연립방정식을 크래머공식을 사용해서 해를 구한다.
            double x = ((c1 * b2) - (c2 * b1)) / ((a1 * b2) - (a2 * b1));
            double y = ((a1 * c2) - (a2 * c1)) / ((a1 * b2) - (a2 * b1));

            result.Add("x", x);
            result.Add("y", y);
            return result;
        }

        /// <summary>
        /// 2D 평면이동 좌표 계산
        /// 원점에서 회전후의 위치할 x,y 좌표까지의 거리값을 반환
        /// </summary>
        public static (double x, double y) FindVirtualPoint(double corX, double corY, double x, double y, double angle)
        {
            double radian = DegreeToRadian(angle);

            double tempCos = Math.Cos(radian);
            double tempSin = Math.Sin(radian);

            double expectedX = ((x - corX) * tempCos) - ((y - corY) * tempSin) + corX;
            double expectedY = ((x - corX) * tempSin) + ((y - corY) * tempCos) + corY;

            /*double dx = Math.Pow(마스터 좌표 X - 회전의 중심 X) - 회전 후 위치한 포인트 X;
            double dy = Math.Pow(마스터 좌표 Y - 회전의 중심 Y) - 회전 후 위치한 포인트 Y;*/

            return (expectedX, expectedY);
        }
    }
}
