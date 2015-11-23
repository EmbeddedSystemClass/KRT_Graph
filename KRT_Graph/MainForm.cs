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
        private GraphLayer _graphLayer = null;
        private DataSaveLayer _dataSaveLayer = new DataSaveLayer();
        private const byte GetFlowCommand = (byte)'G';
        private int _intervalSec = 100;
        private DateTime _timeStart = new DateTime();
        private Status _status = Status.Stop;
        private bool _isAutoSize = true;
        private int _maxVal = 1;
        private int _minVal = 0;
        private int _middleVal = 0;
        private int[] _yMidArr = new int[100];
        private int _yMidCnt = 8;
        private int _yIndex = 0;

        public MainForm()
        {
            InitializeComponent();
            _graphLayer = new GraphLayer(zGraph);
        }

        private void LoadPortSettings()
        {
            _comPort.DataReceived += ComPort_DataReceived;

            cmbPort.Items.Clear();
            cmbPort.Items.AddRange(_comPort.PortNames());
            cmbBaudRate.Items.Clear();
            cmbBaudRate.Items.AddRange(_comPort.BaudRates());

            cmbPort.SelectedItem = Properties.Settings.Default.Port;
            cmbBaudRate.SelectedItem = Properties.Settings.Default.BaudRate;
        }
        private void PreUpdatePortSettings()
        {
            int cpi = cmbPort.SelectedIndex;
            string port="";

            if (cpi >= 0)
            {
                port = cmbPort.Items[cpi].ToString();
            }
            cmbPort.Items.Clear();
            cmbPort.Items.AddRange(_comPort.PortNames());

            cmbPort.SelectedItem = port;
        }
        private void UpdatePortSettings() //Проверить ОК
        {
            int cpi = cmbPort.SelectedIndex;
            int bri = cmbBaudRate.SelectedIndex;
            if (cpi >= 0 && bri >= 0)
            {
                string port = cmbPort.Items[cpi].ToString();
                string baudRate = cmbBaudRate.Items[bri].ToString();
                if (!string.IsNullOrWhiteSpace(port) && !string.IsNullOrWhiteSpace(baudRate) 
                    && _comPort.isPortChange(port,baudRate))
                {
                    _comPort.Open(port, baudRate);
                }
            }
        }
        private void SavePortSettings()
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
            _comPort.Close();
        }
        private void LoadIntervalSettings()
        {
            _intervalSec = Properties.Settings.Default.Interval;
            switch (_intervalSec)
            {
                case 1:
                    cmbInterval.SelectedIndex = 0;
                    break;
                case 5:
                    cmbInterval.SelectedIndex = 0+1;
                    break;
                case 10:
                    cmbInterval.SelectedIndex = 1+1;
                    break;
                case 30:
                    cmbInterval.SelectedIndex = 2+1;
                    break;
                case 60:
                    cmbInterval.SelectedIndex = 3+1;
                    break;
                case 60 * 2:
                    cmbInterval.SelectedIndex = 4+1;
                    break;
                case 60 * 5:
                    cmbInterval.SelectedIndex = 5+1;
                    break;
                case 60 * 10:
                    cmbInterval.SelectedIndex = 6+1;
                    break;
                case 60 * 30:
                    cmbInterval.SelectedIndex = 7+1;
                    break;
                case 60 * 60:
                    cmbInterval.SelectedIndex = 8+1;
                    break;
            }
        }
        private void UpdateIntervalSettings()
        {
            switch (cmbInterval.SelectedIndex)
            {
                case 0:
                    _intervalSec = 1;
                    break;
                case 0+1:
                    _intervalSec = 5;
                    break;
                case 1+1:
                    _intervalSec = 10;
                    break;
                case 2+1:
                    _intervalSec = 30;
                    break;
                case 3+1:
                    _intervalSec = 60;
                    break;
                case 4+1:
                    _intervalSec = 60 * 2;
                    break;
                case 5+1:
                    _intervalSec = 60 * 5;
                    break;
                case 6+1:
                    _intervalSec = 60 * 10;
                    break;
                case 7+1:
                    _intervalSec = 60 * 30;
                    break;
                case 8+1:
                    _intervalSec = 60 * 60;
                    break;
                default:
                    return;
            }
            DateTime dtEnd = _graphLayer.GetEndTime();
            _graphLayer.UpdateAsis(dtEnd.AddSeconds(-_intervalSec), dtEnd,false);
        } //Дописать ОК

        private void ChangeBtnChecked()
        {
            switch (_status)
            {
                case Status.Start:
                    btnStopAndClear.Checked = false;
                    btnPause.Checked = false;
                    btnRecAndPlay.Checked = true;
                    break;
                case Status.Stop:
                    btnStopAndClear.Checked = true;
                    btnPause.Checked = false;
                    btnRecAndPlay.Checked = false;
                    break;
                case Status.Pause:
                    btnStopAndClear.Checked = false;
                    btnPause.Checked = true;
                    btnRecAndPlay.Checked = false;
                    break;
            }
        }

        #region События

        private void cmbInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateIntervalSettings();
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

        private void cmbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePortSettings();
        }


        private void btnPortFind_DropDownOpening(object sender, EventArgs e)
        {
            PreUpdatePortSettings();
        }


        #endregion
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadPortSettings();
            _graphLayer.LoadGraphSettings();
            LoadIntervalSettings();
            _timeStart = DateTime.Now;

            _maxVal = Properties.Settings.Default.MaxValue;
            _minVal = Properties.Settings.Default.MinValue;
            txtMax.Text = _maxVal.ToString();
            txtMin.Text = _minVal.ToString();
            btnAutoSize.Checked = _isAutoSize;
            ChangeBtnChecked();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           

            Properties.Settings.Default.Interval = _intervalSec;
            Properties.Settings.Default.MaxValue = _maxVal;
            Properties.Settings.Default.MinValue = _minVal;
            SavePortSettings();
           
            Properties.Settings.Default.Save();
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

                    _yMidArr[_yIndex] = y;
                    _yIndex++;
                    _yIndex %= _yMidCnt;

                    int temp = 0;
                    for (int i = 0; i < _yMidCnt; i++)
                    {
                        temp += _yMidArr[(i + _yIndex)%_yMidCnt];
                    }
                    txtMidValue.Text = (temp/_yMidCnt).ToString();

                    if (_status == Status.Start)
                    {
                        txtLogValuemiMin.AppendText(y.ToString() + "\r\n");
                        txtLogMaxdelValue.AppendText(((double)_maxVal /(double)y).ToString() + "\r\n");

                        DateTime x = DateTime.Now.AddTicks(-_timeStart.Ticks);
                        _graphLayer.UpdateData(y/1000.0,x); //Делим в литры!
                        _dataSaveLayer.UpdateData(y/1000.0,x);
                    }
                }
            }

        }

   

        private void updTimer200ms_Tick(object sender, EventArgs e)
        {
            if (_status == Status.Start)
            {
                DateTime dtEnd = DateTime.Now.AddTicks(-_timeStart.Ticks);
                _graphLayer.UpdateAsis(dtEnd.AddSeconds(-_intervalSec), dtEnd, _isAutoSize);
            }
        }

        private void btnRecAndPlay_Click(object sender, EventArgs e)
        {
            if (_status == Status.Stop)
            {
                _timeStart = DateTime.Now.AddYears(-1);
                _dataSaveLayer.ClearData();
                _graphLayer.ClearData();
                txtLogMaxdelValue.Text = "";
                txtLogValuemiMin.Text = "";
            }
            _status = Status.Start;
            ChangeBtnChecked();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
           _status = Status.Pause;
           ChangeBtnChecked();
        }
 
        private void btnStopAndClear_Click(object sender, EventArgs e)
        {
            _status = Status.Stop;
            _graphLayer.ClearData();
            ChangeBtnChecked();

            _timeStart = DateTime.Now.AddYears(-1);
            DateTime dtEnd = DateTime.Now.AddTicks(-_timeStart.Ticks);
            _graphLayer.UpdateAsis(dtEnd.AddSeconds(-_intervalSec), dtEnd);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _dataSaveLayer.SaveData(saveFileDialog1.FileName);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _status = Status.Stop;
                
                ChangeBtnChecked();
                _dataSaveLayer.LoadData(openFileDialog1.FileName);
                _dataSaveLayer.CopyData(_graphLayer, _intervalSec);
                _dataSaveLayer.TxtLog(txtLogValuemiMin,txtLogMaxdelValue,_maxVal);
            }
        }

        private void btnScreenshot_Click(object sender, EventArgs e)
        {
            _graphLayer.SaveAs();
        }

        private void btnAutoSize_Click(object sender, EventArgs e)
        {
            DateTime dtEnd = _graphLayer.GetEndTime();
            _graphLayer.UpdateAsis(dtEnd.AddSeconds(-_intervalSec), dtEnd);
           
            _isAutoSize = (btnAutoSize.Checked ^= true);
        }

        private void btnCropFrom_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данная функция ещё не реализована");
        }

        private void btnCropTo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данная функция ещё не реализована");
        }

       
   
    }

    public enum Status
    {
        Start, Pause, Stop
    }
}
