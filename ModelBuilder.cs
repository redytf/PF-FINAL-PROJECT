using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;

namespace CarSalesPredictor_001
{
    internal static class ModelBuilder
    {
        private static string _dataPath = "C:\\Users\\acer\\Downloads\\CarSalesPredictor_001\\Sales.csv";

        internal static ITransformer BuildAndTrainModel(MLContext mlContext)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<CarData>(_dataPath, hasHeader: true, separatorChar: ',');

            var dataProcessPipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: nameof(CarData.Price))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "MakeEncoded", inputColumnName: nameof(CarData.Make)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "ModelEncoded", inputColumnName: nameof(CarData.Model)))
                .Append(mlContext.Transforms.Concatenate("Features", "MakeEncoded", "ModelEncoded", nameof(CarData.Year), nameof(CarData.Mileage)))
                .Append(mlContext.Transforms.NormalizeMinMax("Features"));

            var trainer = mlContext.Regression.Trainers.FastTree();
            var trainingPipeline = dataProcessPipeline.Append(trainer);

            var model = trainingPipeline.Fit(dataView);

            return model;
        }
    }
}

