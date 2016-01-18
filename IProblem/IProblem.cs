namespace ProjectEuler
{
    public interface IProblem
    {
        bool prepare();
        string compute();
    }
}
