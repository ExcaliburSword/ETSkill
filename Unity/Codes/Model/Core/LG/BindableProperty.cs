using System;

namespace ET.LG
{
    public class BindableProperty<T> where T: IEquatable<T>
    {
      
        public T tempValue;

        public T Value
        {
            get
            {
                return this.OnGetValue();
            }
            set
            {
                this.OnSetValue?.Invoke(value);
            }
        }
        public Func<T> OnGetValue;
        public Action<T> OnSetValue;
        
        public double GetDouble() 
        {
            double d = 1;
            switch (this)
            {
                case BindableProperty<float> f:
                    d = f.tempValue;
                    break;
                case BindableProperty<int> i:
                    d = i.tempValue;
                    break;
                case BindableProperty<uint> ui:
                    d = ui.tempValue;
                    break;
                case BindableProperty<long> l:
                    d = l.tempValue;
                    break;
                case BindableProperty<ulong> ul:
                    d = ul.tempValue;
                    break;
                case BindableProperty<byte> b:
                    d = b.tempValue;
                    break;
                case BindableProperty<sbyte> sb:
                    d = sb.tempValue;
                    break;
                case BindableProperty<char> c:
                    d = c.tempValue;
                    break;
                case BindableProperty<double> db:
                    d = db.tempValue;
                    break;
                default:
                    Log.Debug("不是指定的数值类型，请添加");
                    break;
            }
            return d;
        }
        public void SetMValue(double d) 
        {
            switch (this)
            {
                case BindableProperty<float> f:
                    f.tempValue=(float)d;
                    break;
                case BindableProperty<int> i:
                     i.tempValue=(int)d;
                    break;
                case BindableProperty<uint> ui:
                    ui.tempValue=(uint)d;
                    break;
                case BindableProperty<long> l:
                    l.tempValue=(long)d;
                    break;
                case BindableProperty<ulong> ul:
                    ul.tempValue=(ulong)d;
                    break;
                case BindableProperty<byte> b:
                    b.tempValue=(byte)d;
                    break;
                case BindableProperty<sbyte> sb:
                    sb.tempValue=(sbyte)d;
                    break;
                case BindableProperty<char> c:
                    c.tempValue=(char)d;
                    break;
                case BindableProperty<double> db:
                    db.tempValue = d;
                    break;
                default:
                    Log.Debug("不是指定的数值类型，请添加");
                    break;
            }
        }

        public void SetMValue(T v)
        {
            this.tempValue = v;
        }
    }

    public static class BindablePropertyHelper
    {
        public static int OnGet_Normal_int(this BindableProperty<int> self) 
        {
            return self.tempValue;
        }

        public static T OnGet_Over0<T>(this BindableProperty<T> self) where T : IEquatable<T>
        {
            double d = self.GetDouble();
            if (d<0)
            {
                self.SetMValue(0);
            }
            return self.tempValue;
        }
 

        public static void OnSet_Normal_int(this BindableProperty<int> self, int v)
        {
            self.tempValue = v;
        }

     
        public static void OnSet_LeftBigger_int<T>(this BindableProperty<T> self, T v) where T: IEquatable<T>
        {
            double d = self.GetDouble();
            double v0 = ChangeToDouble(v);
            if (v0>d)
            {
                self.tempValue = v;
            }
        }
        private static double ChangeToDouble<T>(T v)
        {
            double d = 1;
            switch (v)
            {
                case float f:
                    d = f;
                    break;
                case int i:
                    d = i;
                    break;
                case uint ui:
                    d = ui;
                    break;
                case long l:
                    d = l;
                    break;
                case ulong ul:
                    d = ul;
                    break;
                case byte b:
                    d = b;
                    break;
                case sbyte sb:
                    d = sb;
                    break;
                case char c:
                    d = c;
                    break;
                case double db:
                    d = db;
                    break;
                default:
                    Log.Debug("不是指定的数值类型，请添加");
                    break;
            }
            return d;
        }
    }
}