using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace KRT_Graph
{
    class DataSaveLayer
    {
        private KeyValuePair<DateTime, double>[] _DataArray = null;
        private int _sizeArray = 4000;
        private int _firstIndex = 0;
        private int _lastIndex = 0;
        private DateTime _startTime = new DateTime();

        public DataSaveLayer()
        {
            _DataArray = new KeyValuePair<DateTime, double>[_sizeArray];
        }

        public void UpdateData(double data, DateTime time)
        {
            _DataArray[_lastIndex] = new KeyValuePair<DateTime, double>(time,data);
            _lastIndex++;
            _lastIndex %= _sizeArray;
            if (_lastIndex == _firstIndex)
            {
                _firstIndex++;
                _firstIndex %= _sizeArray;
            }
        }

        public void ClearData()
        {
            _firstIndex = 0;
            _lastIndex = 0;
        }

        public void CopyData(GraphLayer g, int intervalSec)
        {
            _startTime = _DataArray[_firstIndex].Key.AddYears(-1);
            g.ClearData();
            for (int i = _firstIndex; i != _lastIndex; ++i)
            {
                i %= _sizeArray;
                g.UpdateData(_DataArray[i].Value, _DataArray[i].Key.AddTicks(-_startTime.Ticks));
            }
            g.UpdateAsis(_DataArray[_firstIndex].Key, _DataArray[_firstIndex].Key.AddSeconds(intervalSec));
        }


        public void SaveData(string path)
        {
            _startTime = _DataArray[_firstIndex].Key.AddYears(-1);
            int tsize = (_firstIndex<_lastIndex)?_lastIndex - _firstIndex : _sizeArray - _firstIndex + _lastIndex;
            KeyValuePair<DateTime, double>[] temp = new KeyValuePair<DateTime, double>[tsize];
            for (int i = _firstIndex, j = 0; i != _lastIndex; ++j, ++i)
            {
                i %= _sizeArray;
                temp[j] = new KeyValuePair<DateTime, double>(_DataArray[i].Key.AddTicks(-_startTime.Ticks), _DataArray[i].Value);
            }

            BinaryFormatter binFormat = new BinaryFormatter();
            // Сохранить объект в локальном файле.
            using (Stream fStream = new FileStream(path,
               FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, temp);
            }
        }

        public void LoadData(string path)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = File.OpenRead(path))
            {
                KeyValuePair<DateTime, double>[] temp =
                     ( KeyValuePair<DateTime, double>[])binFormat.Deserialize(fStream);

                for (int i = 0; i < temp.Length; i++)
                {
                    _DataArray[i] = new KeyValuePair<DateTime, double>(temp[i].Key, temp[i].Value);
                }
                _firstIndex = 0;
                _lastIndex = temp.Length;
            }
        }

        public void TxtLog(TextBox t1, TextBox t2, int t2Max)
        {
            t1.Text = "";
            t2.Text = "";
            for (int i = _firstIndex; i != _lastIndex; ++i)
            {
                i %= _sizeArray;
                t1.AppendText(((int)(_DataArray[i].Value*1000)).ToString()+"\r\n");
               t2.AppendText(((t2Max/_DataArray[i].Value/1000)).ToString()+"\r\n");
            }
        }


    }
}
