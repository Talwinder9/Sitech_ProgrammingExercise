

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Sitech_ProgrammingExercise.Support
{
    public delegate void RenderContent(DrawingContext dc);

    public class Exercise_Canvas : Canvas
    {
        public IEnumerable<Line> Lines { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Rect Bounds { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public void CalcBounds()
        {
            Bounds = new Rect((ActualWidth / 2) - 100, (ActualHeight / 2) - 100, 200, 200);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dc"></param>
        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            dc.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Black, 1), Bounds);
            
            Pen p = new Pen((Brushes.Red), 1);

            if (Lines != null && Lines.Any())
            {
                foreach (var line in Lines)
                {
                    dc.DrawLine(p, line.P1, line.P2);
                }
            }
        }
    }
}
