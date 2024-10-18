using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 倍福读取Demo
{
    public class GridItem : INotifyPropertyChanged
    {
        public GridItem(string name, string addr, string type)
        {
            Name = name;
            Addr = addr;
            Type = type;
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Addr
        {
            get { return _addr; }
            set
            {
                if (_addr != value)
                {
                    _addr = value;
                    OnPropertyChanged("Addr");
                }
            }
        }
        public string Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _name;
        private string _addr;
        private string _type;
    }
}
