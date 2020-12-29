
public class Addition : Sentence<int>
{
    public Addition(int num1, int num2) : base(num1, num2) { }

    public override int Operation(int num1, int num2) =>
        num1 + num2;
}

public abstract class Sentence<T> : IOperator<T>
{
    public T FirstNum { get; }
    public T SecondNum { get; }

    public T Result => Operation(FirstNum, SecondNum);

    protected Sentence(T num1, T num2)
    {
        FirstNum = num1;
        SecondNum = num2;
    }

    public abstract T Operation(T num1, T num2);
}

public interface IOperator<T>
{
    T Operation(T num1, T num2);
}


