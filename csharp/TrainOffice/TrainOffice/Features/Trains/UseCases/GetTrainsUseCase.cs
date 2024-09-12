namespace TrainOffice.Features.Trains.UseCases;

using TrainOffice.Features.Domain;

public interface IGetTrainsUseCase
{
    Task<IEnumerable<GetTrainsDTO>> ExecuteAsync();
}

public class GetTrainsUseCase : IGetTrainsUseCase
{
    private readonly ITrainRepository _trainRepository;
    private readonly ICoachRepository _coachRepository;
    private readonly ISeatRepository _seatRepository;

    public GetTrainsUseCase(ITrainRepository trainRepository, ICoachRepository coachRepository, ISeatRepository seatRepository)
    {
        _trainRepository = trainRepository;
        _coachRepository = coachRepository;
        _seatRepository = seatRepository;
    }

    public async Task<IEnumerable<GetTrainsDTO>> ExecuteAsync()
    {
        var trains = await _trainRepository.GetAllAsync();
        var coaches = await _coachRepository.GetAllAsync();
        var seats = await _seatRepository.GetAllAsync();

        return trains.Select(train => new GetTrainsDTO
        {
            Name = train.Name,
            Arrival = train.Arrival,
            Departure = train.Departure,
            Coaches = coaches.Where(c => c.TrainId == train.Id).Select(coach => new CoachDTO
            {
                Name = coach.Name,
                Seats = seats.Where(s => s.CoachId == coach.Id).Select(seat => new SeatDTO
                {
                    Reserved = seat.IsReserved,
                    Name = seat.Name
                }).ToList()
            }).ToList()
        }).ToList();
    }
}