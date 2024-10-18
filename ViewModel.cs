using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Prism.Commands;

/**
namespace 倍福读取Demo
{
    public class GridViewModel
    {
        public GridViewModel()
        {
            GridSource = new GridModel();
            GridSource.GridData.Add(new GridItem("王路飞", "男"));
            GridSource.GridData.Add(new GridItem("娜美", "女", true));
            AddCommand = new DelegateCommand(Add);
            DecCommand = new DelegateCommand(Dec, (obj) => true);
            ModifyCommand = new DelegateCommand(Modify, (obj) => true);
            ShowCommand = new DelegateCommand(Show, (obj) => true);
        }
        public GridModel GridSource
        { get; set; }

        public ICommand AddCommand
        { get; set; }
        public ICommand DecCommand
        { get; set; }
        public ICommand ModifyCommand
        { get; set; }
        public ICommand ShowCommand
        { get; set; }

        private void Add(object obj)
        {
            GridSource.GridData.Add(new GridItem("Luffy", "man", true));
        }
        private void Dec(object obj)
        {
            GridSource.GridData.RemoveAt(0);
        }
        private void Modify(object obj)
        {
            GridSource.GridData[0].Name = "路飞";
            GridSource.GridData[0].Sex = "女";
            GridSource.GridData[0].UserChecked = true;
        }
        private void Show(object obj)
        {
            MessageBox.Show(GridSource.GridData[0].Name + "," + GridSource.GridData[0].Sex + "," + GridSource.GridData[0].UserChecked);
        }
    }
}


*/