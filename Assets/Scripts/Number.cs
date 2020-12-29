
public struct Number
{
    public int Value { get; }

    public Number(int num)
    {
        Value = num;
    }

    public static Number operator +(Number num1, Number num2) =>
        new Number(num1.Value + num2.Value);
}
