using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Singleton<T> where T : class
        {
            private static T instance_;
            protected Singleton() { }
            private static T CreateInstance()
            {
                System.Reflection.ConstructorInfo cInfo = typeof(T).GetConstructor(
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                    null,
                    new Type[0],
                    new System.Reflection.ParameterModifier[0]);
                return (T)cInfo.Invoke(null);
            }
            public static T Instance
            {
                get
                {
                    if (instance_ == null)
                        instance_ = CreateInstance();
                    return instance_;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Singleton<Form1> sg;
        }
    }
}
