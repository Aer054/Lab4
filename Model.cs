using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Model
    {
        private int age;
        private double height;
        private double weight;
        private string bodyType;
        private double distance;
        private double calories;
        private string name;
        private string gender;
        private string activity;
        private string eattingPlan;
        #region gettrs
        public string EattingPlan
        {
            get
            {
                return this.eattingPlan;
            }

            set
            {
                this.eattingPlan = value;
            }
        }
        public string Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                this.gender = value;
            }
        }
        public string Activity
        {
            get
            {
                return this.activity;
            }

            set
            {
                this.activity = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }

            set
            {
                this.weight = value;
            }
        }
        public string BodyType
        {
            get
            {
                return this.bodyType;
            }

            set
            {
                this.bodyType = value;
            }
        }
        public double Distance
        {
            get
            {
                return this.distance;
            }

            set
            {
                this.distance = value;
            }
        }
        public double Calories
        {
            get
            {
                return this.calories;
            }

            set
            {
                this.calories = value;
            }
        }
        #endregion
        public void WhatTypeOfBody()
        {
            bodyType = "Астеник";
        }
        public void HowManyCalories()
        {
            calories = distance/100.0;
        }
        public void GetEattingPlan()
        {
            eattingPlan="Кушай больше овощей))))";
        }
        public Model(string Name0,int Age0,double Height0,double Weight0,string BodyType0,double Calories0,string Gender0,string Activity0)
        {
            name=Name0;
            age=Age0;
            weight=Weight0;
            height=Height0;
            bodyType=BodyType0;
            calories=Calories0;
            gender = Gender0;
            activity=Activity0;
        }
    }
}
