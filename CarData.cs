using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesPredictor_001
{
    public class CarData
    {
        [LoadColumn(0)] // Specifies that the first column in the dataset corresponds to the Make property
        public string Make { get; set; }

        [LoadColumn(1)] // Specifies that the second column in the dataset corresponds to the Model property
        public string Model { get; set; }

        [LoadColumn(2)] // Specifies that the third column in the dataset corresponds to the Year property
        public float Year { get; set; }

        [LoadColumn(3)] // Specifies that the fourth column in the dataset corresponds to the Mileage property
        public float Mileage { get; set; }

        [LoadColumn(4)] // Specifies that the fifth column in the dataset corresponds to the Price property
        public float Price { get; set; }
    }

}
