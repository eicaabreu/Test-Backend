namespace TEST.Application.SeedWork.Models
{
    public interface IPaginationRequest
    {
        int Start { get; }
        int Length { get; }
    }
}
