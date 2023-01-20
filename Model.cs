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
        #region gettrs
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

    }
}
