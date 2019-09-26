using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.Collections;

namespace Profnastil
{
    public partial class WCCGraph : UserControl
    {
        public string XTitle = "XTitle";
        public string YTitle = "YTitle";
        public string Title = "Title";
        public string MarkerFormat = "F2";
        Hashtable ht;

        bool ScaleSetted = false;

        PointPairList PPList4;
        PointPairList PPList3;
        PointPairList PPList2;        
        PointPairList PPList1;

        GraphPane pane;
        LineItem MyCurve;

        //Двигаем точки;
        CurveItem dragCurve;       
        PointF startPt;
        double startX, startY;
        bool isDragPoint = false;        
        int dragIndex;
        PointPair startPair;
        LineObj hLine;
        LineObj vLine;

        //------------------
        public int PPCount {   get { return PPList3.Count; }   set {}  }

        public WCCGraph()
        {
            InitializeComponent();

            pane = zGraph.GraphPane;            
            pane.XAxis.Title.Text = XTitle;
            pane.YAxis.Title.Text = YTitle;
            pane.Title.Text = Title;         

            pane.XAxis.Scale.MinAuto = false;
            pane.XAxis.Scale.MaxAuto = false;
            pane.YAxis.Scale.Format = MarkerFormat;
           
            zGraph.MouseDownEvent += new ZedGraphControl.ZedMouseEventHandler(zGraph_MouseDownEvent);
            zGraph.MouseUpEvent += new ZedGraphControl.ZedMouseEventHandler(zGraph_MouseUpEvent);
            zGraph.MouseMoveEvent += new ZedGraphControl.ZedMouseEventHandler(zGraph_MouseMoveEvent);
            zGraph.IsEnableZoom = false;

            ht = new Hashtable();
            ht[0] = Color.Black;
            ht[1] = Color.Tomato;
            ht[2] = Color.Green;
            ht[3] = Color.Blue;

            PPList1 = new PointPairList();
            PPList2 = new PointPairList();
            PPList3 = new PointPairList();
            PPList4 = new PointPairList();


            AddPairPoint(1, 1, 3);
            AddPairPoint(10, 10, 3);
            DrawCurve(3);
            RemoveCurve(3);
        }
        //----Двигаем точки
        private bool zGraph_MouseDownEvent(ZedGraphControl control, MouseEventArgs e)
        {
           
            if (Control.ModifierKeys == Keys.Shift)
            {                
                PointF mousePt = new PointF(e.X, e.Y);
                        
                if (pane.FindNearestPoint(mousePt, out dragCurve, out dragIndex) &&
                         dragCurve.Points is PointPairList &&
                    dragCurve.YAxisIndex == 0 && dragCurve.Label.Text == "Curve3") 
                {                 
                    startPt = mousePt;
                    startPair = dragCurve.Points[dragIndex];
                   
                    isDragPoint = true;

                    pane.ReverseTransform(mousePt, out startX, out startY);

                    hLine = new LineObj(pane.XAxis.Scale.Min, startPair.Y, pane.XAxis.Scale.Max, startPair.Y);
                    hLine.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
                    vLine = new LineObj(startPair.X, pane.YAxis.Scale.Min, startPair.X, pane.YAxis.Scale.Max);                    
                    vLine.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
                    pane.GraphObjList.Add(hLine);
                    pane.GraphObjList.Add(vLine);

                    control.Refresh();
                }
            }

            return false;
        }
        private bool zGraph_MouseMoveEvent(ZedGraphControl control, MouseEventArgs e)
        {
            GraphPane myPane = control.GraphPane;
            PointF mousePt = new PointF(e.X, e.Y);
          
            if (isDragPoint)
            {                
                double curX, curY;
                pane.ReverseTransform(mousePt, out curX, out curY);

                PointPair newPt = new PointPair(startPair.X + curX - startX, startPair.Y + curY - startY);                
                (dragCurve.Points as PointPairList)[dragIndex] = newPt;

                hLine.Location.Y = startPair.Y + curY - startY;
                hLine.Location.Y1 = startPair.Y + curY - startY;
                vLine.Location.X = startPair.X + curX - startX;
                vLine.Location.X1 = startPair.X + curX - startX;
                

                control.Refresh();
                
                return true;
            }
            else
            {               
                if (myPane.FindNearestPoint(mousePt, out dragCurve, out dragIndex) &&
                         dragCurve.Points is PointPairList &&
                         dragCurve.YAxisIndex == 0 && dragCurve.Label.Text == "Curve3")
                {
                    zGraph.Cursor = Cursors.SizeAll;
                }
                else
                {
                    zGraph.Cursor = Cursors.Default;
                }
            }           
            return false;
        }
        private bool zGraph_MouseUpEvent(ZedGraphControl control, MouseEventArgs e)
        {
            if (isDragPoint)
            {             
                isDragPoint = false;
                pane.GraphObjList.Remove(hLine);
                pane.GraphObjList.Remove(vLine);
                control.Refresh();
            }
            if(!PPList3.Sorted)
                PPList3.Sort();
            return false;
        }
        //-----------------       
        public void SetTitles(string XTitle, string YTitle, string Title)
        {            
            pane.XAxis.Title.Text = XTitle;
            pane.YAxis.Title.Text = YTitle;
            pane.Title.Text = Title;
            zGraph.AxisChange();
            zGraph.Invalidate();

        }                
        //Работаем с изменяемой кривой
        private bool CurveNameIsUnique(string CurveName)
        {
            if (pane.CurveList.Count > 0)
            {
                for (int i = 0; i < pane.CurveList.Count; i++)
                    if (pane.CurveList[i].Label.Text == CurveName)
                        return false;
            }
            return true;
        }
        private void dCurve(ref PointPairList PPList, string CurveName, int ColorNum, bool isLineVisible, SymbolType symbolType)
        {
            if (PPList.Count > 0)
            {
                PPList.Sort();

                if (!ScaleSetted)
                {
                    pane.XAxis.Scale.Min = PPList[0].X;
                    pane.XAxis.Scale.Max = PPList[PPList.Count - 1].X;
                    ScaleSetted = true;
                }
                pane.XAxis.Scale.Min = (PPList[0].X <= pane.XAxis.Scale.Min) ? PPList[0].X : pane.XAxis.Scale.Min;
                pane.XAxis.Scale.Max = (PPList[PPList.Count - 1].X >= pane.XAxis.Scale.Max && PPList[PPList.Count - 1].X != pane.XAxis.Scale.Min) ? PPList[PPList.Count - 1].X : pane.XAxis.Scale.Max;              

                MyCurve = pane.AddCurve(CurveName, PPList, (Color)ht[ColorNum], symbolType);

                MyCurve.Line.IsVisible = isLineVisible;
                
                MyCurve.Label.IsVisible = false;
                MyCurve.Line.Width = 2;
                //MyCurve.Symbol.Fill = new Fill((Color)ht[ColorNum]);
                MyCurve.Symbol.Fill.Type = FillType.Solid;
                zGraph.AxisChange();
                zGraph.Invalidate();
            }
        }
        private double pX(PointPairList PPList, int index)
        {
            if (index < PPList.Count)
                return PPList[index].X;
            return 0;
        }
        private double pY(PointPairList PPList, int index)
        {
            if (index < PPList.Count)
                return PPList[index].Y;
            return 0;
        }
        public void AddPairPoint(double X, double Y, int CurveNum)
        {
            switch (CurveNum)
            {
                case 1:
                    PPList1.Add(X, Y);
                    break;
                case 2:
                    PPList2.Add(X, Y);
                    break;
                case 3:
                    PPList3.Add(X, Y);
                    break;
                case 4:
                    PPList4.Add(X, Y);
                    break;
            }

        }
        public void DrawCurve(int CurveNum)
        {
            switch (CurveNum)
            {
                case 1:
                    dCurve(ref PPList1, "Curve1", 0, true, SymbolType.None);
                    break;
                case 2:
                    dCurve(ref PPList2, "Curve2", 1, true, SymbolType.None);
                    break;
                case 3:
                    dCurve(ref PPList3, "Curve3", 2, false, SymbolType.Diamond);
                    break;
                case 4:
                    dCurve(ref PPList4, "Curve4", 3, true, SymbolType.Square);
                    break;
            }
        }
        public void RemoveCurve(int CurveNum)
        {
            switch (CurveNum)
            {
                case 1:
                    PPList1.Clear();
                    break;
                case 2:
                    PPList2.Clear();
                    break;
                case 3:
                    PPList3.Clear();
                    break;
                case 4:
                    PPList4.Clear();
                    break;
                    
            }            
            zGraph.AxisChange();
            zGraph.Invalidate();
        }                    
        public double PullX(int CurveNum, int index)
        {
            switch (CurveNum)
            {
                case 1:
                    return pX(PPList1, index);                    
                case 2:
                    return pX(PPList2, index);                    
                case 3:
                    return pX(PPList3, index);
                case 4:
                    return pX(PPList4, index);   
            }
            return 0;
        }
        public double PullY(int CurveNum, int index)
        {
            switch (CurveNum)
            {
                case 1:
                    return pY(PPList1, index);
                case 2:
                    return pY(PPList2, index);
                case 3:
                    return pY(PPList3, index);
                case 4:
                    return pY(PPList4, index);
            }
            return 0;
        }        
    }
}
