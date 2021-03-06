﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public enum TypeDVD
    {
        doubleSided = 12000,
        singleSided = 6000
    }
    public class DVD : Storage
    {
        private double ReadingVelocity { get; set; }
        private double RecordingSpeed { get; set; }
        private double MaxSize { get; set; }
        private double Size { get; set; }

        public DVD(string name, string model, TypeDVD typeDVD)
        {
            ReadingVelocity = 10.5;
            RecordingSpeed = 10.5;
            Name = name;
            Model = model;
            MaxSize = (double)typeDVD;
        }

        public override double Copy(ref double data)
        {
            double time;
            if (MaxSize - Size >= data)
            {
                time = data / RecordingSpeed;
                Size = MaxSize - Size - data;
                data = 0;
                return time;
            }
            else
            {

                time = (MaxSize - Size) / RecordingSpeed;
                data = (data - MaxSize - Size);
                Size = MaxSize;
                return time;
            }
        }

        public override double GetFreeMemory()
        {
            return MaxSize - Size;
        }

        public override string GetInfo()
        {
            return string.Format($"{Model}({Name}):{Size}/{MaxSize}");
        }

        public override double GetMemory()
        {
            return MaxSize;
        }

        public override void Clear()
        {
            Size = 0;
        }
    }
}
