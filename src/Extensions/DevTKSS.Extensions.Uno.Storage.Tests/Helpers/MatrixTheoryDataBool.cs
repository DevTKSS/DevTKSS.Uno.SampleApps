namespace DevTKSS.Extensions.Uno.Storage.Tests.Helpers;

public class MatrixTheoryDataBool<T1> : TheoryData<T1, bool>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MatrixTheoryDataBool{T1}"/> class by generating test data pairs from the provided values and all boolean values.
    /// </summary>
    /// <remarks>
    /// Each value in <paramref name="data"/> is combined with both boolean values, resulting in two test data entries per input value.
    /// This is useful for parameterized tests that require all combinations of a value and a boolean flag.
    /// </remarks>
    /// <param name="data">
    /// The collection of values to be paired with both <see langword="true"/> and <see langword="false"/> for test data generation.
    /// </param>
    public MatrixTheoryDataBool(IEnumerable<T1> data)
    {
        Contract.Assert(data is not null && data.Any());
        foreach (T1 t1 in data)
        {
            Add(t1, true);
            Add(t1, false);
        }
    }
}
