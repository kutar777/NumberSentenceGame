
public class Addition : Sentence<int>
{
    public Addition(int num1, int num2) : base(num1, num2) { }

    protected override int Operation(int num1, int num2) =>
        num1 + num2;
}

public abstract class Sentence<T>
{
    public T FirstNum { get; }
    public T SecondNum { get; }

    public T Result => Operation(FirstNum, SecondNum);

    protected Sentence(T num1, T num2)
    {
        FirstNum = num1;
        SecondNum = num2;
    }

    protected abstract T Operation(T num1, T num2);
}
