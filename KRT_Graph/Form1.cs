using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using ZedGraph;

namespace KRT_Graph
{
    public partial class MainForm : Form
    {

        private ComPort _comPort = new ComPort();
        private const byte GetFlowCommand = (byte)'G';
        private int _intervalSec = 100;
        private int _maxVal = 1;
        private int _minVal = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _comPort.DataReceived += ComPort_DataReceived;

            cmbPort.Items.Clear();
            cmbPort.Items.AddRange(_comPort.PortNames());
            cmbBaudRate.Items.Clear();
            cmbBaudRate.Items.AddRange(_comPort.BaudRates());

            cmbPort.SelectedItem = Properties.Settings.Default.Port;
            cmbBaudRate.SelectedItem = Properties.Settings.Default.BaudRate;

            _intervalSec = Properties.Settings.Default.Interval;
            _maxVal = Properties.Settings.Default.MaxValue;
            _minVal = Properties.Settings.Default.MinValue;
            txtMax.Text = _maxVal.ToString();
            txtMin.Text = _minVal.ToString();

            switch (_intervalSec)
            {
                case 5:
                    cmbInterval.SelectedIndex = 0;
                    break;
                case 10:
                    cmbInterval.SelectedIndex = 1;
                    break;
                case 30:
                    cmbInterval.SelectedIndex = 2;
                    break;
                case 60:
                    cmbInterval.SelectedIndex = 3;
                    break;
                case 60*2:
                    cmbInterval.SelectedIndex = 4;
                    break;
                case 60*5:
                    cmbInterval.SelectedIndex = 5;
                    break;
                case 60*10:
                    cmbInterval.SelectedIndex = 6;
                    break;
                case 60*30:
                    cmbInterval.SelectedIndex = 7;
                    break;
                case 60*60:
                    cmbInterval.SelectedIndex = 8;
                    break;
            }

            LoadGraphSettings();

        }

        

        private void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] inBuf = new byte[256];
            int rxCount = _comPort.Read(ref inBuf, 2); //Время чтения
            int rxIndex = 0;


            //case GetFlowCommand : // расход
            //      FlowTemp = 0;
            //      FlowTemp = getchar();
            //      FlowTemp = (FlowTemp << 8) + getchar();
            //      FlowTemp = (FlowTemp << 8) + getchar(); 
            //      FlowTemp = (FlowTemp << 8) + getchar();


            if (rxCount < 5) return; //Не наше

            for (rxIndex = 0; rxIndex < rxCount-4; rxIndex++)
            {
                if (inBuf[rxIndex] == GetFlowCommand)
                {
                    txtDebug.Text = string.Format("{0:X2} {1:X2} {2:X2} {3:X2} {4:X2}", 
                        inBuf[rxIndex], inBuf[rxIndex + 1], inBuf[rxIndex + 2], inBuf[rxIndex + 3], inBuf[rxIndex + 4]);


                    //int y = BitConverter.ToInt32(inBuf, rxIndex+1);
                    int y = (((int) inBuf[rxIndex + 1]) << 24) +
                        (((int) inBuf[rxIndex + 2]) << 16) + 
                        (((int) inBuf[rxIndex + 3]) <<8) + 
                        ((int) inBuf[rxIndex + 4]);


                    if(y>Math.Max(_maxVal*10,30*1000)) continue; //Всплески

                    
                    txtValue.Text = y.ToString();
                    txtValueMin.Text = (y - _minVal).ToString();

                    y -= _minVal;
                    DateTime x = DateTime.Now;

                    _singleCurves[0].UpdateData(y,x);
                    _singleCurves[1].UpdateData((double)_maxVal / y, x);
                    
                }
            }

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            int cpi = cmbPort.SelectedIndex;
            int bri = cmbBaudRate.SelectedIndex;

            if (_comPort.IsOpen() && cpi >= 0 && bri >= 0)
            {
                string port = cmbPort.Items[cpi].ToString();
                string baudRate = cmbBaudRate.Items[bri].ToString();
                if (!string.IsNullOrWhiteSpace(port) && !string.IsNullOrWhiteSpace(baudRate))
                {
                    Properties.Settings.Default.Port = port;
                    Properties.Settings.Default.BaudRate = baudRate;
                }
            }

            Properties.Settings.Default.Interval = _intervalSec;
            Properties.Settings.Default.MaxValue = _maxVal;
            Properties.Settings.Default.MinValue = _minVal;

            _comPort.Close();
            Properties.Settings.Default.Save();
        }

        private void cmbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cpi = cmbPort.SelectedIndex;
            int bri = cmbBaudRate.SelectedIndex;
            if (cpi < 0 || bri < 0) return;

            string port = cmbPort.Items[cpi].ToString();
            string baudRate = cmbBaudRate.Items[bri].ToString();
            if (string.IsNullOrWhiteSpace(port) || string.IsNullOrWhiteSpace(baudRate)) return;
            _comPort.Open(port, baudRate);
        }




        private void LoadGraphSettings()
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

            // Отключаем масштабирование по вертикали
            zGraph.IsEnableVZoom = false;


            // Удалим существующие оси Y
            pane.YAxisList.Clear();


            string[] curveName = { "Value", "Value/Max" };
            Color[] curveColor = {Color.DarkGreen, Color.DarkOrange};

            for (int i = 0; i < 2; i++)
            {
                _singleCurves[i] = new SingleCurve();
                _singleCurves[i].AddCurve(pane, curveName[i], "?", curveColor[i], SymbolType.Plus, 1000);
            }
        }

        private SingleCurve[] _singleCurves = new SingleCurve[5];

        private void UpdateAsis(DateTime beginTime, DateTime endTime)
        {
            //Устанавливаем интересующий нас интервал по оси Y
            zGraph.GraphPane.YAxis.Scale.Min = 0;
            zGraph.GraphPane.YAxis.Scale.Max = 100;
            //По оси Y установим автоматический подбор масштаба
            zGraph.GraphPane.YAxis.Scale.MinAuto = true;
            zGraph.GraphPane.YAxis.Scale.MaxAuto = true;
            //Устанавливаем время по X
            zGraph.GraphPane.XAxis.Scale.Min = (XDate)beginTime;
            zGraph.GraphPane.XAxis.Scale.Max = (XDate)endTime;


            zGraph.AxisChange();
            zGraph.Invalidate();
        }

        private class SingleCurve
        {

            private RollingPointPairList _dataPointList = null;
            private LineItem _myCurve = null;
            private int _axis = 0;
            
            public void AddCurve(GraphPane pane, string name, string measure, Color color, SymbolType sType, int capacity)
            {
                _dataPointList = new RollingPointPairList(capacity);

                // Метод AddYAxis() возвращает индекс новой оси в списке осей (YAxisList)
                _axis = pane.AddYAxis("Axis " + name);

                // Добавим кривую пока еще без каких-либо точек
                _myCurve = pane.AddCurve(string.Format("{0} ({1})", name, measure), _dataPointList, color, sType);

                // Для каждой кривой установим свои оси
                _myCurve.YAxisIndex = _axis;

                // Для наглядности раскрасим надписи на оси Y в цвета графика, 
                // который рисуется с этой осью
                pane.YAxisList[_axis].Title.FontSpec.FontColor = color;
            }

            //Добавление даннх
            public void UpdateData(double data, DateTime time)
            {
                if (_dataPointList == null) return;
                _dataPointList.Add((XDate)time, data);
            }

        }

        private void updTimer200ms_Tick(object sender, EventArgs e)
        {
            UpdateAsis(DateTime.Now.AddSeconds(-_intervalSec), DateTime.Now);
        }

        private void cmbInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbInterval.SelectedIndex)
            {
                case 0:
                    _intervalSec = 5;
                    break;
                case 1:
                    _intervalSec = 10;
                    break;
                case 2:
                    _intervalSec = 30;
                    break;
                case 3:
                    _intervalSec = 60;
                    break;
                case 4:
                    _intervalSec = 60*2;
                    break;
                case 5:
                    _intervalSec = 60*5;
                    break;
                case 6:
                    _intervalSec = 60*10;
                    break;
                case 7:
                    _intervalSec = 60*30;
                    break;
                case 8:
                    _intervalSec = 60*60;
                    break;
            }
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == "Stop")
            {
                updTimer300ms.Stop();
                btnStartStop.Text = "Start";
            }
            else
            {
                updTimer300ms.Start();
                btnStartStop.Text = "Stop";
            }
            
        }

        private void txtMaxValue_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (int.TryParse(txtMax.Text, out value) && value > 10)
            {
                _maxVal = value;
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpForm hForm = new HelpForm();
            hForm.ShowDialog();
        }

        private void txtMin_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (int.TryParse(txtMin.Text, out value) && value > 0)
            {
                _minVal = value;
            }
        }
    }
}
