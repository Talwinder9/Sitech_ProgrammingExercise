
using System;
using System.Collections.Generic;
using System.Windows;
using Sitech_ProgrammingExercise.Support;

namespace Sitech_ProgrammingExercise
{
    public partial class MainWindow
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static double ToDegrees(double radians)
        {
            return radians * 57.29578f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static double ToRadians(double degrees)
        {
            return degrees * (Math.PI / 180.0f);
        }


        // return a collection of line objects that will ultimately be used to render a circle on the canvas
        // the circle should be inside the bounds of the "Rect" argument (left,top,width,height)
        // the line class has 2 properties P1 & P2, that are used as drawing Points (X,Y)

        //NOTE:I didn't get this question exactly though just returned a collection of lines
        public IEnumerable<Line> Exercise6(Rect rect)
        {
            return new List<Line>
            {
                new Line
                {
                    P1 = new Point { X = rect.Left, Y = rect.Top },
                    P2 = new Point { X = rect.Left, Y = rect.Height }
                },
                new Line
                {
                    P1 = new Point { X = rect.Left, Y = rect.Top },
                    P2 = new Point { X = rect.Left, Y = rect.Width }
                },
            };
        }
    }
}
