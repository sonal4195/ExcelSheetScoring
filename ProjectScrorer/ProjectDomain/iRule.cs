
namespace ProjectDomain
{
    public interface IRule
    {
        Result Evaluate(ExcelDataRow row);
    }
}
