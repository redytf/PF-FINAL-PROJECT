using System;
using System.Windows.Forms;
using Microsoft.ML;

namespace CarSalesPredictor_001
{
    public partial class Form1 : Form
    {
        private readonly Predictor _predictor;
        private readonly MLContext _mlContext;


        public Form1()
        {
            InitializeComponent();
            _predictor = new Predictor();
            _mlContext = new MLContext();
        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
            try
            {
                var carData = new CarData
                {
                    Make = txtMake.Text,
                    Model = txtModel.Text,
                    Year = float.Parse(txtYear.Text),
                    Mileage = float.Parse(txtMileage.Text)
                };

                float predictedPrice = _predictor.PredictPrice(carData);
                lblPredictedPrice.Text = $"Predicted Price: {predictedPrice:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
