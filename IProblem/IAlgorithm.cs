namespace ProjectEuler
{
    public enum AlgorithmLanguage
    {
        CSharp,
        FSharp,
        Unknown,
    }

    public interface IAlgorithm
    {
        bool Prepare();
        string Compute();
    }
}
