using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace 倍福读取Demo
{
    public class GridItem2  :INotifyPropertyChanged
    {
        public string name;
        public string Name { 
            get { return name; }

            set{ name = value; 
                
                OnPropertyChanged(new PropertyChangedEventArgs("Name")); }
        }
        public string addr="DB100";
        public string Addr
        {
            get { return addr; }

            set { addr = value;
                
                OnPropertyChanged(new PropertyChangedEventArgs("Addr")); }
        }


        public string type = "bool";
        public string Type {
            get { return type; }

            set { type = value;
                
                OnPropertyChanged(new PropertyChangedEventArgs("Type")); }
        }
        public string val;
        public string Val {
            get { return val; }

            set { val= value; 
                
                OnPropertyChanged(new PropertyChangedEventArgs("Val")); }
        } 

        
        #region // INotifyPropertyChanged成员
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
        #endregion
    }
}
