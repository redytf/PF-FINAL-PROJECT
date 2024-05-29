using CarSalesPredictor_001;
using Microsoft.ML;

public class Predictor
{
    private readonly ITransformer _model;
    private readonly MLContext _mlContext;

    public Predictor()
    {
        _mlContext = new MLContext();
        _model = ModelBuilder.BuildAndTrainModel(_mlContext);
    }

    public float PredictPrice(CarData carData)
    {
        var predictionEngine = _mlContext.Model.CreatePredictionEngine<CarData, CarPricePrediction>(_model);
        var prediction = predictionEngine.Predict(carData);
        return prediction.Score;
    }
}
