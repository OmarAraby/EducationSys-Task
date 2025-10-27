using EducationSys.Application.DTOs.Mark;
using EducationSys.Application.Helpers.GeneralResult;

namespace EducationSys.Application.Interfaces
{
    public interface IMarkService
    {

        ApiResponse<MarkDto> RecordMark(CreateMarkDto createMarkDto);
        ApiResponse<double> CalculateAverageForClass(int classId);
    }
}
