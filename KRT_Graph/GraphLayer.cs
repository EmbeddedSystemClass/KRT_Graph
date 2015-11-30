using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace KRT_Graph
{
    class GraphLayer
    {
        private ZedGraphControl zGraph;
        private SingleCurve[] _singleCurves = new SingleCurve[2];
        public GraphLayer(ZedGraphControl zG)
        {
            zGraph = zG;
        }
        public void LoadGraphSettings()
        {
            zGraph.EditButtons = MouseButtons.None;
            zGraph.LinkButtons = MouseButtons.None;
            zGraph.SelectButtons = MouseButtons.None;
            //Кнопка таскания
            // zGraph.PanButtons = MouseButtons.None;
            zGraph.PanModifierKeys = Keys.None;
            zGraph.PanButtons2 = MouseButtons.None;
            //Кнопка зума выделенного прямоугольника
            zGraph.ZoomButtons = MouseButtons.None;
            zGraph.ZoomButtons2 = MouseButtons.None;

            GraphPane pane = zGraph.GraphPane;

            // Отключаем заголовок
            pane.Title.IsVisible = false;

            // Отключаем имя осям
            pane.XAxis.Title.IsVisible = false;
            pane.YAxis.Title.IsVisible = false;

            // Не рисовать линию нуля
            pane.YAxis.MajorGrid.IsZeroLine = false;

            // С помощью этого свойства указываем, что шрифты не надо масштабировать
            // при изменении размера компонента.
            pane.IsFontsScaled = false;

            // Установим размеры шрифтов для меток вдоль осей
            pane.XAxis.Scale.FontSpec.Size = 12;
            pane.YAxis.Scale.FontSpec.Size = 12;

            // Установим размеры шрифтов для подписей по осям
            pane.XAxis.Title.FontSpec.Size = 10;
            pane.YAxis.Title.FontSpec.Size = 10;

            // Установим размеры шрифта для легенды
            pane.Legend.FontSpec.Size = 12;

            // Установим размеры шрифта для заголовка
            pane.Title.FontSpec.Size = 12;


            // Для оси X установим календарный тип
            pane.XAxis.Type = AxisType.Date;

            // Установим значение параметра IsBoundedRanges как true.
            // Это означает, что при автоматическом подборе масштаба 
            // нужно учитывать только видимый интервал графика
            pane.IsBoundedRanges = true;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            // Включаем отображение сетки напротив крупных рисок по оси X
            pane.XAxis.MajorGrid.IsVisible = true;

            // Задаем вид пунктирной линии для крупных рисок по оси X:
            // Длина штрихов равна 10 пикселям, ... 
            pane.XAxis.MajorGrid.DashOn = 10;

            // затем 5 пикселей - пропуск
            pane.XAxis.MajorGrid.DashOff = 5;


            // Включаем отображение сетки напротив крупных рисок по оси Y
            pane.YAxis.MajorGrid.IsVisible = true;

            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;


            // Включаем отображение сетки напротив мелких рисок по оси X
            pane.YAxis.MinorGrid.IsVisible = true;

            // Задаем вид пунктирной линии для крупных рисок по оси Y: 
            // Длина штрихов равна одному пикселю, ... 
            pane.YAxis.MinorGrid.DashOn = 1;

            // затем 2 пикселя - пропуск
            pane.YAxis.MinorGrid.DashOff = 2;

            // Включаем отображение сетки напротив мелких рисок по оси Y
            pane.XAxis.MinorGrid.IsVisible = true;

            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;



            // Свойства IsSynchronizeXAxes и IsSynchronizeYAxes указывают, что
            // оси на графиках должны перемещаться и масштабироваться одновременно.
            zGraph.IsSynchronizeXAxes = true;
            //zGraph.IsSynchronizeYAxes = true;

            // Отключаем масштабирование по горизонтали
            zGraph.IsEnableHZoom = false;


            // Удалим существующие оси Y
            //pane.YAxisList.Clear();


            // Включим показ всплывающих подсказок
            zGraph.IsShowCursorValues = true;
            zGraph.CursorValueEvent += new ZedGraphControl.CursorValueHandler(zGraph_CursorValueEvent);


            //Няшка
            _singleCurves[0] = new SingleCurve();
            _singleCurves[1] = new SingleCurve();

           _singleCurves[0].AddCurve(pane, "Значение", "Л", Color.DarkGreen, SymbolType.Plus, 4000);
           _singleCurves[1].AddCurve(pane, "Значение/Макс", "Л", Color.DarkOrange, SymbolType.Plus, 4000);
        }

        private string zGraph_CursorValueEvent(ZedGraphControl sender, GraphPane pane, Point mousePt)
        {
            double x, y;
            pane.ReverseTransform(mousePt, out x, out y);
            return string.Format("X={0} Y={1}", ((XDate)x).ToString("mm:ss"), y);
        }

        public void SaveAs()
        {
            zGraph.SaveAs("img");
        }

        public void UpdateData(double data, DateTime time, double data2 = 0)
        {
            _singleCurves[0].UpdateData(data, time);
            _singleCurves[1].UpdateData(data2,time);
        }

        public void ClearData()
        {
            _singleCurves[0].ClearData();
            _singleCurves[1].ClearData();
        }

        public DateTime GetBeginTime()
        {
            return (XDate) zGraph.GraphPane.XAxis.Scale.Min;
        }

        public DateTime GetEndTime()
        {
            return (XDate)zGraph.GraphPane.XAxis.Scale.Max;
        }

        public void UpdateAsis(DateTime beginTime, DateTime endTime, bool isAuto = true)
        {
            //Устанавливаем интересующий нас интервал по оси Y
            //zGraph.GraphPane.YAxis.Scale.Min = 0;
            //zGraph.GraphPane.YAxis.Scale.Max = 100;
            //По оси Y установим автоматический подбор масштаба
            zGraph.GraphPane.YAxis.Scale.MinAuto = isAuto;
            zGraph.GraphPane.YAxis.Scale.MaxAuto = isAuto;
            //Устанавливаем время по X
            zGraph.GraphPane.XAxis.Scale.Min = (XDate)beginTime;
            zGraph.GraphPane.XAxis.Scale.Max = (XDate)endTime;


            zGraph.AxisChange();
            zGraph.Invalidate();
        }
    }
    class SingleCurve
    {

        private RollingPointPairList _dataPointList = null;
        private LineItem _myCurve = null;
        private int _axis = 0;

        public void AddCurve(GraphPane pane, string name, string measure, Color color, SymbolType sType, int capacity)
        {
            _dataPointList = new RollingPointPairList(capacity);

            // Метод AddYAxis() возвращает индекс новой оси в списке осей (YAxisList)
            //_axis = pane.AddYAxis("Axis " + name);

            // Добавим кривую пока еще без каких-либо точек
            _myCurve = pane.AddCurve(string.Format("{0} ({1})", name, measure), _dataPointList, color, sType);

            // Для каждой кривой установим свои оси
           // _myCurve.YAxisIndex = _axis;

            // Для наглядности раскрасим надписи на оси Y в цвета графика, 
            // который рисуется с этой осью
            //pane.YAxisList[_axis].Title.FontSpec.FontColor = color;
        }

        public void ClearData()
        {
            if (_dataPointList!=null)
            _dataPointList.Clear();
        }

        //Добавление даннх
        public void UpdateData(double data, DateTime time)
        {
            if (_dataPointList != null) 
            _dataPointList.Add((XDate)time, data);
        }

    }
}
