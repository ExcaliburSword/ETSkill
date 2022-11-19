using System;

namespace ET.LG
{
    public class BindableProperty<T> where T: IEquatable<T>
    {
      
        private T tempValue;
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
        private Func<T> OnGetValue;
        private Action<T> OnSetValue;
        
        public BindableProperty<T> RegistGet(Func<T> f)
        {
            this.OnGetValue = f;
            return this;
        }

        public BindableProperty<T> RegistSet(Action<T> a)
        {
            this.OnSetValue = a;
            return this;
        }

        public BindableProperty<T> UnRegistGet(Func<T> f)
        {
            this.OnGetValue -= f;
            return this;
        }

        public BindableProperty<T> UnRegistSet(Action<T> a)
        {
            this.OnSetValue -= a;
            return this;
        }
        public double GetTempValueAsDouble() 
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
                    throw new Exception("预期之外的类型，不是预设的数值类型");
            }
            return d;
        }
        public void SetTempValue(double d) 
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
                    throw new Exception("预期之外的类型，不是预设的数值类型");
            }
        }

        public void SetTempValue(T v)
        {
            this.tempValue = v;
        }

        public T GetTempValue()
        {
            return this.tempValue;
        }
    }

    public static class BindablePropertyHelper
    {
        public static int OnGet_Normal_int(this BindableProperty<int> self) 
        {
            return self.GetTempValue();
        }

        public static T OnGet_Over0<T>(this BindableProperty<T> self) where T : IEquatable<T>
        {
            double d = self.GetTempValueAsDouble();
            if (d<0)
            {
                self.SetTempValue(0);
            }
            return self.GetTempValue();
        }
        
        public static void OnSet_LeftBigger<T>(this BindableProperty<T> self, T v) where T: IEquatable<T>
        {
            double d = self.GetTempValueAsDouble();
            double v0 = ChangeToDouble(v);
            if (v0>d)
            {
                self.SetTempValue(v);
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
                    throw new Exception("预期之外的类型，不是预设的数值类型");
            }
            return d;
        }
    }
}