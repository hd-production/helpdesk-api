using AutoMapper;
using HdProduction.HelpDesk.Api.Models.Tickets;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Api.Configuration
{
  public class AutoMapperConfig
  {
    public static IMapper Configure()
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMissingTypeMaps = true;
        cfg.AllowNullCollections = true;
        cfg.AllowNullDestinationValues = true;
        CreateMapping(cfg);
      });

      return config.CreateMapper();
    }

    private static void CreateMapping(IProfileExpression cfg)
    {
      cfg.CreateMap<Ticket, TicketAdminResponseModel>();
      cfg.CreateMap<Ticket, TicketItemResponseModel>();
    }
  }
}