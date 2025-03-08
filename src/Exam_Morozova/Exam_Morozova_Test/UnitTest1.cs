using Xunit;
using Exam_Morozova;

public class GraphTests
{
    private double[,] adjacencyMatrix = {
        { 0, 2.75, double.MaxValue, double.MaxValue, 2.04, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue },
        { 2.75, 0, 0.63, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue },
        { double.MaxValue, 0.63, 0, 1.4, double.MaxValue, double.MaxValue, double.MaxValue, 1.72, double.MaxValue },
        { double.MaxValue, double.MaxValue, 1.4, 0, 1.51, double.MaxValue, 1.49, double.MaxValue, double.MaxValue },
        { 2.04, double.MaxValue, double.MaxValue, 1.51, 0, 0.73, double.MaxValue, double.MaxValue, double.MaxValue },
        { double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, 0.73, 0, 1.98, double.MaxValue, 3.5 },
        { double.MaxValue, double.MaxValue, double.MaxValue, 1.49, double.MaxValue, 1.98, 0, 0.37, double.MaxValue },
        { double.MaxValue, double.MaxValue, 1.72, double.MaxValue, double.MaxValue, double.MaxValue, 0.37, 0, 1.25 },
        { double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, 3.5, double.MaxValue, 1.25, 0 }
    };

    //  Тест 3: Проверка исключения вершин без контейнеров (исключаем вершины 5 и 9)
    [Fact]
    public void Dijkstra_ShouldHandleExcludedNodes()
    {
        double[,] modifiedMatrix = (double[,])adjacencyMatrix.Clone();
        for (int i = 0; i < 9; i++)
        {
            modifiedMatrix[4, i] = double.MaxValue;
            modifiedMatrix[i, 4] = double.MaxValue;
            modifiedMatrix[8, i] = double.MaxValue;
            modifiedMatrix[i, 8] = double.MaxValue;
        }

        double[] result = Graph.Dijkstra(modifiedMatrix, 0, 9);

        Assert.Equal(double.MaxValue, result[4]); // Вершина 5 недоступна
        Assert.Equal(double.MaxValue, result[8]); // Вершина 9 недоступна
    }
}
